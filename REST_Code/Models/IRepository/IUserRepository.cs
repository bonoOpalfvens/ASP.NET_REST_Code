namespace REST_Code.Models.IRepository
{
    public interface IUserRepository
    {
        User GetBy(string username);
        User GetByEmail(string email);
        void Add(User user);
        bool TryGetUser(long id, out User user);
        void Update(User user);
        void SaveChanges();
    }
}
