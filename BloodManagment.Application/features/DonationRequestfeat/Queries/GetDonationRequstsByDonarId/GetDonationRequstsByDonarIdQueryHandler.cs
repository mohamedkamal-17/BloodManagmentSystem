using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequstsByDonarId
{
    public class GetDonationRequstsByDonarIdQueryHandler : IRequestHandler<GetDonationRequstsByDonarIdQuery, ReadOnlyCollection<DonationRequestDto>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetDonationRequstsByDonarIdQueryHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public async Task<ReadOnlyCollection<DonationRequestDto>> Handle(GetDonationRequstsByDonarIdQuery request, CancellationToken cancellationToken)
        {
            var donationRequests = await unitOfWorke.DonationRequestRepository.GetByDonarIdAsync(request.UserId);
              

            // Map the entities to DTOs
            var donationRequestsDto = mapper.Map<List<DonationRequestDto>>(donationRequests);

            // Return as ReadOnlyCollection
            return new ReadOnlyCollection<DonationRequestDto>(donationRequestsDto);
        }
    }
}
