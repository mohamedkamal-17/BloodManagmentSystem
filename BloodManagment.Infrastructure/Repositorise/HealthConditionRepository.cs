using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;

namespace BloodManagment.Infrastructure.Repositorise
{
    public class HealthConditionRepository : GenericRepository<HealthCondition>, IHealthConditionRepository
    {
        public HealthConditionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
