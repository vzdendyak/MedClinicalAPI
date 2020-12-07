using MedClinical.API.Data.DTOs;
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Queries.GetHoursForDoctor
{
    public class GetHoursForDoctor
    {
        public class Query : IRequest<List<DateTime>>
        {
            public string Id { get; set; }
            public long Date { get; set; }

            public Query(string id, long date)
            {
                Id = id;
                Date = date;
            }
        }

        public class Handler : IRequestHandler<GetHoursForDoctor.Query, List<DateTime>>
        {
            private readonly AppDbContext _context;
            private readonly UserManager<User> _userManager;

            public Handler(AppDbContext context, UserManager<User> userManager)
            {
                _context = context;
                _userManager = userManager;
            }

            public async Task<List<DateTime>> Handle(Query request, CancellationToken cancellationToken)
            {
                // doctor id 365468ba-020a-4850-82cd-e4b0e703b6f5
                // date  637405632000000000
                var doctor = await _userManager.FindByIdAsync(request.Id);
                var sid = (await _context.Departments.Where(dep => dep.Id == doctor.DepartmentId).Select(dep => new DepartmentDto { ScheduleId = dep.ScheduleId }).FirstOrDefaultAsync()).ScheduleId;
                var schedule = await _context.Schedules.Where(s => s.Id == sid).Select(sch => new Schedule { StartHour = sch.StartHour, EndHour = sch.EndHour }).FirstOrDefaultAsync();

                TimeSpan time = new TimeSpan(schedule.StartHour, 0, 0);
                var numberOfRecords = schedule.EndHour - schedule.StartHour;
                var exDate = new DateTime(request.Date);
                var tspan = new TimeSpan();
                var needDate = new DateTimeOffset(request.Date, tspan).LocalDateTime;

                var existingRecords = _context.Records.Select(rec => new RecordDto
                {
                    Id = rec.Id,
                    DateOfMeeting = rec.DateOfMeeting,
                    DoctorId = rec.DoctorId,
                    PatientId = rec.PatientId
                }).Where(rec => rec.DoctorId == doctor.Id && rec.DateOfMeeting.Date == needDate.Date).ToList();
                var freeHours = new List<DateTime>();
                foreach (var item in existingRecords)
                {
                    Console.WriteLine(item);
                    Console.WriteLine(item.DateOfMeeting.ToLocalTime());
                    Console.WriteLine(item.DateOfMeeting.ToLocalTime().TimeOfDay);
                    Console.WriteLine(item.DateOfMeeting.ToLocalTime().TimeOfDay.Hours);
                }
                for (int i = schedule.StartHour; i < schedule.EndHour; i++)
                {
                    if (!existingRecords.Any(r => r.DateOfMeeting.TimeOfDay.Hours == i))
                    {
                        freeHours.Add(new DateTime(needDate.Year, needDate.Month, needDate.Day, i, 0, 0));
                    }
                }
                return freeHours;
            }
        }
    }
}