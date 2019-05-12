using Microsoft.AspNetCore.Mvc;
using REST_Code.DTOs;
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
    public class PostController : Controller
    {
        #region Init
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository context)
        {
            _postRepository = context;
        }
        #endregion

        // GET : api/post
        /// <summary>
        /// Get all the posts
        /// </summary>
        /// <returns>the posts</returns>
        [HttpGet]
        public IEnumerable<PostDTO> GetPosts()
        {
            List<PostDTO> postDTOs = new List<PostDTO>();
            foreach (Post post in _postRepository.GetAll().OrderByDescending(b => b.DateAdded))
            {
                PostDTO temp = PostDTO.FromPost(post);
                temp.Board = new BoardDTO { Id = post.Board.Id, Description = post.Board.Description, Name = post.Board.Name, Icon = post.Board.Icon.Url, Likes = post.Likes.Count };
                postDTOs.Add(temp);
            }
            return postDTOs;
        }

        // GET : api/post/id
        /// <summary>
        /// Get the post with the given id
        /// </summary>
        /// <param name="id">the id of the post</param>
        /// <returns>the post</returns>
        [HttpGet("{id}")]
        public ActionResult<PostDTO> GetPost(long id)
        {
            Post post = _postRepository.GetBy(id);
            if (post == null)
                return NotFound();
            PostDTO temp = PostDTO.FromPost(post);
            temp.Board = new BoardDTO { Id = post.Board.Id, Description = post.Board.Description, Name = post.Board.Name, Icon = post.Board.Icon.Url, Likes = post.Likes.Count };
            return temp;
        }
    }
}