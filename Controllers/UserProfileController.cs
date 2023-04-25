using AutoMapper;
using BoxinatorBackend.Exceptions;
using BoxinatorBackend.Models.DTO.PackageDtos;
using BoxinatorBackend.Models;
using BoxinatorBackend.Models.DTO.UserProfileDtos;
using BoxinatorBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BoxinatorBackend.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;

        public UserProfileController(IUserProfileService userProfileService, IMapper mapper)
        {
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        [HttpGet("UserProfile")]
        public async Task<ActionResult<GetUserProfileDTO>> GetAllUserProfiles()
        {
            return Ok(_mapper.Map<IEnumerable<GetUserProfileDTO>>(await _userProfileService.GetAllUserProfiles()));
        }

        [HttpPost("UserProfile")]
        public async Task<ActionResult<UserProfile>> PostPackage(PostUserProfileDTO userProfileDTO , string KeyCloakId , string Email)
        {
         
            var userProfile = _mapper.Map<UserProfile>(userProfileDTO);
            userProfile.KeycloakId = KeyCloakId;
            userProfile.Email = Email;
            await _userProfileService.CreateUserProfile(userProfile);

            return CreatedAtAction(nameof(GetAllUserProfiles), new { id = userProfile.Id }, userProfile);
        }

        [HttpGet("UserProfile/{id}")]
        public async Task<ActionResult<GetUserProfileDTO>> GetUserProfileById(int id)
        {
            try
            {
                return Ok(_mapper.Map<GetUserProfileDTO>(await _userProfileService.GetUserProfileById(id)));
            }
            catch (UserProfileNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        [HttpPut("UserProfile/{id}")]
        public async Task<IActionResult> PutUserProfile(int id, PutUserProfileDTO putUserProfileDto)
        {
            if (id != putUserProfileDto.Id)
            {
                return BadRequest();
            }

            try
            {
                UserProfile userProfile = _mapper.Map<UserProfile>(putUserProfileDto);
                await _userProfileService.UpdateUserProfile(userProfile);
            }
            catch (PackageNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        [HttpDelete("UserProfile/{id}")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            try
            {
                await _userProfileService.DeleteUserProfile(id);
            }
            catch (UserProfileNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

    }
}
