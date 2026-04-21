using BloodManagment.Application.Commane;
using MediatR;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAssignScreenData
{
    public class GetAssignScreenDataQueryHandler
    : IRequestHandler<GetAssignScreenDataQuery, AssignScreenVm>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAssignScreenDataQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AssignScreenVm> Handle(
            GetAssignScreenDataQuery request,
            CancellationToken cancellationToken)
        {
            var req = await _unitOfWork.AnemiaBloodRequestRepository
                .GetByIdAsync(request.RequestId);

            if (req == null)
                throw new Exception("Request not found");

            var donors = await _unitOfWork.DonarRepository.GetAllAsync();

            return new AssignScreenVm
            {
                RequestId = req.Id,
                PatientId = req.PatientId,
                RequestCode = req.RequestCode,
                BloodGroup = req.BloodGroup,
                Hospital = req.ResponsibleEntity,

                Donors = donors.Select(d => new DonorVm
                {
                    Id = d.Id,
                    Name = d.FullName,
                    BloodGroup = d.BloodGroup.ToString(),
                    LastDonationDate = d.LastDonationDate
                }).ToList()
            };
        }
    }
}
