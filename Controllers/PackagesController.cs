using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BoxinatorBackend.Services;
using BoxinatorBackend.Models.DTO.PackageDtos;
using BoxinatorBackend.Models;
using System.Net.Mime;
using BoxinatorBackend.Exceptions;

namespace BoxinatorBackend.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PackagesController : Controller
    {
        private readonly IPackageService _packageService;
        private readonly IMapper _mapper;

        public PackagesController(IPackageService packageService, IMapper mapper)
        {
            _packageService = packageService;
            _mapper = mapper;
        }

        [HttpGet("Package")]
        public async Task<ActionResult<GetPackageDTO>> GetAllPackage()
        {
            return Ok(_mapper.Map<IEnumerable<GetPackageDTO>>(await _packageService.GetAllPackages()));
        }

        [HttpPost("Package")]
        public async Task<ActionResult<Package>> PostPackage(PostPackageDTO packageDTO)
        {
            var package = _mapper.Map<Package>(packageDTO);

            await _packageService.CreatePackage(package);

            return CreatedAtAction(nameof(GetAllPackage), new { id = package.Id }, package);
        }


        [HttpGet("Package/{id}")]
        public async Task<ActionResult<GetPackageDTO>> GetPackageById(int id)
        {
            try
            {
                return Ok(_mapper.Map<GetPackageDTO>(await _packageService.GetPackageById(id)));
            }
            catch (PackageNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        [HttpGet("Package/myemail")]
        public async Task<ActionResult<GetPackageDTO>> GetPackageByEmail(string email)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<GetPackageDTO>>(await _packageService.GetUsersPackagesByEmail(email)));
            }
            catch (EmailNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
        [HttpGet("Package/cancelled/myemail")]
        public async Task<ActionResult<GetPackageDTO>> GetCancelledPackageByEmail(string email)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<GetPackageDTO>>(await _packageService.GetUsersCancelledPackagesByEmail(email)));
            }
            catch (EmailNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
        [HttpGet("Package/completed/myemail")]
        public async Task<ActionResult<GetPackageDTO>> GetCompletedPackageByEmail(string email)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<GetPackageDTO>>(await _packageService.GetUsersCompletedPackagesByEmail(email)));
            }
            catch (EmailNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        [HttpPut("Package/ChangeSatus")]
        public async Task<IActionResult> PutPackage(int id, PutPackageDTO putPackageDto)
        {
            if (id != putPackageDto.Id)
            {
                return BadRequest();
            }

            try
            {
                Package package = _mapper.Map<Package>(putPackageDto);
                await _packageService.UpdatePackage(package);
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

        [HttpPut("Package/{id}")]
        public async Task<IActionResult> PutCancelPackage(int id, PutPackageDTO putPackageDto)
        {
            if (id != putPackageDto.Id)
            {
                return BadRequest();
            }
            putPackageDto.PackageStatus = "CANCELLED";
            try
            {
                Package package = _mapper.Map<Package>(putPackageDto);
                await _packageService.CancelPackage(package);
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

    }
}
