using BoxinatorBackend.Data;
using BoxinatorBackend.Models;

namespace BoxinatorBackend.Services
{
    public class UserProfileService : IUserProfileService
    {

        private readonly BoxinatorDbContext _context;

        public UserProfileService(BoxinatorDbContext context)
        {
            _context = context;
        }

        public Task<UserProfile> CreateUserProfile(UserProfile userProfile)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserProfile(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> GetUserProfileById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> UpdateUserProfile(Country userProfile)
        {
            throw new NotImplementedException();
        }
    }
}
