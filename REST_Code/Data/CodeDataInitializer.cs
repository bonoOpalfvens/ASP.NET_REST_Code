namespace REST_Code.Data
{
    public class CodeDataInitializer
    {
        private readonly CodeContext _dbContext;

        public CodeDataInitializer(CodeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                // Seed db, see DBContext
            }
        }
    }
}
