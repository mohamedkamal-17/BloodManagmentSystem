namespace BloodManagment.domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }

        // Notification Content
        public string Title { get; set; }
        public string Message { get; set; }


        // Receiver (User who will see the notification)
        public string? RescipientId { get; set; }
        public Rescipient? User { get; set; }

        public string? DonarId { get; set; }
        public Donar? Donar { get; set; }

        public string ThalassemiaPatientId { get; set; }
        public ThalassemiaPatient? ThalassemiaPatient { get; set; }

        // Optional: Link to request
        public int? RequestId { get; set; }
        public RecipientBloodRequest Request { get; set; }

        public int? DonationRequestId { get; set; }
        public DonationRequest? DonationRequest { get; set; }
        // Type (Info, Warning, Success, Urgent...)
        public NotificationType Type { get; set; }

        // Status
        public bool IsRead { get; set; } = false;

        // Time
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
