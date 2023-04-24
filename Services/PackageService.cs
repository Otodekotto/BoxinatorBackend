using AutoMapper;
using BoxinatorBackend.Data;
using BoxinatorBackend.Exceptions;
using BoxinatorBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BoxinatorBackend.Services
{
    public class PackageService : IPackageService
    {
        private readonly BoxinatorDbContext _context;

        public PackageService(BoxinatorDbContext context)
        {
            _context = context;
        }
        public async Task<Package> CancelPackage(Package package)
        {
            var foundPackage = await _context.Packages.AnyAsync(x => x.Id == package.Id);

            if (!foundPackage)
            {
                throw new PackageNotFoundException(package.Id);
            }
            _context.Entry(package).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return package;
        }

        public async Task<Package> CreatePackage(Package package)
        {
            package.OrderTime = DateTime.Now.ToString();
            package.PackageStatus = "CREATED";
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();

            return package;
        }

        public async Task<IEnumerable<Package>> GetAllPackages()
        {
            return await _context.Packages.ToListAsync();
        }

        public async Task<Package> GetPackageById(int id)
        {
            var package = await _context.Packages.FirstOrDefaultAsync(x => x.Id == id);

            if (package == null)
            {
                throw new PackageNotFoundException(id);
            }
            return package;
        }

        public async Task<IEnumerable<Package>> GetUsersPackagesByEmail(string email)
        {
            return await _context.Packages.Where(x => x.Email == email).ToListAsync();
        }

        public async Task<IEnumerable<Package>> GetUsersCancelledPackagesByEmail(string email)
        {
            return await _context.Packages.Where(x => x.Email == email && x.PackageStatus == "CANCELLED").ToListAsync();
        }

        public async Task<IEnumerable<Package>> GetUsersCompletedPackagesByEmail(string email)
        {
            return await _context.Packages.Where(x => x.Email == email && x.PackageStatus == "COMPLETED").ToListAsync();
        }


        public async Task<Package> UpdatePackage(Package package)
        {
            var foundPackage = await _context.Packages.AnyAsync(x => x.Id == package.Id);
            if (!foundPackage)
            {
                throw new PackageNotFoundException(package.Id);
            }
            _context.Entry(package).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return package;
        }
    }
}
