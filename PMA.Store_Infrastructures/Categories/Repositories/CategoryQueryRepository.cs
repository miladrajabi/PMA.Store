using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMA.Store_Domain.Categories.Entities;
using PMA.Store_Domain.Categories.Repositories.Interface;

namespace PMA.Store_Infrastructures.Categories.Repositories
{
    public class CategoryQueryRepository : ICategoryQueryRepository
    {
        private readonly StoreDbContext dbContext;

        public CategoryQueryRepository(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Category> GetAll()
        {
            return dbContext.Categories.Include(c => c.Photo).Include(c => c.Children)
                .ThenInclude(x => x.Photo)
                .Where(c => !c.ParentId.HasValue).ToList();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await dbContext.Categories.Include(c => c.Photo).Include(c => c.Children)
                .ThenInclude(x => x.Photo)
                .Where(c => !c.ParentId.HasValue).ToListAsync();
        }

        public List<Category> GetParentCategories()
        {
            return dbContext.Categories.Where(c => !c.ParentId.HasValue).ToList();
        }

        public async Task<List<Category>> GetParentCategoriesAsync()
        {
            return await dbContext.Categories.Where(c => !c.ParentId.HasValue).ToListAsync();
        }
    }
}