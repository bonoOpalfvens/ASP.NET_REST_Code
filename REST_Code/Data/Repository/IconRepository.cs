using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using REST_Code.Models;
using REST_Code.Models.IRepository;

namespace REST_Code.Data.Repository
{
    public class IconRepository : IIconRepository
    {
        private readonly CodeContext _context;
        private readonly DbSet<Icon> _icons;

        public IconRepository(CodeContext dbContext)
        {
            _context = dbContext;
            _icons = dbContext.Icons;
        }

        public IEnumerable<Icon> GetAll()
        {
            return _icons.ToList();
        }

        public Icon GetBy(long id)
        {
            return _icons.SingleOrDefault(b => b.Id == id);
        }

        public bool TryGetIcon(long id, out Icon icon)
        {
            icon = _icons.FirstOrDefault(b => b.Id == id);
            return icon != null;
        }
    }
}
