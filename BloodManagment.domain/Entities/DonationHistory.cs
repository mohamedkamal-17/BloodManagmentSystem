namespace BloodManagment.domain.Entities
{


    public class DonationHistory
    {
        public int Id { get; set; }   // Primary Key

        public BloodGroup BloodGroup { get; set; }

        public int UnitsDonated { get; set; }   // Number of units donated

        // Dates & Tracking
        public DateTime DonationDate { get; set; } = DateTime.Now;

        public RequestStatus status { get; set; }  // Status of the donation record

        public string DonationLocation { get; set; }  // Hospital / Center name
        public string Notes { get; set; }             // Optional notes

        // Donor Info
        public int DonorId { get; set; }       // FK to User
        public Donar Donor { get; set; }




    }

}
