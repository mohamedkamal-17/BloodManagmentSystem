using BloodManagment.domain.Common;

namespace BloodManagment.domain.Entities
{
    public class Notification : BaseEntity
    {


        // Notification Content
        public string Title { get; set; }
        public string Message { get; set; }


        // Receiver (User who will see the notification)
        public int? RescipientId { get; set; }
        public Rescipient? Rescipient { get; set; }

        public int? DonarId { get; set; }
        public Donar? Donar { get; set; }

        public int ThalassemiaPatientId { get; set; }
        public ThalassemiaPatient? ThalassemiaPatient { get; set; }

        // Optional: Link to request
        public int? BloodRequestId { get; set; }
        public BloodRequest BloodRequest { get; set; }

        public int? DonationRequestId { get; set; }
        public DonationRequest? DonationRequest { get; set; }
        // Type (Info, Warning, Success, Urgent...)
        public NotificationType Type { get; set; }

        // Status
        public bool IsRead { get; set; } = false;

        // Time

        public int? HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }

}
