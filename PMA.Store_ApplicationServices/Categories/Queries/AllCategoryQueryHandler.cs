using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMA.Store_Domain.Categories.Entities;
using PMA.Store_Domain.Categories.Queries;
using PMA.Store_Domain.Categories.Repositories.Interface;
using PMA.Store_Framework.Queries;

namespace PMA.Store_ApplicationServices.Categories.Queries
{
    public class AllCategoryQueryHandler : IQueryHandler<AllCategoryQuery, List<Category>>
    {
        private readonly ICategoryQueryRepository repository;

        public AllCategoryQueryHandler(ICategoryQueryRepository repository)
        {
            this.repository = repository;
        }

        public List<Category> Handle(AllCategoryQuery query)
        {
            return repository.GetAll();
        }

        public async Task<List<Category>> HandleAsync(AllCategoryQuery query)
        {
            return await repository.GetAllAsync();
        }
    }
}
