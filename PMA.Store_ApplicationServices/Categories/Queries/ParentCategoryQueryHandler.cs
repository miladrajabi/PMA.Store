using System.Collections.Generic;
using System.Threading.Tasks;
using PMA.Store_Domain.Categories.Entities;
using PMA.Store_Domain.Categories.Queries;
using PMA.Store_Domain.Categories.Repositories.Interface;
using PMA.Store_Framework.Queries;

namespace PMA.Store_ApplicationServices.Categories.Queries
{
    public class ParentCategoryQueryHandler : IQueryHandler<ParentCategoryQuery, List<Category>>
    {
        private readonly ICategoryQueryRepository repository;

        public ParentCategoryQueryHandler(ICategoryQueryRepository repository)
        {
            this.repository = repository;
        }

        public List<Category> Handle(ParentCategoryQuery query)
        {
            return repository.GetParentCategories();
        }

        public async Task<List<Category>> HandleAsync(ParentCategoryQuery query)
        {
            return await repository.GetParentCategoriesAsync();
        }
    }
}