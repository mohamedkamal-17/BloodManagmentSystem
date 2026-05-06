namespace BloodManagment.Application.features.Donarfeat.Queries
{
    public class DonarVm
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DonarCode { get; set; }

        public string BloodGroup { get; set; }
        public string Gender { get; set; }

        public int DonationRequestesCount { get; set; }
        public DateTime? LastDonationDate { get; set; }
        public DateTime? NextDonationDate { get; set; }

        public int DonationCount { get; set; }

        public bool IsEilgibleToDonate { get; set; }
    }
}
