namespace BloodManagment.Application.features.Dashboardfeat.Queries.GetDashboardData
{
    public class UrgentRequestDto
    {
        public string PatientName { get; set; }
        public string Hospital { get; set; }
        public string BloodType { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}