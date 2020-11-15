using System.Threading.Tasks;
using PMA.Store_Domain.Masters.Entities;
using PMA.Store_Domain.Masters.Repositories.Interface;

namespace PMA.Store_Infrastructures.Masters.Repositories
{
    public class MasterCommandRepository : IMasterCommandRepository
    {
        private readonly StoreDbContext _dbContext;

        public MasterCommandRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Master master)
        {
            _dbContext.Masters.Add(master);
        }
        public async Task AddAsync(Master master)
        {
            await _dbContext.Masters.AddAsync(master);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public int SaveChange()
        {
            return _dbContext.SaveChanges();
        }
    }
}