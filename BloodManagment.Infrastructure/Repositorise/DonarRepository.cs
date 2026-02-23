using BloodManagment.Application.features.Donarfeat.Queries.GetByUserId;
using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using Microsoft.EntityFrameworkCore;

namespace BloodManagment.Infrastructure.Repositorise
{
    public class DonarRepository : GenericRepository<Donar>, IDonarRepository
    {
        public DonarRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Donar?> GetByUserIdAsync(string userId)
        {
            return await ApplaySpacedication(new GetByUserISpec(userId)).FirstOrDefaultAsync();
        }
    }
}

