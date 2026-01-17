using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IBloodInventoryRepository : IGenirecRepo<BloodInventory>
    {
        Task<IList<BloodInventory>> GetAllAsync();
    }
}
