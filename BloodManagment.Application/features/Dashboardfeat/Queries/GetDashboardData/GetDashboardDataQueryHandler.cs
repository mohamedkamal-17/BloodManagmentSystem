using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BloodManagment.Application.features.Dashboardfeat.Queries.GetDashboardData
{
    public class GetDashboardDataQueryHandler
     : IRequestHandler<GetDashboardDataQuery, DashboardDto>
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUnitOfWork unitOfWork;

        public GetDashboardDataQueryHandler(UserManager<ApplicationUser> _userManager, IUnitOfWork unitOfWork)
        {
            userManager = _userManager;
            this.unitOfWork = unitOfWork;
        }

        public async Task<DashboardDto> Handle(
            GetDashboardDataQuery request,
            CancellationToken cancellationToken)
        {
            var dto = new DashboardDto();

            dto.TotalUsers = await userManager.Users.CountAsync();
            dto.TotalBloodRequests = await unitOfWork.BloodRequestRepository.GetCountAsync();
            dto.TotalDonations = await unitOfWork.DonationRequestRepository.GetByStatusAsync(RequestStatus.Completed).ContinueWith(t => t.Result.Count);
            dto.TotalBloodUnits = await unitOfWork.BloodUnitRepository.GetCountAsync();
            var invetoey = await unitOfWork.BloodInventoryRepository.GetAllAsync();
            dto.BloodTypeStats = invetoey
                .Select(g => new BloodTypeStatsDto
                {
                    BloodType = g.BloodGroup,
                    Count = g.Quantity
                }).ToList();

            var bloodRequest = await unitOfWork.BloodRequestRepository.GetAllAsync();
            dto.WeeklyRequests = bloodRequest.GroupBy(x => x.CreatedAt.DayOfWeek).Select(g => new WeeklyRequestStatsDto
            {
                Day = g.Key.ToString(),
                Count = g.Count()
            }).ToList();

            var topDonors = await unitOfWork.DonarRepository.GetTopDonarAsync();
            dto.TopDonors = topDonors
                .Select(x => new TopDonorDto
                {
                    Name = x.FullName,
                    DonationCount = x.DonationCount
                }).ToList();

            //var urgentRequests = await unitOfWork.BloodRequestRepository.GetByStatusAsync(RequestStatus.);
            //dto.UrgentRequests = await _context.BloodRequests
            //    .Where(x => x.Status == RequestStatus.Pending)
            //    .OrderByDescending(x => x.CreatedAt)
            //    .Take(5)
            //    .Select(x => new UrgentRequestDto
            //    {
            //        PatientName = x.PatientName,
            //        Hospital = x.Hospital.Name,
            //        BloodType = x.BloodType.ToString(),
            //        Quantity = x.Quantity,
            //        Status = x.Status.ToString()
            //    }).ToListAsync();

            return dto;
        }
    }
}
