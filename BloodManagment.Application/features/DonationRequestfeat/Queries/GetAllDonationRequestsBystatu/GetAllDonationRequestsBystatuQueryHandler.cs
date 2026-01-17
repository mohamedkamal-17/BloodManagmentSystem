using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetAllDonationRequestsBystatu
{
    public class GetAllDonationRequestsBystatuQueryHandler : IRequestHandler<GetAllDonationRequestsBystatuQuery, ReadOnlyCollection<GetAllDonationRequestsBystatuDto>>
    {
        private readonly IUnitOfWorke unitOfWorke;
        private readonly IMapper mapper;

        public GetAllDonationRequestsBystatuQueryHandler(IUnitOfWorke unitOfWorke, IMapper mapper)
        {

            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public async Task<ReadOnlyCollection<GetAllDonationRequestsBystatuDto>> Handle(GetAllDonationRequestsBystatuQuery request, CancellationToken cancellationToken)
        {
            var reqs = await unitOfWorke.DonationRequestRepository.GetByStatusAsync(request.Statu);
            return mapper.Map<ReadOnlyCollection<GetAllDonationRequestsBystatuDto>>(reqs);
        }
    }
}
