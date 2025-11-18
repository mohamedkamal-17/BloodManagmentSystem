namespace BloodManagment.domain.Entities
{
    public class Rescipient
    {
        public int Id { get; set; }

        public string RescipientCode { get; set; }
        public Gender Gender { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
