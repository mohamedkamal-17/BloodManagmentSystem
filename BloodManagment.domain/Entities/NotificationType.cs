using System.ComponentModel.DataAnnotations;

namespace BloodManagment.domain.Entities
{

    public enum NotificationType
    {
        [Display(Name = "Information")]
        Info,

        [Display(Name = "Success")]
        Success,

        [Display(Name = "Warning")]
        Warning,

        [Display(Name = "Error")]
        Error,

        [Display(Name = "Urgent")]
        Urgent
    }

}
