using System.Collections.Generic;
using System.Threading.Tasks;
using PMA.Store_Domain.Masters.Entities;

namespace PMA.Store_Domain.Masters.Repositories.Interface
{
    public interface IMasterQueryRepository
    {
        List<Master> GetAll();
        Task<List<Master>> GetAllAsync();
    }
}