using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GettAllDonationRequests
{
    public class GetAllDonationRequestQueryHandler : IRequestHandler<GetAllDonationRequestQuery, List<DonationRequestDto>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetAllDonationRequestQueryHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }

        public async Task<List<DonationRequestDto>> Handle(GetAllDonationRequestQuery request, CancellationToken cancellationToken)
        {
            var requests = await unitOfWorke.DonationRequestRepository.GetAllAsync();
            return mapper.Map<List<DonationRequestDto>>(requests);

        }
    }
}
