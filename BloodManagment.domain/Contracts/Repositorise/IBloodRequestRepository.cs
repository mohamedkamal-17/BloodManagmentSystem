using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IBloodRequestRepository : IGenericRepository<BloodRequest>
    {
        Task<IList<BloodRequest>> GetAllAsync();
        Task<List<BloodRequest>> GetUrgentRequests();
        Task<int> GetCountAsync();
        Task<IList<BloodRequest>> GetByStatusAsync(RequestStatus status);
        Task<BloodRequest?> GetByHospitalsync(int hospitalId);
        Task<BloodRequest?> GetByIdAsync(int hospitalId);

        Task<IList<BloodRequest>> GetByUserIdAsync(int userID);

        Task<IList<BloodRequest>> GetByBloodGroupAsync(BloodGroup bloodGroup);




    }
}
