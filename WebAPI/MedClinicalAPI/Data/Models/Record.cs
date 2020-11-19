using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedClinicalAPI.Data.Models
{
    [Table("Records")]
    public class Record
    {
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public DateTime DateOfRecord { get; set; }
        public DateTime DateOfMeeting { get; set; }
        public int? ServiceId { get; set; }

        // nav props
        public User Doctor { get; set; }

        public Service Service { get; set; }
        public User Patient { get; set; }
    }
}