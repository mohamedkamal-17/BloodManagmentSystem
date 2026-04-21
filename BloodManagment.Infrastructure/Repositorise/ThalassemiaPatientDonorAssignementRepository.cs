using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.DataHelper;
using BloodManagment.Infrastructure.Repositoris;
using Microsoft.EntityFrameworkCore;

namespace BloodManagment.Infrastructure.Repositorise
{

    public class ThalassemiaPatientDonorAssignementRepository
        : GenericRepository<ThalassemiaPatientDonorAssignement>, IThalassemiaPatientDonorAssignementRepository
    {
        private readonly ApplicationContext _context;

        public ThalassemiaPatientDonorAssignementRepository(ApplicationContext context) : base(context)
        {
            _context = context;

        }

        public async Task AddAsync(ThalassemiaPatientDonorAssignement entity)
            => await _context.Set<ThalassemiaPatientDonorAssignement>().AddAsync(entity);

        public void DeleteAsync(ThalassemiaPatientDonorAssignement entity)
            => _context.Set<ThalassemiaPatientDonorAssignement>().Remove(entity);

        public void UpdateAsync(ThalassemiaPatientDonorAssignement entity)
            => _context.Set<ThalassemiaPatientDonorAssignement>().Update(entity);

        public async Task<bool> ExistsAsync(int patientId, int donorId)
        {
            return await _context.Set<ThalassemiaPatientDonorAssignement>()
                .AnyAsync(x =>
                    x.ThalassemiaPatientId == patientId &&
                    x.DonarId == donorId);
        }


    }
}
