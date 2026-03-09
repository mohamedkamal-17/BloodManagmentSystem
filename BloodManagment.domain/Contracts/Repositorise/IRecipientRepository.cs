using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IRecipientRepository : IGenericRepository<Rescipient>
    {
        Task<Rescipient> GetByIdAsync(int id);
        Task<IList<Rescipient>> GetAllAsync();
        Task<IList<Rescipient>> GetByBloodGroupAsync(BloodGroup bloodGroup);
        Task<IList<Rescipient>> GetByUserIdAsync(string userID);
    }
}
