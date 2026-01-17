using BloodManagment.Application.Commane;
using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositorise;

namespace BloodManagment.Infrastructure.Comman
{
    public class UnitOfworke : IUnitOfWorke

    {
        private ApplicationContext context;
        private IBloodRequestRepository? _bloodRequestRepository;
        private IAnemiaBloodRequestRepository? _anemiaBloodRequestRepository;
        private IDonationRequestRepository? _donationRequestRepository;
        private IBloodInventoryRepository? _bloodInventoryRepository;


        public UnitOfworke(ApplicationContext context)
        {
            this.context = context;
        }

        public IBloodRequestRepository BloodRequestRepository =>
            _bloodRequestRepository ??= new BloodRequestRepository(context);

        public IAnemiaBloodRequestRepository AnemiaBloodRequestRepository =>
             _anemiaBloodRequestRepository ??= new AnemiaBloodRequestRepository(context);

        public IBloodInventoryRepository BloodInventoryRepository =>
            _bloodInventoryRepository ??= new BloodInventoryRepository(context);

        public IDonationRequestRepository DonationRequestRepository =>
            _donationRequestRepository ??= new DonationRequestRepository(context);

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
