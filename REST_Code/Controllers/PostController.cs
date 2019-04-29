using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Post> GetPosts()
        {
            return _postRepository.GetAll().OrderBy(p => p.DateAdded);
        }

        // GET : api/post/id
        /// <summary>
        /// Get the post with the given id
        /// </summary>
        /// <param name="id">the id of the post</param>
        /// <returns>the post</returns>
        [HttpGet("{id}")]
        public ActionResult<Post> GetPost(long id)
        {
            Post post = _postRepository.GetBy(id);
            if (post == null)
                return NotFound();
            return post;
        }
    }
}