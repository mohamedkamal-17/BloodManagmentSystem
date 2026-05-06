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

          public async Task<Rescipient?> GetByIdAsync(int id)
        {
            return await DbSet.Include(r => r.User)

                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Rescipient?> GetByUserIdAsync(string userID)
        {
            return await DbSet.Include(r => r.User)

                 .FirstOrDefaultAsync(r => r.UserId == userID);
        }

       
    }
}
