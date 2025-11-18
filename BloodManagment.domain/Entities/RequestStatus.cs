namespace BloodManagment.domain.Entities
{
    public enum RequestStatus
    {
        Pending,        // Request has been created but not yet processed
        Approved,       // Request has been approved
        Rejected,       // Request has been rejected
        Completed,      // Blood has been successfully provided
        Cancelled       // Request was cancelled by the user or admin
    }
}
