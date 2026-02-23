using BloodManagment.domain.Contracts.Repositorise;

namespace BloodManagment.Application.Commane
{
    public interface IUnitOfWork : IDisposable
    {
        IBloodRequestRepository BloodRequestRepository { get; }
        IAnemiaBloodRequestRepository AnemiaBloodRequestRepository { get; }
        IBloodInventoryRepository BloodInventoryRepository { get; }
        IDonationRequestRepository DonationRequestRepository { get; }
        IPasswordResetOtpRepository PasswordResetOtpRepository { get; }
        IDonarRepository DonarRepository { get; }
        IHospitalRepository HospitalRepository { get; }

        IHealthConditionRepository HealthConditionRepository { get; }
        IThalassemiaPatientRepository ThalassemiaPatientRepository { get; }
        Task<int> SaveChangesAsync();


    }
}
