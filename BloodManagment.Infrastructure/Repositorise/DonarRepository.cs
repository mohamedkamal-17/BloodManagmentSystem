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
        DbSet<Donar> _donars;
        public DonarRepository(ApplicationContext context) : base(context)
        {
            _donars = context.Set<Donar>();
        }

        public async Task<Donar?> GetByUserIdAsync(string userId)
        {
            return await ApplaySpacedication(new GetByUserISpec(userId)).FirstOrDefaultAsync();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Donar>> GetTopDonarAsync()
        {
            return await _donars
           .OrderByDescending(d => d.DonationCount)
           .Take(5)
           .ToListAsync();
        }
    }
}

