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
            return _posts.ToList();
        }

        public Post GetBy(long id)
        {
            return _posts.SingleOrDefault(p => p.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetPost(long id, out Post post)
        {
            post = _posts.FirstOrDefault(p => p.Id == id);
            return post != null;
        }

        public void Update(Post post)
        {
            _posts.Update(post);
        }
    }
}
