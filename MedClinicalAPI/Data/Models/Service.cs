namespace MedClinicalAPI.Data.Models
{
    public class Service
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }

        // nav props
        public Department Department { get; set; }
    }
}