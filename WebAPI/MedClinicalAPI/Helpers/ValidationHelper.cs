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

        public static void IsServiceExist(Service service, AppDbContext _context)
        {
            var isService = _context.Services.Any(d => d.Name == service.Name && d.Price == service.Price);
            if (isService)
                throw new BadRequestException("Service with the same name and same price is exist.");
        }

        public static void IsAddressExist(Address address, AppDbContext _context)
        {
            var isAddress = _context.Addresses.Any(d => d.City == address.City && d.Region == address.Region && d.Street == address.Street && d.HouseNumber == address.HouseNumber);
            if (isAddress)
                throw new BadRequestException("This address already exists.");
        }

        public static void IsRoleExist(string Name, AppDbContext _context)
        {
            var isRole = _context.Roles.Any(d => d.Name == Name);
            if (isRole)
                throw new BadRequestException("This role already exists.");
        }
    }
}