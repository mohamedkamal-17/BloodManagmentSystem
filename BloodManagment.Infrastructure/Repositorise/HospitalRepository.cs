using BloodManagment.Application.features.Hospitalfeat.Queries.GetHospitalById;
using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using System.Data.Entity;

namespace BloodManagment.Infrastructure.Repositorise
{
    public class HospitalRepository : GenericRepository<Hospital>, IHospitalRepository
    {
        private readonly ApplicationContext context;

        public HospitalRepository(ApplicationContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IList<Hospital>> GetAllAsync()
        {
            return await context.Hospitals.ToListAsync();
        }

        public async Task<Hospital> GetByIdAsync(int id)
        {
            return await ApplaySpacedication(new GetHospitalByIdSpec(id)).FirstOrDefaultAsync();
        }
    }
}
