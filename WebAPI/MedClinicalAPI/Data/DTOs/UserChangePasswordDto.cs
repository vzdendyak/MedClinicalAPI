namespace MedClinical.API.Data.DTOs
{
    public class UserChangePasswordDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}