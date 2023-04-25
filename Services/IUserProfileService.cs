using BoxinatorBackend.Models;

namespace BoxinatorBackend.Services
{
    public interface IUserProfileService
    {
        public Task<IEnumerable<UserProfile>> GetAllUserProfiles();
        public Task<UserProfile> GetUserProfileById(int id);
        public Task<UserProfile> CreateUserProfile(UserProfile userProfile);
        public Task<UserProfile> UpdateUserProfile(UserProfile userProfile);
        public Task DeleteUserProfile(int id);
    }
}
