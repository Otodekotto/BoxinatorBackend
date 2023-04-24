namespace BoxinatorBackend.Models.DTO.PackageDtos
{
    public class GetPackageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Weight { get; set; }
        public string BoxColor { get; set; }
        public string Destination { get; set; }
        public string PackageStatus { get; set; }
        public string OrderTime { get; set; }
    }
}
