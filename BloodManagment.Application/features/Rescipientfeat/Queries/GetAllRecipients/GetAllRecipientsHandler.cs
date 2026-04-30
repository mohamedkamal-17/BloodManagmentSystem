using BloodManagment.Application.Commane;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.Rescipientfeat.Queries.GetAllRecipients
{
    public class GetAllRecipientsHandler
     : IRequestHandler<GetAllRecipientsQuery, IList<RecipientDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRecipientsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<RecipientDto>> Handle(
            GetAllRecipientsQuery request,
            CancellationToken cancellationToken)
        {
            var recipients = await _unitOfWork
                .RecipientRepository
                .GetAllAsync();

            return recipients.Select(r => new RecipientDto
            {
                Id = r.Id,
                RecipientCode = r.RescipientCode,
                FullName = r.FullName,
                Gender = r.Gender,
                BloodRequestsCount = r.BloodRequests.Count
            }).ToList();
        }
    }
}
