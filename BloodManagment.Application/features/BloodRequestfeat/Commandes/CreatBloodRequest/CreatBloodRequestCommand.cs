using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodRequestfeat.Commandes.CreatBloodRequest
{
    public class CreatBloodRequestCommand : IRequest<int>
    {
        public DateTime RequestDate { get; set; }
        public bool IsEmergency { get; set; }
        public int HospitalId { get; set; }
        public string Reason { get; set; }
        public int? RescipientId { get; set; }
        public int? LabTechnicianId { get; set; }
        public BloodGroup BloodGroup { get; set; }
    }
}
