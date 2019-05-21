using Microsoft.EntityFrameworkCore;
using REST_Code.Models;
using REST_Code.Models.IRepository;
using System.Linq;

namespace REST_Code.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Init
        private readonly CodeContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(CodeContext dbContext)
        {
            _context = dbContext;
            _users = dbContext.AppUsers;
        }

        private IQueryable<User> Users => _users
            .Include(p => p.Avatar)
            .Include(p => p.CreatedPosts)
            .Include(p => p.LikedPosts)
            .Include(p => p.CreatedComments);
        #endregion

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User GetBy(string username)
        {
            return Users.Include(u => u.CreatedPosts).Include(u => u.Boards).Include(u => u.LikedPosts).SingleOrDefault(u => u.Username.Equals(username));
        }

        public User GetByEmail(string email)
        {
            return Users.Include(u => u.CreatedPosts).Include(u => u.Boards).Include(u => u.LikedPosts).SingleOrDefault(u => u.Email.Equals(email));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetUser(long id, out User user)
        {
            user = Users.Include(u => u.CreatedPosts).Include(u => u.Boards).Include(u => u.LikedPosts).FirstOrDefault(u => u.Id == id);
            return user != null;
        }

        public void Update(User user)
        {
            _users.Update(user);
        }
    }
}
