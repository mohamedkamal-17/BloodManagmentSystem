using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Commandes.ApproveAnemiaRequest
{
    public class ApproveAnemiaRequestHandler
     : IRequestHandler<ApproveAnemiaRequestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApproveAnemiaRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

     

        async Task IRequestHandler<ApproveAnemiaRequestCommand>.Handle(ApproveAnemiaRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
            .AnemiaBloodRequestRepository
            .GetByIdAsync(request.Id);

            if (entity == null)
                throw new Exception("Request not found");

            if (entity.Status != RequestStatus.Pending)
                throw new Exception("Only pending requests can be approved");

            entity.Status = RequestStatus.Approved;

            await _unitOfWork.SaveChangesAsync();

           
        }
    }
}
