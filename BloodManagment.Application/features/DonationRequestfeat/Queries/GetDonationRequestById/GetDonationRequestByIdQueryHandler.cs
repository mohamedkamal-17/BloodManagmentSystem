using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestById
{
    public class GetDonationRequestByIdQueryHandler : IRequestHandler<GetDonationRequestByIdQuery, GetDonationRequestByIdDto>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetDonationRequestByIdQueryHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }

        public async Task<GetDonationRequestByIdDto> Handle(GetDonationRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var req = await unitOfWorke.DonationRequestRepository.GetByIdAsync(request.Id);
            return mapper.Map<GetDonationRequestByIdDto>(req);
        }
    }
}
