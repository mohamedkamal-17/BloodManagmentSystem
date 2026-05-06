using BloodManagment.Application.Commane;
using BloodManagment.domain.Contracts.Repositorise;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.CheckThalassemiaPatientExistByUserId
{
    public class CheckThalassemiaPatientExistByUserIdQueryHandler : IRequestHandler<CheckThalassemiaPatientExistByUserIdQuery, bool>
    {
     
        private readonly IUnitOfWork unitOfWork;

        public CheckThalassemiaPatientExistByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
          
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckThalassemiaPatientExistByUserIdQuery request, CancellationToken cancellationToken)
        {
            // Call the repository method to check if ThalassemiaPatient exists by UserId
            var patient = await unitOfWork.ThalassemiaPatientRepository.GetByUserIdAsync(request.UserId);

            // If ThalassemiaPatient exists, return true; otherwise false
            return patient != null;
        }
    }
}
