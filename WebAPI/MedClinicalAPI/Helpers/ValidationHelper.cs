using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Exceptions;
using System.Linq;

namespace MedClinicalAPI.Helpers
{
    public class ValidationHelper
    {
        public static void IsDepartmentExist(Department department, AppDbContext _context)
        {
            var isDepartment = _context.Departments.Any(d => d.DepartmentName == department.DepartmentName && d.AddressId == department.AddressId);
            if (isDepartment)
                throw new BadRequestException("Department with the same name is exist at this address.");
        }

        internal static void IsRecordExist(Record record, AppDbContext context)
        {
            var isRecord = context.Records.Any(rec => rec.DateOfMeeting == record.DateOfMeeting && rec.PatientId == record.PatientId && rec.DoctorId == record.DoctorId);
            if (isRecord)
                throw new BadRequestException($"Record for this patient and this doctor scheduled for {record.DateOfMeeting.ToString("g")} is exist.");
        }
    }
}