using Microsoft.EntityFrameworkCore;
using REST_Code.Models;
using REST_Code.Models.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace REST_Code.Data.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly CodeContext _context;
        private readonly DbSet<Post> _posts;

        public PostRepository(CodeContext dbContext)
        {
            _context = dbContext;
            _posts = dbContext.Posts;
        }

        private IQueryable<Post> Posts => _posts
            .Include(p => p.Board).ThenInclude(b => b.Icon)
            .Include(p => p.User).ThenInclude(p => p.Avatar)
            .Include(p => p.Comments).ThenInclude(c => c.User).ThenInclude(u => u.Avatar)
            .Include(p => p.Comments).ThenInclude(c => c.Likes)
            .Include(p => p.Likes);


        public void Add(Post post)
        {
            _posts.Add(post);
        }

        public void Delete(Post post)
        {
            _posts.Remove(post);
        }

        public IEnumerable<Post> GetAll()
        {
            return Posts.ToList();
        }

        public Post GetBy(long id)
        {
            return Posts.SingleOrDefault(p => p.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetPost(long id, out Post post)
        {
            post = Posts.FirstOrDefault(p => p.Id == id);
            return post != null;
        }

        public void Update(Post post)
        {
            _posts.Update(post);
        }
    }
}
