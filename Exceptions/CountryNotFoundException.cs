namespace BoxinatorBackend.Exceptions
{
    public class CountryNotFoundException : Exception
    {
        public CountryNotFoundException(int id) : base($"Country with id {id} was not found")
        {

        }
    }
}
