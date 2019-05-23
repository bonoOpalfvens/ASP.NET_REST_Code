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
    /// Defines the <see cref="PostController" />
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PostController : Controller
    {
        /// <summary>
        /// Defines the _postRepository
        /// </summary>
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostController"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="IPostRepository"/></param>
        public PostController(IPostRepository context, IUserRepository userRepository)
        {
            _postRepository = context;
            _userRepository = userRepository;
        }

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

                if (User.Identity.IsAuthenticated && post.Likes.Any(l => l.User.Username.Equals(User.Identity.Name)))
                {
                    temp.IsLiking = true;
                }
                postDTOs.Add(temp);
            }
            return postDTOs;
        }


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

            if (User.Identity.IsAuthenticated)
            {
                if(post.Likes.Any(l => l.User.Username.Equals(User.Identity.Name)))
                    temp.IsLiking = true;

                temp.Comments = post.Comments.Select(c => CommentDTO.FromComment(c, User.Identity.Name));
            }
            else
            {
                temp.Comments = post.Comments.Select(CommentDTO.FromComment);
            }
            return temp;
        }

        // POST : api/post/postid/comment/commentid/like
        /// <summary>
        /// Like a post
        /// </summary>
        /// <param name="postId">the Id of the post</param>
        /// <param name="commentId">the Id of the post</param>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{postId}/comment/{commentId}/like")]
        public ActionResult<Boolean> LikeComment(long postId, long commentId)
        {
            Post post = _postRepository.GetBy(postId);
            if (post == null)
                return NotFound();
            Comment comment = post.Comments.FirstOrDefault(c => c.Id == commentId);
            if (comment == null)
                return NotFound();

            if (User.Identity.IsAuthenticated && comment.Likes.Any(l => l.User.Username.Equals(User.Identity.Name)))
            {
                comment.Likes.Remove(comment.Likes.First(l => l.User.Username.Equals(User.Identity.Name)));
            }
            else
            {
                comment.Likes.Add(new CommentLikes { Comment = comment, User = _userRepository.GetBy(User.Identity.Name), DateLiked = DateTime.Now });
            }
            _postRepository.SaveChanges();
            return true;
        }

        // POST : api/post/id/like
        /// <summary>
        /// Like a post
        /// </summary>
        /// <param name="id">the Id of the post</param>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{id}/like")]
        public ActionResult<Boolean> Like(long id)
        {
            Post post = _postRepository.GetBy(id);
            if (post == null)
                return NotFound();

            if (User.Identity.IsAuthenticated && post.Likes.Any(l => l.User.Username.Equals(User.Identity.Name)))
            {
                post.Likes.Remove(post.Likes.First(l => l.User.Username.Equals(User.Identity.Name)));
            }
            else
            {
                post.Likes.Add(new PostLikes { Post = post, User = _userRepository.GetBy(User.Identity.Name), DateLiked = DateTime.Now });
            }
            _postRepository.SaveChanges();
            return true;
        }
    }
}
