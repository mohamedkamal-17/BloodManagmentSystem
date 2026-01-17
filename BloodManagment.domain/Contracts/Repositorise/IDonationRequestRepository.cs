using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IDonationRequestRepository : IGenirecRepo<DonationRequest>
    {
        Task<DonationRequest> GetByIdAsync(int id);
        Task<IList<DonationRequest>> GetAllAsync();

        Task<IList<DonationRequest>> GetByUserIdAsync(int userID);

        Task<IList<DonationRequest>> GetByStatusAsync(RequestStatus status);

    }
}
