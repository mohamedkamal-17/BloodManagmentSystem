using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.Rescipientfeat.Queries
{
    public class RecipientDto
    {
        public int Id { get; set; }
        public string RecipientCode { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public Gender Gender { get; set; }
        public int BloodRequestsCount { get; set; }
    }
}