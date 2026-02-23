namespace BloodManagment.Application.Commane
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        bool IsAuthenticated { get; }
        string? Email { get; }
        IEnumerable<string> Roles { get; }
    }

}
