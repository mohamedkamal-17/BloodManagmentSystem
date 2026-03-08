namespace BloodManagment.Mvc.ViewModels.BloodRequests
{
    public class BloodRequestDetailsVM
    {
        public string RequestNumber { get; set; }

        public string PatientName { get; set; }

        public string BloodGroup { get; set; }

        public string PhoneNumber { get; set; }

        public string Disease { get; set; }

        public string Hospital { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public string Status { get; set; }
    }
}
