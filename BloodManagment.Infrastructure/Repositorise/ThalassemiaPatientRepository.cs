using BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetAllThalassemiaPatients;
using BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientById;
using BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientByUserId;
using BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientsByBloodGroup;
using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using Microsoft.EntityFrameworkCore;

namespace BloodManagment.Infrastructure.Repositorise
{
    public class ThalassemiaPatientRepository : GenericRepository<ThalassemiaPatient>, IThalassemiaPatientRepository
    {
        private readonly ApplicationContext context;

        public ThalassemiaPatientRepository(ApplicationContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IList<ThalassemiaPatient>> GetAllAsync()
        {
            return await ApplaySpacedication(
                    new GetAllThalassemiaPatientsSpec())
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ThalassemiaPatient?> GetByIdAsync(int id)
        {
            return await ApplaySpacedication(
                    new GetThalassemiaPatientByIdSpec(id))
                .FirstOrDefaultAsync();
        }

        public async Task<IList<ThalassemiaPatient>>
            GetByBloodGroupAsync(BloodGroup bloodGroup)
        {
            return await ApplaySpacedication(
                    new GetThalassemiaPatientsByBloodGroupSpec(bloodGroup))
                .AsNoTracking()
                .ToListAsync();
        }



        public async Task<IList<ThalassemiaPatient>>
            GetByUserIdAsync(string userID)
        {
            return await ApplaySpacedication(
                    new GetThalassemiaPatientsByUserIdSpec(userID)).ToListAsync();
        }
    }
}
