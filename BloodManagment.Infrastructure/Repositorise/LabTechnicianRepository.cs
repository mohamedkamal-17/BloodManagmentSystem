using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using Microsoft.EntityFrameworkCore;

namespace BloodManagment.Infrastructure.Repositorise
{
    public class LabTechnicianRepository : GenericRepository<LabTechnician>, ILabTechnicianRepository
    {
        private readonly ApplicationContext context;
        private DbSet<LabTechnician> _dbSet;
        public LabTechnicianRepository(ApplicationContext context) : base(context)
        {
            this.context = context;
            this._dbSet = context.Set<LabTechnician>();
        }

        public async Task<IList<LabTechnician>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public Task<IList<LabTechnician>> GetByBloodGroupAsync(BloodGroup bloodGroup)
        {
            throw new NotImplementedException();
        }

        public Task<LabTechnician> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<LabTechnician>> GetByUserIdAsync(string userID)
        {
            throw new NotImplementedException();
        }
    }
}
