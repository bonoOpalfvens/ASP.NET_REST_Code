namespace REST_Code.Models.IRepository
{
    public interface IUserRepository
    {
        User GetBy(string username);
        void Add(User user);
        bool TryGetUser(long id, out User user);
        void Update(User user);
        void SaveChanges();
    }
}
