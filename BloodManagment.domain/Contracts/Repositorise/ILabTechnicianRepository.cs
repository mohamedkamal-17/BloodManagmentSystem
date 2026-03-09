using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface ILabTechnicianRepository : IGenericRepository<LabTechnician>
    {
        Task<LabTechnician> GetByIdAsync(int id);
        Task<IList<LabTechnician>> GetAllAsync();
        Task<IList<LabTechnician>> GetByBloodGroupAsync(BloodGroup bloodGroup);
        Task<IList<LabTechnician>> GetByUserIdAsync(string userID);
    }
}
