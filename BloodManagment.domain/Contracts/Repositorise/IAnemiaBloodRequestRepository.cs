using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IAnemiaBloodRequestRepository : IGenericRepository<AnemiaBloodRequest>
    {

        Task<AnemiaBloodRequest?> GetByIdAsync(int id);

        Task<IList<AnemiaBloodRequest>> GetAllAsync();
        Task<IList<AnemiaBloodRequest>> GetByBloodGroupAsync(BloodGroup bloodGroup);
        Task<IList<AnemiaBloodRequest>> GetByPatientIdAsync(int userID);
        Task<IList<AnemiaBloodRequest>> GetByStatusAsync(RequestStatus status);
        Task<List<AnemiaBloodRequest>> GetByUserIdAsync(string userId);
        Task <int>  GetCountByPationIdAsync(int pationId);
        



    }
}
