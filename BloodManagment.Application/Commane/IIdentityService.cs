using BloodManagment.domain.Entities;

namespace BloodManagment.Application.Commane
{
    public interface IIdentityService
    {
        public Task<string> CreateToken(ApplicationUser user);
    }
}
