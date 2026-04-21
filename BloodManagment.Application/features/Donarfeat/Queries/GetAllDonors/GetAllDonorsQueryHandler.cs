using BloodManagment.Application.Commane;
using MediatR;

namespace BloodManagment.Application.features.Donarfeat.Queries.GetAllDonors
{

    public class GetAllDonorsQueryHandler
        : IRequestHandler<GetAllDonorsQuery, List<DonarVm>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDonorsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DonarVm>> Handle(
            GetAllDonorsQuery request,
            CancellationToken cancellationToken)
        {
            var donors = await _unitOfWork.DonarRepository.GetAllAsync();

            return donors.Select(d => new DonarVm
            {
                Id = d.Id,
                FullName = d.FullName,
                DonarCode = d.DonarCode,

                BloodGroup = d.BloodGroup.ToString(),
                Gender = d.Gender.ToString(),

                LastDonationDate = d.LastDonationDate,
                NextDonationDate = d.NextDonationDate,

                DonationCount = d.DonationCount,
                IsEilgibleToDonate = d.IsEilgibleToDonate
            }).ToList();
        }
    }
}
