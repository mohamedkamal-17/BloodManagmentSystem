using BloodManagment.Application.Commane;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.Rescipientfeat.Queries.GetRescipientByUserId
{
    public class GetRecipientByUserIdHandler : IRequestHandler<GetRecipientByUserIdQuery, RecipientDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecipientByUserIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RecipientDto> Handle(
            GetRecipientByUserIdQuery request,
            CancellationToken cancellationToken)
        {
            var rescipient = await _unitOfWork.RecipientRepository.GetByUserIdAsync(request.UserId);

            if (rescipient == null)
                return null;
            int BloodrequestesCount = _unitOfWork.BloodRequestRepository.GetCountByRecipiantIDAsync(rescipient.Id).Result;

            return new RecipientDto
            {
                Id = rescipient.Id,
                FullName = rescipient.FullName,
                RecipientCode = rescipient.RescipientCode,
                Gender = rescipient.Gender,
                UserId = rescipient.UserId,
                BloodrequestesCount = BloodrequestesCount
            };
        }
    }
}