using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.DonationRequestfeat.Commandes.AcceptDonationRequest
{
    public class AcceptDonationRequestHandler
     : IRequestHandler<AcceptDonationRequestCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AcceptDonationRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AcceptDonationRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.DonationRequestRepository
                .GetByIdAsync(request.Id);

            if (entity == null)
                return false;

            entity.Statu = RequestStatus.Accepted;

           
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
