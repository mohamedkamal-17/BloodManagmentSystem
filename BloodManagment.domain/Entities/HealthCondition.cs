using BloodManagment.domain.Common;

namespace BloodManagment.domain.Entities
{
    public class HealthCondition : BaseEntity
    {

        public bool HasAnemia { get; set; }                 // فقر الدم
        public bool HasJaundice { get; set; }               // الصفراء
        public bool HasHeartDisease { get; set; }           // أمراض القلب
        public bool HasCancer { get; set; }                 // السرطان
        public bool HasDiabetes { get; set; }               // السكري
        public bool HasAIDS { get; set; }                   // الإيدز
        public bool HasCold { get; set; }                   // نزلات البرد
        public bool IsPregnant { get; set; }                // الحمل
        public bool HasSkinDisease { get; set; }            // أمراض جلدية
        public bool HasBloodPressureIssue { get; set; }     // ارتفاع أو انخفاض الضغط
        public bool HasRecentSurgery { get; set; }          // عملية جراحية مؤخرًا

        public ICollection<DonationRequest> DonationRequests { get; set; } = new HashSet<DonationRequest>();
    }
}
