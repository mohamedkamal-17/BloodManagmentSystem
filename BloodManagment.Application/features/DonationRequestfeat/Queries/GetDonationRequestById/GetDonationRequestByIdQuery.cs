using MediatR;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestById
{
    public class GetDonationRequestByIdQuery : IRequest<GetDonationRequestByIdDto>
    {
        public int Id { get; set; }
    }
}
