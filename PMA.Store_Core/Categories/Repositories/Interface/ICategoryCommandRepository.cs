using System.Collections.Generic;
using System.Threading.Tasks;
using PMA.Store_Domain.Categories.Entities;

namespace PMA.Store_Domain.Categories.Repositories.Interface
{
    public interface ICategoryCommandRepository
    {
        void Add(Category category);
        Task AddAsync(Category category);
        Task<int> SaveChangesAsync();
        int SaveChange();

    }
}