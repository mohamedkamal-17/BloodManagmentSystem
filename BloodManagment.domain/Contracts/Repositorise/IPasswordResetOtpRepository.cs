using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IPasswordResetOtpRepository : IGenericRepository<PasswordResetOtp>
    {

        Task<PasswordResetOtp?> GetByUserIdAsync(string userId);
    }
}
