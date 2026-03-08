using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IBloodUnitRepository : IGenericRepository<BloodUnit>
    {
        Task<IReadOnlyList<BloodUnit>> GetAllAsync();

        Task<BloodUnit?> GetByIdAsync(int id);

        Task<IReadOnlyList<BloodUnit>> GetByBloodGroupAsync(BloodGroup bloodGroup);

        Task<IReadOnlyList<BloodUnit>> GetAvailableUnitsAsync();

        Task<IReadOnlyList<BloodUnit>> GetByInventoryIdAsync(int inventoryId);
        Task<int> GetCountAsync();
    }
}
