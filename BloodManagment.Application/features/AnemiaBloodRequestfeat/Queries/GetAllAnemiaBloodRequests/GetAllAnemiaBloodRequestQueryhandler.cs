using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAllAnemiaBloodRequests
{
    public class GetAllAnemiaBloodRequestQueryhandler : IRequestHandler<GetAllAnemiaBloodRequestQuery, ReadOnlyCollection<GetAllAnemiaBloodRequestDto>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetAllAnemiaBloodRequestQueryhandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public async Task<ReadOnlyCollection<GetAllAnemiaBloodRequestDto>> Handle(GetAllAnemiaBloodRequestQuery request, CancellationToken cancellationToken)
        {
            var anemiaBloodRequests = await unitOfWorke.AnemiaBloodRequestRepository.GetAllAsync();
            return mapper.Map<ReadOnlyCollection<GetAllAnemiaBloodRequestDto>>(anemiaBloodRequests);

        }
    }
}
