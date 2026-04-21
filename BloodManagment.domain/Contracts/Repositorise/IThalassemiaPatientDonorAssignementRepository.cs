using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IThalassemiaPatientDonorAssignementRepository
    : IGenericRepository<ThalassemiaPatientDonorAssignement>
    {
        Task<bool> ExistsAsync(int patientId, int donorId);
    }

}
