using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetPendingDonationRequestByDonor
{
    public class PendingDonationRequestByDonorQueryHandler : IRequestHandler<PendingDonationRequestByDonorQuery, DonationRequestDto>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public PendingDonationRequestByDonorQueryHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public async Task<DonationRequestDto> Handle(PendingDonationRequestByDonorQuery request, CancellationToken cancellationToken)
        {
            var pandingRequest = await unitOfWorke.DonationRequestRepository.GetPendingDonationRequestByDonor(request.DonorId);

            return mapper.Map<DonationRequestDto>(pandingRequest);

        }
    }
}
