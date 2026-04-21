using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByStatu;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByUserId;
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
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<AnemiaBloodRequest?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Patient)
                .AsNoTracking()
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

        public async Task<IList<AnemiaBloodRequest>> GetByUserIdAsync(int userID)
        {
            return await ApplaySpacedication(new GetAnemiaBloodRequestByUserIdSpc(userID)).ToListAsync();
        }
    }

}
