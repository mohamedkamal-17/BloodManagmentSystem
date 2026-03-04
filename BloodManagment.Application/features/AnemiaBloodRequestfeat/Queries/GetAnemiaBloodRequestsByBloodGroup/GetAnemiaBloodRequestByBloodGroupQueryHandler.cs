using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestsByBloodGroup
{
    public class GetAnemiaBloodRequestByBloodGroupQueryHandler : IRequestHandler<GetAnemiaBloodRequestByBloodGroupQuery, ReadOnlyCollection<GetAnemiaBloodRequestByBloodGroupDto>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetAnemiaBloodRequestByBloodGroupQueryHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public async Task<ReadOnlyCollection<GetAnemiaBloodRequestByBloodGroupDto>> Handle(GetAnemiaBloodRequestByBloodGroupQuery request, CancellationToken cancellationToken)
        {
            var AnemiaBloodRequests = await unitOfWorke.AnemiaBloodRequestRepository.GetByBloodGroupAsync(request.BloodGroup);
            return mapper.Map<ReadOnlyCollection<GetAnemiaBloodRequestByBloodGroupDto>>(AnemiaBloodRequests);
        }
    }
}
