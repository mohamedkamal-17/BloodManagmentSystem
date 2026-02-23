using BloodManagment.domain.Common;

namespace BloodManagment.domain.Entities
{
    public class Hospital : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }


        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        public ICollection<LabTechnician> LabTechnicians { get; set; } = new HashSet<LabTechnician>();
        public ICollection<BloodInventory> BloodInventories { get; set; } = new HashSet<BloodInventory>();
        public ICollection<BloodRequest> BloodRequests { get; set; } = new HashSet<BloodRequest>();

    }
}
