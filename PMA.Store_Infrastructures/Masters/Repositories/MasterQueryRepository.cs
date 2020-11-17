using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMA.Store_Domain.Masters.Entities;
using PMA.Store_Domain.Masters.Repositories.Interface;

namespace PMA.Store_Infrastructures.Masters.Repositories
{
    public class MasterQueryRepository : IMasterQueryRepository
    {
        private readonly StoreDbContext _dbContext;

        public MasterQueryRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Master> GetAll()
        {
            return _dbContext.Masters.AsNoTracking().Include(c => c.Photo).ToList();
        }

        public async Task<List<Master>> GetAllAsync()
        {
            return await _dbContext.Masters.AsNoTracking().Include(c => c.Photo).ToListAsync();
        }
    }
}
