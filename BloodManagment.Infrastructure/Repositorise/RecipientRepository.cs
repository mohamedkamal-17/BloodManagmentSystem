using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using Microsoft.EntityFrameworkCore;

namespace BloodManagment.Infrastructure.Repositorise
{
    public class RecipientRepository : GenericRepository<Rescipient>, IRecipientRepository
    {
        private readonly ApplicationContext context;
        private DbSet<Rescipient> DbSet;

        public RecipientRepository(ApplicationContext context) : base(context)
        {
            this.context = context;
            this.DbSet = context.Set<Rescipient>();
        }
        public async Task<IList<Rescipient>> GetAllAsync()
        {
            return await DbSet
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<IList<Rescipient>> GetByBloodGroupAsync(BloodGroup bloodGroup)
        {
            throw new NotImplementedException();
        }

        public Task<Rescipient> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Rescipient>> GetByUserIdAsync(string userID)
        {
            throw new NotImplementedException();
        }
    }
}
