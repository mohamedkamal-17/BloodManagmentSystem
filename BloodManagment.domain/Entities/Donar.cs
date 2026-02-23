namespace BloodManagment.domain.Entities
{
    public class Donar
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string DonarCode { get; set; }
        public DateTime? NextDonationDate { get; set; }

        public BloodGroup BloodGroup { get; set; }

        public Gender Gender { get; set; }

        public DateTime? LastDonationDate { get; set; }

        public short DonationCount { get; set; } = default;

        public bool IsEilgibleToDonate { get; set; } = default;

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<ThalassemiaPatientDonorAssignement> thalassemiaPatientDonorAssignements { get; set; } = new HashSet<ThalassemiaPatientDonorAssignement>();
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();




    }
}
