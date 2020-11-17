using MedClinical.API.Data.DTOs;
using MedClinical.API.Services.Interfaces;
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedClinical.API.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(AppDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        async Task<List<RecordDto>> IUserService.GetUserRecords(User user)
        {
            var userRole = (await _userManager.GetRolesAsync(user));
            var records = new List<RecordDto>();
            if (userRole.Contains("DOCTOR"))
            {
                records = GetRecordsFiltered(r => r.DoctorId == user.Id);
            }
            else if (userRole.Contains("PATIENT"))
            {
                records = GetRecordsFiltered(r => r.PatientId == user.Id);
            }
            else
            {
                records = GetRecordsFiltered(r => r.DoctorId == user.Id || r.PatientId == user.Id);
            }
            return records;
        }

        private List<RecordDto> GetRecordsFiltered(Expression<Func<Record, bool>> predicate)
        {
            var res = _context.Records.Where(predicate)
                   .Select(rec => new RecordDto
                   {
                       Id = rec.Id,
                       DateOfMeeting = rec.DateOfMeeting,
                       DateOfRecord = rec.DateOfRecord,
                       DoctorId = rec.DoctorId,
                       PatientId = rec.PatientId,
                       ServiceId = (int)rec.ServiceId,
                       Service = new Service
                       {
                           Id = rec.Service.Id,
                           Name = rec.Service.Name,
                           Description = rec.Service.Description,
                           Price = rec.Service.Price
                       },
                       Doctor = new UserDto
                       {
                           Id = rec.Doctor.Id,
                           FirstName = rec.Doctor.FirstName,
                           LastName = rec.Doctor.LastName,
                           UserName = rec.Doctor.UserName
                       },
                       Patient = new UserDto
                       {
                           Id = rec.Patient.Id,
                           FirstName = rec.Patient.FirstName,
                           LastName = rec.Patient.LastName,
                           UserName = rec.Patient.UserName
                       }
                   }).ToList();
            return res;
        }
    }
}