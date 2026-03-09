using System.ComponentModel.DataAnnotations;

namespace BloodManagment.domain.Entities
{

    public enum BloodUnitStatus
    {
        [Display(Name = "متاح")]
        Available,

        [Display(Name = "محجوز")]
        Reserved,

        [Display(Name = "تم الاستخدام")]
        Used,

        [Display(Name = "منتهي الصلاحية")]
        Expired,

        [Display(Name = "تالف")]
        Damaged,

        [Display(Name = "قيد النقل")]
        InTransit
    }

}
