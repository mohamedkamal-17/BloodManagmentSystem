using BloodManagment.Application.features.BloodRequestfeat.Queries.GetAllBloodRequests;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestDetails;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestesByBloodStatu;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetByBloodGroup;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetByUserId;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetUrgentRequests;
using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using Microsoft.EntityFrameworkCore;

namespace BloodManagment.Infrastructure.Repositorise
{
    public class BloodRequestRepository : GenericRepository<BloodRequest>, IBloodRequestRepository
    {
        DbSet<BloodRequest> _dbSet;
        public BloodRequestRepository(ApplicationContext context) : base(context)
        {
            _dbSet = context.Set<BloodRequest>();

        }



        public async Task<IList<BloodRequest>> GetAllAsync()
        {
            return await ApplaySpacedication(new GetAllBloodRequestsQuerySpec()).ToListAsync();
        }

        public async Task<IList<BloodRequest>> GetByBloodGroupAsync(BloodGroup bloodGroup)
        {
            return await ApplaySpacedication(new GetByBloodGroupSpc(bloodGroup)).ToListAsync();
        }

        public Task<BloodRequest?> GetByHospitalsync(int hospitalId)
        {
            throw new NotImplementedException();
        }

        public async Task<BloodRequest?> GetByIdAsync(int id)
        {
            return await ApplaySpacedication(new GetBloodRequestDetailsSpec(id)).FirstOrDefaultAsync();
        }

        public async Task<IList<BloodRequest>> GetByStatusAsync(RequestStatus status)
        {
            return await ApplaySpacedication(new GetBloodRequestesByStatuSpc(status)).ToListAsync();
        }

        public async Task<IList<BloodRequest>> GetByUserIdAsync(int userID)
        {
            return await ApplaySpacedication(new GetByUserIdSpec(userID)).ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbset.CountAsync();
        }

        public async Task<List<BloodRequest>> GetUrgentRequests()
        {
            return await ApplaySpacedication(new GetUrgentBloodRequestsSpec()).ToListAsync();
        }
    }


}
