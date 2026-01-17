using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByStatu
{
    public class GetAnemiaBloodRequestByStatuQueryHandler : IRequestHandler<GetAnemiaBloodRequestByStatuQuery, ReadOnlyCollection<GetAnemiaBloodRequestByStatuDto>>
    {
        private readonly IUnitOfWorke unitOfWorke;
        private readonly Mapper mapper;

        public GetAnemiaBloodRequestByStatuQueryHandler(IUnitOfWorke unitOfWorke, Mapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public async Task<ReadOnlyCollection<GetAnemiaBloodRequestByStatuDto>> Handle(GetAnemiaBloodRequestByStatuQuery request, CancellationToken cancellationToken)
        {
            var AnemiaBloodRequests = await unitOfWorke.AnemiaBloodRequestRepository.GetByStatusAsync(request.Status);
            return mapper.Map<ReadOnlyCollection<GetAnemiaBloodRequestByStatuDto>>(AnemiaBloodRequests);
        }
    }
}
