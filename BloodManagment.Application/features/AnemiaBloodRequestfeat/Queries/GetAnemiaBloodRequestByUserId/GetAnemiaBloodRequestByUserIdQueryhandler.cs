using BloodManagment.domain.Contracts.Repositorise;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByUserId
{
    public class GetAnemiaBloodRequestByUserIdQueryHandler : IRequestHandler<GetAnemiaBloodRequestByUserIdQuery, List<GetAnemiaBloodRequestByUserIdDto>>
    {
        private readonly IAnemiaBloodRequestRepository _anemiaBloodRequestRepository;

        public GetAnemiaBloodRequestByUserIdQueryHandler(IAnemiaBloodRequestRepository anemiaBloodRequestRepository)
        {
            _anemiaBloodRequestRepository = anemiaBloodRequestRepository;
        }

        public async Task<List<GetAnemiaBloodRequestByUserIdDto>> Handle(GetAnemiaBloodRequestByUserIdQuery request, CancellationToken cancellationToken)
        {
            var anemiaBloodRequests = await _anemiaBloodRequestRepository.GetByUserIdAsync(request.UserId);

            var anemiaBloodRequestDtos = new List<GetAnemiaBloodRequestByUserIdDto>();

            foreach (var anemiaBloodRequest in anemiaBloodRequests)
            {
                anemiaBloodRequestDtos.Add(new GetAnemiaBloodRequestByUserIdDto
                {
                    RequestCode = anemiaBloodRequest.RequestCode,
                    RequestDate = anemiaBloodRequest.RequestDate,
                    BloodGroup = anemiaBloodRequest.BloodGroup,
                    Status = anemiaBloodRequest.Status,
                    ResponsibleEntity = anemiaBloodRequest.ResponsibleEntity,
                    AttendanceDate = anemiaBloodRequest.AttendanceDate,
                    BloodTestDate = anemiaBloodRequest.BloodTestDate,
                    LastTransfusionDate = anemiaBloodRequest.LastTransfusionDate,
                    HemoglobinLevel = anemiaBloodRequest.HemoglobinLevel,
                    BloodTestIssuer = anemiaBloodRequest.BloodTestIssuer,
                    PatientId = anemiaBloodRequest.PatientId


                });
            }

            return anemiaBloodRequestDtos;
        }
    }
}

