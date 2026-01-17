using BloodManagment.domain.Contracts.Repositorise;

namespace BloodManagment.Application.Commane
{
    public interface IUnitOfWorke : IDisposable
    {
        IBloodRequestRepository BloodRequestRepository { get; }
        IAnemiaBloodRequestRepository AnemiaBloodRequestRepository { get; }
        IBloodInventoryRepository BloodInventoryRepository { get; }
        IDonationRequestRepository DonationRequestRepository { get; }
        Task<int> SaveChangesAsync();


    }
}
