using BloodManagment.domain.Contracts.Repositorise;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestsByUserIdQuery
{

    public class GetBloodRequestsByUserIdQueryHandler : IRequestHandler<GetBloodRequestsByUserIdQuery, List<BloodRequestDto>>
    {
        private readonly IBloodRequestRepository _bloodRequestRepository;

        public GetBloodRequestsByUserIdQueryHandler(IBloodRequestRepository bloodRequestRepository)
        {
            _bloodRequestRepository = bloodRequestRepository;
        }

        public async Task<List<BloodRequestDto>> Handle(GetBloodRequestsByUserIdQuery request, CancellationToken cancellationToken)
        {
            // Fetch BloodRequests by RescipientId where the Rescipient UserId matches the given UserId
            var bloodRequests = await _bloodRequestRepository.GetByUserIdAsync(request.UserId);

            var bloodRequestDtos = new List<BloodRequestDto>();

            foreach (var bloodRequest in bloodRequests)
            {
                bloodRequestDtos.Add(new BloodRequestDto
                {
                    Id = bloodRequest.Id,
                    RequestCode = bloodRequest.RequestCode,
                    RequestDate = bloodRequest.RequestDate,
                    HospitalName = bloodRequest.Hospital.Name, // Assuming Hospital has Name property
                    IsEmergency = bloodRequest.IsEmergency,
                    Reason = bloodRequest.Reason,
                    RescipientId = bloodRequest.RescipientId,
                    BloodGroup = bloodRequest.BloodGroup,
                    Status = bloodRequest.Status
                });
            }

            return bloodRequestDtos;
        }
    }

    }
