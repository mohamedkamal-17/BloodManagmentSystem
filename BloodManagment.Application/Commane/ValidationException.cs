namespace BloodManagment.Application.Commane
{
    public class ValidationException : Exception
    {

        public Dictionary<string, string[]> Errors;
        public ValidationException(string message,
            Dictionary<string, string[]> errors
            ) : base(message)
        {
            Errors = errors;
        }


    }
}
