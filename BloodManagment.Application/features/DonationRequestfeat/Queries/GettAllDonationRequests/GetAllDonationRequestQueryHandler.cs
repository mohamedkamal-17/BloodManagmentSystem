using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GettAllDonationRequests
{
    public class GetAllDonationRequestQueryHandler : IRequestHandler<GetAllDonationRequestQuery, ReadOnlyCollection<GetAllDonationRequestDto>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetAllDonationRequestQueryHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }

        public async Task<ReadOnlyCollection<GetAllDonationRequestDto>> Handle(GetAllDonationRequestQuery request, CancellationToken cancellationToken)
        {
            var requests = await unitOfWorke.BloodInventoryRepository.GetAllAsync();
            return mapper.Map<ReadOnlyCollection<GetAllDonationRequestDto>>(requests);

        }
    }
}
