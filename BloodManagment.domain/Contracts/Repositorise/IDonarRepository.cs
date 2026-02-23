using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IDonarRepository : IGenericRepository<Donar>
    {
        Task<Donar?> GetByUserIdAsync(string userId);

    }
}
