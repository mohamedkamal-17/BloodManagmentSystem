
using BloodManagment.Application.features.PasswordResetOtp.Queries.GetByUserId;
using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using System.Data.Entity;

namespace BloodManagment.Infrastructure.Repositorise
{
    public class PasswordResetOtpRepository : GenericRepository<PasswordResetOtp>, IPasswordResetOtpRepository
    {
        public PasswordResetOtpRepository(ApplicationContext context) : base(context)
        {


        }

        public async Task<PasswordResetOtp?> GetByUserIdAsync(string userId)
        {
            return await ApplaySpacedication(new GetByUserIdSpec(userId)).FirstOrDefaultAsync();
        }
    }
}
