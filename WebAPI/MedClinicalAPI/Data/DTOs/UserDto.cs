using MedClinicalAPI.Data.Models;

namespace MedClinical.API.Data.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? DepartmentId { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public Department Department { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }
}