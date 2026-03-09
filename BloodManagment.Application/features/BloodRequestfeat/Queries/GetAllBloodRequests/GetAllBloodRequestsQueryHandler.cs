using AutoMapper;
using BloodManagment.Application.Commane;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetAllBloodRequests;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetAllBolodRequests
{
    public class GetAllBloodRequestsQueryHandler : IRequestHandler<GetAllBloodRequestsQuery, ReadOnlyCollection<BloodRequestDto>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;


        public GetAllBloodRequestsQueryHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {

            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }

        public async Task<ReadOnlyCollection<BloodRequestDto>> Handle(GetAllBloodRequestsQuery request,
            CancellationToken cancellationToken)
        {

            var bloodRequests = await unitOfWorke.BloodRequestRepository.GetAllAsync();
            return mapper.Map<ReadOnlyCollection<BloodRequestDto>>(bloodRequests);
        }


    }
}
