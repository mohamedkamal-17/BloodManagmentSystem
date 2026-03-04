using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.Dashboardfeat.Queries.GetDashboardData
{
    public class BloodTypeStatsDto
    {

        public BloodGroup BloodType { get; set; }
        public int Count { get; set; }
    }
}