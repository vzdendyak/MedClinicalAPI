namespace MedClinicalAPI.Data.Models
{
    public class DepartmentService
    {
        public int DepartmentId { get; set; }
        public int ServiceId { get; set; }

        // nav
        public Department Department { get; set; }

        public Service Service { get; set; }
    }
}