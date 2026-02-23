using BloodManagment.Application.Commane;
using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositorise;

namespace BloodManagment.Infrastructure.Comman
{
    public class UnitOfworke : IUnitOfWork

    {
        private ApplicationContext context;
        private IBloodRequestRepository? bloodRequestRepository;
        private IAnemiaBloodRequestRepository? anemiaBloodRequestRepository;
        private IDonationRequestRepository? donationRequestRepository;
        private IBloodInventoryRepository? bloodInventoryRepository;
        private IPasswordResetOtpRepository? passwordResetOtpRepository;
        private IDonarRepository? donarRepository;

        private IHealthConditionRepository healthConditionRepository;

        private IHospitalRepository hospitalRepository;

        private ThalassemiaPatientRepository thalassemiaPatientRepository;


        public UnitOfworke(ApplicationContext context)
        {
            this.context = context;
        }

        public IBloodRequestRepository BloodRequestRepository =>
            bloodRequestRepository ??= new BloodRequestRepository(context);

        public IAnemiaBloodRequestRepository AnemiaBloodRequestRepository =>
             anemiaBloodRequestRepository ??= new AnemiaBloodRequestRepository(context);

        public IBloodInventoryRepository BloodInventoryRepository =>
            bloodInventoryRepository ??= new BloodInventoryRepository(context);

        public IDonationRequestRepository DonationRequestRepository =>
            donationRequestRepository ??= new DonationRequestRepository(context);

        public IPasswordResetOtpRepository PasswordResetOtpRepository =>
            passwordResetOtpRepository ??= new PasswordResetOtpRepository(context);

        public IDonarRepository DonarRepository =>
            donarRepository ??= new DonarRepository(context);
        public IHealthConditionRepository HealthConditionRepository =>
            healthConditionRepository ??= new HealthConditionRepository(context);

        public IHospitalRepository HospitalRepository =>
            hospitalRepository ??= new HospitalRepository(context);

        public IThalassemiaPatientRepository ThalassemiaPatientRepository =>
            thalassemiaPatientRepository ??= new ThalassemiaPatientRepository(context);

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
