namespace BloodManagment.Application.Commane
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message
            ) : base(message)
        {
        }
    }
}
