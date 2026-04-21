using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IAnemiaBloodRequestRepository : IGenericRepository<AnemiaBloodRequest>
    {

        Task<AnemiaBloodRequest?> GetByIdAsync(int id);

        Task<IList<AnemiaBloodRequest>> GetAllAsync();
        Task<IList<AnemiaBloodRequest>> GetByBloodGroupAsync(BloodGroup bloodGroup);
        Task<IList<AnemiaBloodRequest>> GetByUserIdAsync(int userID);
        Task<IList<AnemiaBloodRequest>> GetByStatusAsync(RequestStatus status);



    }
}
