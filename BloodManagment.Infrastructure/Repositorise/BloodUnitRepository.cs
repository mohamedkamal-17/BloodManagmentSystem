using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
