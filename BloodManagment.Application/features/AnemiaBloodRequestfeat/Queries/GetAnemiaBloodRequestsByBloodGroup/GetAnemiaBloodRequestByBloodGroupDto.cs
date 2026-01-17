using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestsByBloodGroup
{
    public class GetAnemiaBloodRequestByBloodGroupDto
    {
        public string RequestCode { get; set; }
        public DateTime RequestDate { get; set; }

        public BloodGroup BloodGroup { get; set; }

        public RequestStatus Status { get; set; }
        // Step 2: Case Information
        public string ResponsibleEntity { get; set; }            // الجهة
        public DateTime AttendanceDate { get; set; }             // يوم الحضور
        public DateTime BloodTestDate { get; set; }              // تاريخ عمل صورة الدم
        public DateTime LastTransfusionDate { get; set; }        // تاريخ آخر نقل دم
        public float HemoglobinLevel { get; set; }               // نسبة الهيموجلوبين
        public string BloodTestIssuer { get; set; }              // جهة إصدار صورة الدم


        public int PatientId { get; set; }

    }
}
