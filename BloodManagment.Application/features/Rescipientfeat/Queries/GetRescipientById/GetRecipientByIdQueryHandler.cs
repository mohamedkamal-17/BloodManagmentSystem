using BloodManagment.Application.Commane;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.Rescipientfeat.Queries.GetRescipientById
{
    public class GetRecipientByIdHandler
     : IRequestHandler<GetRecipientByIdQuery, RecipientDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecipientByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RecipientDto> Handle(
            GetRecipientByIdQuery request,
            CancellationToken cancellationToken)
        {
            var rescipient = await _unitOfWork.RecipientRepository.GetByIdAsync(request.Id);

            if (rescipient == null)
                return null;
            int numberOfRequestes = _unitOfWork.BloodRequestRepository.GetCountByRecipiantIDAsync(request.Id).Result;

            return new RecipientDto
            {
                Id = rescipient.Id,
                FullName = rescipient.FullName,
                RecipientCode = rescipient.RescipientCode,
                Gender = rescipient.Gender,
                UserId = rescipient.UserId,
                BloodrequestesCount= numberOfRequestes
            };
        }
    }
}
