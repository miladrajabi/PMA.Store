using System.Collections.Generic;
using System.Threading.Tasks;
using PMA.Store_Domain.Categories.Entities;
using PMA.Store_Domain.Categories.Repositories.Interface;

namespace PMA.Store_Infrastructures.Categories.Repositories
{
    public class CategoryCommandRepository : ICategoryCommandRepository
    {
        public void Add(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}