using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Commandes.RejectAnemiaRequest
{
    public class RejectAnemiaRequestHandler
     : IRequestHandler<RejectAnemiaRequestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RejectAnemiaRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        

        async Task IRequestHandler<RejectAnemiaRequestCommand>.Handle(RejectAnemiaRequestCommand request, CancellationToken cancellationToken)
        {

            var entity = await _unitOfWork
                .AnemiaBloodRequestRepository
                .GetByIdAsync(request.Id);

            if (entity == null)
                throw new Exception("Request not found");

            entity.Status = RequestStatus.Rejected;

            await _unitOfWork.SaveChangesAsync();

           
        }
    }
}
