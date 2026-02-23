using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IBloodInventoryRepository : IGenericRepository<BloodInventory>
    {
        Task<IList<BloodInventory>> GetAllAsync();
    }
}
