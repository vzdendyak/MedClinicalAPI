using MedClinical.API.Data.DTOs;
using MedClinical.API.Services.Interfaces;
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedClinical.API.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public DoctorService(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<double>> GetDoctorHours(string id, long date)
        {
            var doctor = await _userManager.FindByIdAsync(id);

            var sid = (await _context.Departments.Where(dep => dep.Id == doctor.DepartmentId).Select(dep => new DepartmentDto { ScheduleId = dep.ScheduleId }).FirstOrDefaultAsync()).ScheduleId;
            var schedule = await _context.Schedules.Where(s => s.Id == sid).Select(sch => new Schedule { StartHour = sch.StartHour, EndHour = sch.EndHour }).FirstOrDefaultAsync();
            TimeSpan time = new TimeSpan(schedule.StartHour, 0, 0);
            var numberOfRecords = schedule.EndHour - schedule.StartHour;
            var needDate = new DateTime(date);
            var existingRecords = _context.Records.Where(rec => rec.DoctorId == doctor.Id && rec.DateOfMeeting.ToShortDateString() == needDate.ToShortDateString()).Select(rec => new RecordDto
            {
                Id = rec.Id,
                DateOfMeeting = rec.DateOfMeeting,
                DoctorId = rec.DoctorId,
                PatientId = rec.PatientId
            }).ToList();
            for (int i = 0; i < numberOfRecords; i++)
            {
            }

            return null;
        }

        public IEnumerable<UserDto> GetDoctorsWithHours(int id)
        {
            var dep = _context.Departments.Include(dep => dep.Doctors).Include(dep => dep.Schedule).Where(dep => dep.Id == id).FirstOrDefault();

            //var doctors = _userManager.Users.Where(u => u.DepartmentId == id);
            var doctors = dep.Doctors.Select(doc => new UserDto
            {
                Id = doc.Id,
                DepartmentId = doc.DepartmentId,
                UserName = doc.UserName,
                Email = doc.Email,
                FirstName = doc.FirstName,
                LastName = doc.LastName
            }).ToList();
            var schedule = dep.Schedule;
            var numberOfRecords = schedule.EndHour - schedule.StartHour;
            TimeSpan time = new TimeSpan(schedule.StartHour, 0, 0);

            foreach (var doctor in doctors)
            {
                for (int i = 0; i < numberOfRecords; i++)
                {
                }
            }
            return null;
        }
    }
}