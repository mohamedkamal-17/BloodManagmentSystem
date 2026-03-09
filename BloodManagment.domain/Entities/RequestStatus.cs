using System.ComponentModel.DataAnnotations;

namespace BloodManagment.domain.Entities
{


    public enum RequestStatus
    {

        [Display(Name = "Pending")]
        Pending,        // Request has been created but not yet processed

        [Display(Name = "Approved")]
        Approved,       // Request has been approved

        [Display(Name = "Rejected")]
        Rejected,       // Request has been rejected

        [Display(Name = "Accepted")]
        Accepted,      // Blood has been successfully provided

        [Display(Name = "Cancelled")]
        Cancelled       // Request was cancelled by the user or admin
    }
}
