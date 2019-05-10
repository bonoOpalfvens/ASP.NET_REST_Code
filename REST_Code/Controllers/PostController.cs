using Microsoft.AspNetCore.Mvc;
using REST_Code.DTOs;
using REST_Code.Models;
using REST_Code.Models.IRepository;
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
            IEnumerable<PostDTO> posts = _postRepository.GetAll().OrderBy(p => p.DateAdded).Select(post => new PostDTO { Id = post.Board.Id, Title = post.Title, BoardId = post.Board.Id, BoardIcon = post.Board.Icon, BoardName = post.Board.Name, User = post.User, DateAdded = post.DateAdded, Comments = post.Comments, Likes = post.Likes });

            return posts;
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
            return new PostDTO { Id = post.Board.Id, Title = post.Title, BoardId = post.Board.Id, BoardIcon = post.Board.Icon, BoardName = post.Board.Name, User = post.User, DateAdded = post.DateAdded, Comments = post.Comments, Likes = post.Likes };
        }
    }
}