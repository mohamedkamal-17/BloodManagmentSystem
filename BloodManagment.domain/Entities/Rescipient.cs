namespace BloodManagment.domain.Entities
{
    public class Rescipient
    {
        public int Id { get; set; }

        public string RescipientCode { get; set; }
        public Gender Gender { get; set; }
        public string FullName { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Notification> Notification { get; set; } = new HashSet<Notification>();
        public ICollection<BloodRequest> BloodRequests { get; set; } = new HashSet<BloodRequest>();

    }
}
