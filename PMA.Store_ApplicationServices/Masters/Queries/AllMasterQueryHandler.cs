using System.Collections.Generic;
using System.Threading.Tasks;
using PMA.Store_Domain.Masters.Entities;
using PMA.Store_Domain.Masters.Queries;
using PMA.Store_Domain.Masters.Repositories.Interface;
using PMA.Store_Framework.Queries;

namespace PMA.Store_ApplicationServices.Masters.Queries
{
    public class AllMasterQueryHandler : IQueryHandler<AllMasterQuery, List<Master>>
    {
        private readonly IMasterQueryRepository _repository;

        public AllMasterQueryHandler(IMasterQueryRepository repository)
        {
            _repository = repository;
        }

        public List<Master> Handle(AllMasterQuery query)
        {
            return _repository.GetAll();
        }

        public async Task<List<Master>> HandleAsync(AllMasterQuery query)
        {
            return await _repository.GetAllAsync();

        }
    }
}
