using System.Threading.Tasks;
using PMA.Store_Domain.Masters.Entities;

namespace PMA.Store_Domain.Masters.Repositories.Interface
{
    public interface IMasterCommandRepository
    {
        void Add(Master master);
        Task AddAsync(Master master);
        Task<int> SaveChangesAsync();
        int SaveChange();
    }
}