using AutoMapper;
using BoxinatorBackend.Models;
using BoxinatorBackend.Models.DTO.UserProfileDtos;

namespace BoxinatorBackend.Profiles
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile() 
        {
            CreateMap<PostUserProfileDTO, UserProfile>();
            CreateMap<PostUserProfileDTO , UserProfile>();
            CreateMap<UserProfile, GetUserProfileDTO>();
        }
    }
}
