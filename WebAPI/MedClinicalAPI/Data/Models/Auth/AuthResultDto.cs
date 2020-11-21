using System.Collections.Generic;

namespace MedClinical.API.Data.Models.Auth
{
    public class AuthResultDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
    }
}