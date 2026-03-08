namespace BloodManagment.Mvc.ViewModels.BloodRequests
{
    public class BloodRequestCardVM
    {
        public string RequestNumber { get; set; }

        public string PatientName { get; set; }

        public string BloodGroup { get; set; }

        public string Status { get; set; }

        public string RequestType { get; set; }

        public DateTime RequiredDate { get; set; }

        public string HospitalName { get; set; }

        public int Contributors { get; set; }
    }
}
