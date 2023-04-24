using AutoMapper;
using BoxinatorBackend.Models;
using BoxinatorBackend.Models.DTO.PackageDtos;

namespace BoxinatorBackend.Profiles
{
    public class PackageProfile : Profile
    {
        public PackageProfile() 
        {
            CreateMap<PostPackageDTO , Package>();
            CreateMap<PutPackageDTO , Package>();
            CreateMap<Package, GetPackageDTO>();
        }
    }
}
