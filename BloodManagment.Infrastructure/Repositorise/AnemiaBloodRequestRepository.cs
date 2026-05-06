using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByPatientId;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByStatu;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestsByBloodGroup;
using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using Microsoft.EntityFrameworkCore;


namespace BloodManagment.Infrastructure.Repositorise
{
    public class AnemiaBloodRequestRepository : GenericRepository<AnemiaBloodRequest>, IAnemiaBloodRequestRepository
    {
        private readonly ApplicationContext context;
        DbSet<AnemiaBloodRequest> _dbSet;
        public AnemiaBloodRequestRepository(ApplicationContext context) : base(context)
        {
            this.context = context;
            this._dbSet = context.Set<AnemiaBloodRequest>();
        }


        public async Task<AnemiaBloodRequest?> GetByIdAsync(int id)
        {
            return await _dbSet
               
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<AnemiaBloodRequest?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Patient)
               
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IList<AnemiaBloodRequest>> GetAllAsync()
        {
            return await _dbset.ToListAsync();

        }

        public async Task<IList<AnemiaBloodRequest>> GetByBloodGroupAsync(BloodGroup bloodGroup)
        {
            return await ApplaySpacedication(new GetAnemiaBloodRequestByBloodGroupSpc(bloodGroup)).ToListAsync();
        }

        public async Task<IList<AnemiaBloodRequest>> GetByStatusAsync(RequestStatus status)
        {
            return await ApplaySpacedication(new GetAnemiaBloodRequestByStatuSpc(status)).ToListAsync();
        }

        public async Task<IList<AnemiaBloodRequest>> GetByPatientIdAsync(int userID)
        {
            return await ApplaySpacedication(new GetAnemiaBloodRequestByPatientIdSpc(userID)).ToListAsync();
        }
        public async Task<List<AnemiaBloodRequest>> GetByUserIdAsync(string userId)
        {
            return await _dbSet
                .Include(abr => abr.Patient)  // Assuming Patient has a UserId property
                .Where(abr => abr.Patient.UserId == userId)  // Filter by Patient's UserId
                .ToListAsync();
        }
        public async Task<int> GetCountByPationIdAsync(int pationId)
        {
            return await _dbset.CountAsync(r => r.PatientId == pationId);
        }
    }

}
