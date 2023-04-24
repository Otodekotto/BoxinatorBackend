using BoxinatorBackend.Models;

namespace BoxinatorBackend.Services
{
    public interface IPackageService
    {
        public Task<IEnumerable<Package>> GetAllPackages();
        public Task<IEnumerable<Package>> GetUsersPackagesByEmail(string email);
        public Task<IEnumerable<Package>> GetUsersCompletedPackagesByEmail(string email);
        public Task<IEnumerable<Package>> GetUsersCancelledPackagesByEmail(string email);
        public Task<Package> CreatePackage(Package package);
        public Task<Package> GetPackageById(int id);
        public Task<Package> UpdatePackage(Package package);
        public Task<Package> CancelPackage(Package package);
    }
}
