namespace MedClinical.API.Data.Models.Auth
{
    public class RefreshTokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}