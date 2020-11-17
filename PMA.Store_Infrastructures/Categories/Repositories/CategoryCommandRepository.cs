using System.Collections.Generic;
using System.Threading.Tasks;
using PMA.Store_Domain.Categories.Entities;
using PMA.Store_Domain.Categories.Repositories.Interface;

namespace PMA.Store_Infrastructures.Categories.Repositories
{
    public class CategoryCommandRepository : ICategoryCommandRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryCommandRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Category category)
        {
            _dbContext.Categories.Add(category);
        }

        public async Task AddAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
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