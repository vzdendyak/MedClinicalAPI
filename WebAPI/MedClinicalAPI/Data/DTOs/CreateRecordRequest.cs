namespace MedClinical.API.Data.DTOs
{
    public class CreateRecordRequest
    {
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public long DateOfMeeting { get; set; }
        public int ServiceId { get; set; }
    }
}