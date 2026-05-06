using BloodManagment.Application.features.DonationRequestfeat.Queries.GetAllDonationRequestsBystatu;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestById;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequstsByDonarId;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetPendingDonationRequestByDonor;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GettAllDonationRequests;
using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using Microsoft.EntityFrameworkCore;


namespace BloodManagment.Infrastructure.Repositorise
{
    public class DonationRequestRepository : GenericRepository<DonationRequest>, IDonationRequestRepository
    {
        DbSet<DonationRequest> dbSet;
        public DonationRequestRepository(ApplicationContext context) : base(context)
        {
            this.dbSet = context.Set<DonationRequest>();
        }
        public async Task<IList<DonationRequest>> GetAllAsync()
        {
            return await ApplaySpacedication(
                new GetAllDonationRequestSpec()
                )
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<DonationRequest?> GetByIdAsync(int id)
        {

            return await ApplaySpacedication(new GetDonationRequestByIdSpec(id)).FirstOrDefaultAsync(); ;
        }

        public async Task<DonationRequest?> GetPendingDonationRequestByDonor(int donerId)
        {
            return await ApplaySpacedication(new GetPendingDonationRequestByDonorSpec(donerId)).FirstOrDefaultAsync();
        }


        public async Task<IList<DonationRequest>> GetByStatusAsync(RequestStatus status)
        {
            return await ApplaySpacedication(
                new GetDonationRequestsBystatuSpec(status)
                )
                 .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<DonationRequest>> GetByDonarIdAsync(int donarId)
        {
            return await ApplaySpacedication(
                new GetDonationRequstsByDonarIdSpec(donarId)
                )
                 .AsNoTracking()
                .ToListAsync();
        }
        public async Task<List<DonationRequest>> GetByUserIdAsync(string userId)
        {
            // Fetch the donation requests where the donar's UserId matches
            return await dbSet
                .Include(dr => dr.Donar) // Include the Donar navigation property
                .Where(dr => dr.Donar.UserId == userId)
                .ToListAsync();
        }

        public async Task<int> GetDonarRequestnumberByDonerId(int donarId)
        {
            return await dbSet.CountAsync(r => r.DonarId == donarId);
        }
    }
}
