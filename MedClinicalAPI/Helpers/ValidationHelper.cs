using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using System;
using System.Linq;

namespace MedClinicalAPI.Helpers
{
    public class ValidationHelper
    {
        public static void IsDepartmentExist(Department department, AppDbContext _context)
        {
            var isDepartment = _context.Departments.Any(d => d.DepartmentName == department.DepartmentName && d.AddressId == department.AddressId);
            if (isDepartment)
                throw new Exception("Department with the same name is exist at this address.");
        }
    }
}