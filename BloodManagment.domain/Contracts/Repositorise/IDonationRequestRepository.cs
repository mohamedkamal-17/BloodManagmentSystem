using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IDonationRequestRepository : IGenericRepository<DonationRequest>
    {
        Task<DonationRequest> GetByIdAsync(int id);
        Task<DonationRequest?> GetPendingDonationRequestByDonor(int donerId);
        Task<IList<DonationRequest>> GetAllAsync();

        Task<IList<DonationRequest>> GetByUserIdAsync(int userID);

        Task<IList<DonationRequest>> GetByStatusAsync(RequestStatus status);

    }
}
