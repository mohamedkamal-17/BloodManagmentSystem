using BloodManagment.Application.features.DonationPredictionService;
using MediatR;

namespace BloodManagment.Application.features.Donarfeat.Queries.PredictDonor
{
    public class PredictDonorByIdQuery : IRequest<PredictionResultVm>
    {
        public int DonorId { get; set; }
    }
}
