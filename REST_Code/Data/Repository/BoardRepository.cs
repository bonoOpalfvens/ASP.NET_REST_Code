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

        public void Add(Board board)
        {
            _boards.Add(board);
        }

        public IEnumerable<Board> GetAll()
        {
            return _boards.ToList();
        }

        public Board GetBy(long id)
        {
            return _boards.Include(b => b.Posts).SingleOrDefault(b => b.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetBoard(long id, out Board board)
        {
            board = _boards.Include(b => b.Posts).FirstOrDefault(b => b.Id == id);
            return board != null;
        }
    }
}
