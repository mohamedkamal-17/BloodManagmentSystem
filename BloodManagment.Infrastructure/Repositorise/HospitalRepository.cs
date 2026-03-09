using BloodManagment.Application.features.Hospitalfeat.Queries.GetHospitalById;
using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using Microsoft.EntityFrameworkCore;


namespace BloodManagment.Infrastructure.Repositorise
{
    public class HospitalRepository : GenericRepository<Hospital>, IHospitalRepository
    {
        private readonly ApplicationContext context;
        private DbSet<Hospital> _dbset;
        public HospitalRepository(ApplicationContext context) : base(context)
        {
            this.context = context;
            this._dbset = context.Set<Hospital>();
        }

        public async Task<IList<Hospital>> GetAllAsync()
        {
            return await _dbset.AsNoTracking().ToListAsync();
        }

        public async Task<Hospital> GetByIdAsync(int id)
        {
            return await ApplaySpacedication(new GetHospitalByIdSpec(id)).FirstOrDefaultAsync();
        }
    }
}
