namespace BoxinatorBackend.Exceptions
{
    public class EmailNotFoundException : Exception
    {
        public EmailNotFoundException(string email) : base($"{email} was not found")
        {

        }
    }
}
