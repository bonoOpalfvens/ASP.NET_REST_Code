using System.Collections.Generic;

namespace REST_Code.Models.IRepository
{
    public interface IPostRepository
    {
        Post GetBy(long id);
        bool TryGetPost(long id, out Post post);
        IEnumerable<Post> GetAll();
        void Add(Post post);
        void Delete(Post post);
        void Update(Post post);
        void SaveChanges();
    }
}
