namespace BloodManagment.domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public enum Gender
    {
        [Display(Name = "ذكر")]
        Male,

        [Display(Name = "انثى")]
        Female,

        [Display(Name = "غير ذلك")]
        Other,        // لو عايز تدعم خيارات غير ثنائية



    }
}
