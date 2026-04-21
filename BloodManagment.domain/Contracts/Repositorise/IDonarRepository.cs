using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IDonarRepository : IGenericRepository<Donar>
    {
        Task<Donar?> GetByUserIdAsync(string userId);
        Task<Donar?> GetByIdAsync(int userId);

        Task<List<Donar>> GetTopDonarAsync();
        Task<int> GetCountAsync();
        Task<IReadOnlyList<Donar>> GetAllAsync();

    }
}
