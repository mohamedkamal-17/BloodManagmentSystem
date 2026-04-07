using MediatR;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestById
{
    public class GetDonationRequestByIdQuery : IRequest<DonationRequestDetailsDto>
    {
        public int Id { get; set; }
    }
}
