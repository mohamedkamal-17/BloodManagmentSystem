using BloodManagment.domain.Common;

namespace BloodManagment.domain.Entities
{
    public class RecipientBloodRequestHistory : BaseEntity
    {


        public BloodGroup BloodGroup { get; set; }

        public int UnitsNeeded { get; set; }      // Number of units requested

        // Request Details
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        public string HospitalName { get; set; }
        public string Diagnosis { get; set; }      // Thalassemia, Surgery, Accident…

        // Status
        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        // Recipient Info
        public int RecipientId { get; set; }      // FK → User
        public Rescipient Recipient { get; set; }

        // Optional Notes
        public string Notes { get; set; }


    }

}
