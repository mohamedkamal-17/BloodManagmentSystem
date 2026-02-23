using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using Microsoft.EntityFrameworkCore;

namespace BloodManagment.Infrastructure.Repositorise
{
    public class BloodInventoryRepository : GenericRepository<BloodInventory>, IBloodInventoryRepository
    {
        DbSet<BloodInventory> _dbSet;
        public BloodInventoryRepository(ApplicationContext context) : base(context)
        {
            _dbSet = context.Set<BloodInventory>();
        }

        public async Task<IList<BloodInventory>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }


    }
}
