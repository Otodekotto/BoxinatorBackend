namespace BoxinatorBackend.Models.DTO.UserProfileDtos
{
    public class PutUserProfileDTO
    {
        public int Id { get; set; }
        public string KeycloakId { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public int Zipcode { get; set; }
        public int ContactNumber { get; set; }
    }
}
