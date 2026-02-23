using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IHospitalRepository : IGenericRepository<Hospital>
    {
        Task<Hospital> GetByIdAsync(int id);
        Task<IList<Hospital>> GetAllAsync();
    }
}
