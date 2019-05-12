using Microsoft.AspNetCore.Mvc;
using REST_Code.DTOs.Models;
using REST_Code.Models;
using REST_Code.Models.IRepository;
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
        
        public BoardController(IBoardRepository context)
        {
            _boardRepository = context;
        }
        #endregion

        // GET : api/board
        /// <summary>
        /// Get all the boards
        /// </summary>
        /// <returns>the boards</returns>
        [HttpGet]
        public IEnumerable<BoardDTO> GetBoards()
        {
            List<BoardDTO> boardDTOs = new List<BoardDTO>();
            foreach (Board board in _boardRepository.GetAll().OrderBy(b => b.Name))
            {
                BoardDTO temp = BoardDTO.FromBoard(board);
                temp.Posts = board.Posts.Select(PostDTO.FromPost);
                boardDTOs.Add(temp);
            }
            return boardDTOs;
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
            return temp;
        }
    }
}