using System.Collections.Generic;
using System.Threading.Tasks;
using PMA.Store_Domain.Categories.Entities;

namespace PMA.Store_Domain.Categories.Repositories.Interface
{
    public interface ICategoryQueryRepository
    {
        List<Category> GetAll();
        Task<List<Category>> GetAllAsync();
        List<Category> GetParentCategories();
        Task<List<Category>> GetParentCategoriesAsync();
    }
}