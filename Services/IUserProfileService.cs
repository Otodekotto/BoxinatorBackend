using BoxinatorBackend.Models;

namespace BoxinatorBackend.Services
{
    public interface IUserProfileService
    {
        public Task<UserProfile> GetUserProfileById(int id);
        public Task<UserProfile> CreateUserProfile(UserProfile userProfile);
        public Task<UserProfile> UpdateUserProfile(Country userProfile);
        public Task DeleteUserProfile(int id);
    }
}
