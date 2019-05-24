namespace REST_Code.Controllers
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using REST_Code.DTOs.Models;
    using REST_Code.Models;
    using REST_Code.Models.DataBindings;
    using REST_Code.Models.IRepository;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="BoardController" />
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class BoardController : Controller
    {
        /// <summary>
        /// Defines the _boardRepository
        /// </summary>
        private readonly IBoardRepository _boardRepository;

        /// <summary>
        /// Defines the _userRepository
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardController"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="IBoardRepository"/></param>
        /// <param name="userRepository">The userRepository<see cref="IUserRepository"/></param>
        public BoardController(IBoardRepository context, IUserRepository userRepository)
        {
            _boardRepository = context;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get top 5 boards
        /// </summary>
        /// <returns>the top 5 boards</returns>
        [HttpGet("top")]
        public IEnumerable<BoardDTO> GetTopBoards()
        {
            if (User.Identity.IsAuthenticated)
            {
                IEnumerable<Board> _boards = _boardRepository.GetAll().OrderByDescending(b => b.Likes.Count).ThenByDescending(b => b.Posts.Count).Take(5);
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
            return _boardRepository.GetAll().OrderByDescending(b => b.Likes.Count).ThenByDescending(b => b.Posts.Count).Take(5).Select(BoardDTO.FromBoard);
        }

        /// <summary>
        /// Get all the boards
        /// </summary>
        /// <returns>the boards</returns>
        [HttpGet]
        public IEnumerable<BoardDTO> GetBoards()
        {
            if (User.Identity.IsAuthenticated)
            {
                IEnumerable<Board> _boards = _boardRepository.GetAll().OrderByDescending(b => b.Likes.Count).ThenByDescending(b => b.Posts.Count);
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
            return _boardRepository.GetAll().OrderByDescending(b => b.Likes.Count).ThenByDescending(b => b.Posts.Count).Select(BoardDTO.FromBoard);
        }

        /// <summary>
        /// Get all the boards you haven't liked yet
        /// </summary>
        /// <returns>the boards</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("notLiked")]
        public IEnumerable<BoardDTO> GetBoardsNotLiked()
        {
            IEnumerable<Board> _boards = _boardRepository.GetAll().Where(b => !b.Likes.Any(l => l.User.Username.Equals(User.Identity.Name))).OrderByDescending(b => b.Likes.Count).ThenByDescending(b => b.Posts.Count);

            return _boards.Select(BoardDTO.FromBoard);
        }

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

        /// <summary>
        /// Like a board
        /// </summary>
        /// <param name="id">the Id of the board</param>
        /// <returns>The <see cref="ActionResult{Boolean}"/></returns>
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

