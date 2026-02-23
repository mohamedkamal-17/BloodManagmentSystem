using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetAllDonationRequestsBystatu
{
    public class GetAllDonationRequestsBystatuQueryHandler : IRequestHandler<GetDonationRequestsByStatuQuery, ReadOnlyCollection<GetDonationRequestsByStatuDto>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetAllDonationRequestsBystatuQueryHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {

            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public async Task<ReadOnlyCollection<GetDonationRequestsByStatuDto>> Handle(GetDonationRequestsByStatuQuery request, CancellationToken cancellationToken)
        {
            var reqs = await unitOfWorke.DonationRequestRepository.GetByStatusAsync(request.Statu);
            return mapper.Map<ReadOnlyCollection<GetDonationRequestsByStatuDto>>(reqs);
        }
    }
}
