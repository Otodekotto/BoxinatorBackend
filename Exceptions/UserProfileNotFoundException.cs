namespace BoxinatorBackend.Exceptions
{
    public class UserProfileNotFoundException : Exception
    {
        public UserProfileNotFoundException(int id) : base($"UserProfile with id {id} was not found")
        {

        }
    }
}
