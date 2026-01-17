using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IAnemiaBloodRequestRepository : IGenirecRepo<AnemiaBloodRequest>
    {
        Task<IList<AnemiaBloodRequest>> GetAllAsync();
        Task<IList<AnemiaBloodRequest>> GetByBloodGroupAsync(BloodGroup bloodGroup);
        Task<IList<AnemiaBloodRequest>> GetByUserIdAsync(int userID);
        Task<IList<AnemiaBloodRequest>> GetByStatusAsync(RequestStatus status);



    }
}
