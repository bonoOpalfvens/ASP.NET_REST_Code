using System.Collections.Generic;

namespace REST_Code.Models.IRepository
{
    public interface IBoardRepository
    {
        Board GetBy(long id);
        bool TryGetBoard(long id, out Board board);
        IEnumerable<Board> GetAll();
        void Add(Board board);
        void SaveChanges();
    }
}
