using BloodManagment.Application.features.DonationRequestfeat.Queries.GetAllDonationRequestsBystatu;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestById;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GettAllDonationRequests;
using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using Microsoft.EntityFrameworkCore;

namespace BloodManagment.Infrastructure.Repositorise
{
    public class DonationRequestRepository : GenirecRepo<DonationRequest>, IDonationRequestRepository
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

        public async Task<IList<DonationRequest>> GetByStatusAsync(RequestStatus status)
        {
            return await ApplaySpacedication(
                new GetAllDonationRequestsBystatuSpec(status)
                )
                 .AsNoTracking()
                .ToListAsync();
        }

        public Task<IList<DonationRequest>> GetByUserIdAsync(int userID)
        {
            throw new NotImplementedException();
        }
    }
}
