using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedClinical.API.Data.DTOs
{
    public class CreateRecordRequest
    {
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public long DateOfMeeting { get; set; }
    }
}