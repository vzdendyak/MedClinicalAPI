using MedClinicalAPI.Data.Models;
using System;

namespace MedClinical.API.Data.DTOs
{
    public class RecordDto
    {
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public DateTime DateOfRecord { get; set; }
        public DateTime DateOfMeeting { get; set; }
        public int ServiceId { get; set; }
        public UserDto Doctor { get; set; }
        public UserDto Patient { get; set; }
        public Service Service { get; set; }
    }
}