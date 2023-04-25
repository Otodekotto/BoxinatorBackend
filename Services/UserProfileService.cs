using BoxinatorBackend.Data;
using BoxinatorBackend.Exceptions;
using BoxinatorBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BoxinatorBackend.Services
{
    public class UserProfileService : IUserProfileService
    {

        private readonly BoxinatorDbContext _context;

        public UserProfileService(BoxinatorDbContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> CreateUserProfile(UserProfile userProfile)
        {
            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();

            return userProfile;
        }

        public async Task DeleteUserProfile(int id)
        {
            var profile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == id);
            if (profile == null)
            {
                throw new UserProfileNotFoundException(id);
            }
            _context.UserProfiles.Remove(profile);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserProfile>> GetAllUserProfiles()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task<UserProfile> GetUserProfileById(int id)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == id);

            if (userProfile == null)
            {
                throw new UserProfileNotFoundException(id);
            }
            return userProfile;
        }

        public async Task<UserProfile> UpdateUserProfile(UserProfile userProfile)
        {
            var foundUserProfile = await _context.Packages.AnyAsync(x => x.Id == userProfile.Id);
            if (!foundUserProfile)
            {
                throw new UserProfileNotFoundException(userProfile.Id);
            }
            _context.Entry(userProfile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return userProfile;
        }
    }
}
