using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IThalassemiaPatientRepository : IGenericRepository<ThalassemiaPatient>
    {

        Task<ThalassemiaPatient> GetByIdAsync(int id);
        Task<IList<ThalassemiaPatient>> GetAllAsync();
        Task<IList<ThalassemiaPatient>> GetByBloodGroupAsync(BloodGroup bloodGroup);
        Task<ThalassemiaPatient> GetByUserIdAsync(string userID);
    }
}
