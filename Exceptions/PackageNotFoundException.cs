namespace BoxinatorBackend.Exceptions
{
    public class PackageNotFoundException : Exception
    {
        public PackageNotFoundException(int id) : base($"Package with id {id} was not found")
        {

        }
    }
}
