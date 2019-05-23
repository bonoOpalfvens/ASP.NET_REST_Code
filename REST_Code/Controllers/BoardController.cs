using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using REST_Code.DTOs.Models;
using REST_Code.Models;
using REST_Code.Models.DataBindings;
using REST_Code.Models.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace REST_Code.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class BoardController : Controller
    {
        #region Init
        private readonly IBoardRepository _boardRepository;
        private readonly IUserRepository _userRepository;

        public BoardController(IBoardRepository context, IUserRepository userRepository)
        {
            _boardRepository = context;
            _userRepository = userRepository;
        }
        #endregion

        // GET : api/board/top
        /// <summary>
        /// Get top 5 boards
        /// </summary>
        /// <returns>the top 5 boards</returns>
        [HttpGet("top")]
        public IEnumerable<BoardDTO> GetTopBoards()
        {
            if (User.Identity.IsAuthenticated)
            {
                IEnumerable<Board> _boards = _boardRepository.GetAll().OrderBy(b => b.Posts.Count).ThenByDescending(b => b.Likes.Count);
                List<BoardDTO> tempBoards = new List<BoardDTO>();
                foreach (Board board in _boards)
                {
                    BoardDTO tempBoard = BoardDTO.FromBoard(board);
                    if (board.Likes.Any(l => l.User.Username.Equals(User.Identity.Name)))
                    {
                        tempBoard.IsLiking = true;
                    }
                    tempBoards.Add(tempBoard);
                }
                return tempBoards;
            }
            return _boardRepository.GetAll().OrderBy(b => b.Posts.Count).ThenByDescending(b => b.Likes.Count).Take(5).Select(BoardDTO.FromBoard);
        }

        // GET : api/board
        /// <summary>
        /// Get all the boards
        /// </summary>
        /// <returns>the boards</returns>
        [HttpGet]
        public IEnumerable<BoardDTO> GetBoards()
        {
            if (User.Identity.IsAuthenticated)
            {
                IEnumerable<Board> _boards = _boardRepository.GetAll().OrderBy(b => b.Posts.Count).ThenByDescending(b => b.Likes.Count);
                List<BoardDTO> tempBoards = new List<BoardDTO>();
                foreach (Board board in _boards)
                {
                    BoardDTO tempBoard = BoardDTO.FromBoard(board);
                    if(board.Likes.Any(l => l.User.Username.Equals(User.Identity.Name))){
                        tempBoard.IsLiking = true;
                    }
                    tempBoards.Add(tempBoard);
                }
                return tempBoards;
            }
            return _boardRepository.GetAll().OrderBy(b => b.Posts.Count).ThenByDescending(b => b.Likes.Count).Select(BoardDTO.FromBoard);
        }

        // GET : api/board/id
        /// <summary>
        /// Get the board with the given id
        /// </summary>
        /// <param name="id">the id of the board</param>
        /// <returns>the board</returns>
        [HttpGet("{id}")]
        public ActionResult<BoardDTO> GetBoard(long id)
        {
            Board board = _boardRepository.GetBy(id);
            if (board == null)
                return NotFound();
            BoardDTO temp = BoardDTO.FromBoard(board);
            temp.Posts = board.Posts.Select(PostDTO.FromPost);

            if (User.Identity.IsAuthenticated && board.Likes.Any(l => l.User.Username.Equals(User.Identity.Name)))
            {
                temp.IsLiking = true;
            }
            return temp;
        }

        // POST : api/board/id/like
        /// <summary>
        /// Like a board
        /// </summary>
        /// <param name="id">the Id of the board</param>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{id}/like")]
        public ActionResult<Boolean> Like(long id)
        {
            Board board = _boardRepository.GetBy(id);
            if (board == null)
                return NotFound();

            if (User.Identity.IsAuthenticated && board.Likes.Any(l => l.User.Username.Equals(User.Identity.Name)))
            {
                board.Likes.Remove(board.Likes.First(l => l.User.Username.Equals(User.Identity.Name)));
            }
            else
            {
                board.Likes.Add(new BoardLikes { Board = board, User = _userRepository.GetBy(User.Identity.Name), DateLiked = DateTime.Now });
            }
            _boardRepository.SaveChanges();
            return true;
        }
    }
}