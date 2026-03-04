namespace BloodManagment.Application.features.Dashboardfeat.Queries.GetDashboardData
{
    public class DashboardDto
    {
        public int TotalUsers { get; set; }
        public int TotalBloodRequests { get; set; }
        public int TotalDonations { get; set; }
        public int TotalBloodUnits { get; set; }

        public List<BloodTypeStatsDto> BloodTypeStats { get; set; }
        public List<WeeklyRequestStatsDto> WeeklyRequests { get; set; }

        public List<TopDonorDto> TopDonors { get; set; }
        public List<UrgentRequestDto> UrgentRequests { get; set; }
    }
}