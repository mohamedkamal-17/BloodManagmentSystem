using BloodManagment.domain.Common;

namespace BloodManagment.domain.Entities
{
    public class ThalassemiaPatientDonorAssignement : BaseEntity
    {


        public int ThalassemiaPatientId { get; set; }
        public ThalassemiaPatient ThalassemiaPatient { get; set; }

        public int DonarId { get; set; }
        public Donar Donar { get; set; }
    }
}
