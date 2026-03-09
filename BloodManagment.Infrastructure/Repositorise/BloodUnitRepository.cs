using BloodManagment.Application.features.BloodUnitfeat.Queries.GetAllBloodUnits;
using BloodManagment.Application.features.BloodUnitfeat.Queries.GetAvailableBloodUnits;
using BloodManagment.Application.features.BloodUnitfeat.Queries.GetBloodUnitsByBloodGroup;
using BloodManagment.Application.features.BloodUnitfeat.Queries.GetBloodUnitsByInventoryId;
using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using Microsoft.EntityFrameworkCore;

namespace BloodManagment.Infrastructure.Repositorise
{
    public class BloodUnitRepository : GenericRepository<BloodUnit>, IBloodUnitRepository
    {
        private DbSet<BloodUnit> _dbSet;
        public BloodUnitRepository(ApplicationContext context) : base(context)
        {
            _dbSet = context.Set<BloodUnit>();
        }
        public async Task<int> GetCountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<IReadOnlyList<BloodUnit>> GetAllAsync()
        {
            var spec = new GetAllBloodUnitsSpec();

            return await ApplaySpacedication(spec).ToListAsync();
        }

        public async Task<BloodUnit?> GetByIdAsync(int id)
        {
            var spec = new GetBloodUnitByIdSpec(id);

            return await ApplaySpacedication(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<BloodUnit>> GetByBloodGroupAsync(BloodGroup bloodGroup)
        {
            var spec = new GetBloodUnitsByBloodGroupSpec(bloodGroup);

            return await ApplaySpacedication(spec).ToListAsync();
        }

        public async Task<IReadOnlyList<BloodUnit>> GetAvailableUnitsAsync()
        {
            var spec = new GetAvailableBloodUnitsSpec();

            return await ApplaySpacedication(spec).ToListAsync();
        }

        public async Task<IReadOnlyList<BloodUnit>> GetByInventoryIdAsync(int inventoryId)
        {
            var spec = new GetBloodUnitsByInventoryIdSpec(inventoryId);

            return await ApplaySpacedication(spec).ToListAsync();
        }
    }
}
