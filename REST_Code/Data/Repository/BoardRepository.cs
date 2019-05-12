using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using REST_Code.Models;
using REST_Code.Models.IRepository;

namespace REST_Code.Data.Repository
{
    public class BoardRepository : IBoardRepository
    {
        private readonly CodeContext _context;
        private readonly DbSet<Board> _boards;

        public BoardRepository(CodeContext dbContext)
        {
            _context = dbContext;
            _boards = dbContext.Boards;
        }
        
        private IQueryable<Board> Boards => _boards
            .Include(b => b.Icon)
            .Include(p => p.Posts).ThenInclude(p => p.User)
            .Include(p => p.Likes);

        public void Add(Board board)
        {
            _boards.Add(board);
        }

        public IEnumerable<Board> GetAll()
        {
            return Boards.ToList();
        }

        public Board GetBy(long id)
        {
            return Boards.SingleOrDefault(b => b.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetBoard(long id, out Board board)
        {
            board = Boards.FirstOrDefault(b => b.Id == id);
            return board != null;
        }
    }
}
