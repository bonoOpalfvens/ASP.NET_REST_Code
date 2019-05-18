using System.Collections.Generic;

namespace REST_Code.Models.IRepository
{
    public interface IIconRepository
    {
        IEnumerable<Icon> GetAll();
        Icon GetBy(long id);
        bool TryGetIcon(long id, out Icon icon);
    }
}
