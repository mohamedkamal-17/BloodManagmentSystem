using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequstsByUserId
{
    public class GetDonationRequstsByUserIdQueryHandler : IRequestHandler<GetDonationRequstsByUserIdQuery, ReadOnlyCollection<GetDonationRequstsByUserIdDto>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetDonationRequstsByUserIdQueryHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public Task<ReadOnlyCollection<GetDonationRequstsByUserIdDto>> Handle(GetDonationRequstsByUserIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
