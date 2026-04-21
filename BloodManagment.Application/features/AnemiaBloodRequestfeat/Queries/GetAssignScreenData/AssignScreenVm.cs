using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAssignScreenData
{
    public class AssignScreenVm
    {
        public int RequestId { get; set; }
        public int PatientId { get; set; }

        public string RequestCode { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public string Hospital { get; set; }

        public List<DonorVm> Donors { get; set; }
    }

    public class DonorVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BloodGroup { get; set; }
        public DateTime? LastDonationDate { get; set; }
    }
}
