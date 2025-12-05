namespace BloodManagment.Infrastructure.Comman
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message
            ) : base(message)
        {
        }

    }
}
