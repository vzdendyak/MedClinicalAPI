using MedClinicalAPI.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedClinicalAPI.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Record> Records { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<DepartmentService> DepartmentServices { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Department>()
                .HasOne(dep => dep.Address)
                .WithMany(addr => addr.Departments)
                .HasForeignKey(dep => dep.AddressId);
            builder.Entity<Department>()
                .HasOne(dep => dep.Schedule)
                .WithMany(sch => sch.Departments)
                .HasForeignKey(dep => dep.ScheduleId);
            //builder.Entity<Service>()
            //    .HasOne(serv => serv.Department)
            //    .WithMany(dep => dep.Services)
            //    .HasForeignKey(serv => serv.DepartmentId);
            builder.Entity<DepartmentService>()
                .HasKey(ds => new { ds.DepartmentId, ds.ServiceId });
            builder.Entity<DepartmentService>()
                .HasOne(ds => ds.Department)
                .WithMany(d => d.DepartmentServices)
                .HasForeignKey(ds => ds.DepartmentId);
            builder.Entity<DepartmentService>()
                .HasOne(ds => ds.Service)
                .WithMany(s => s.DepartmentServices)
                .HasForeignKey(ds => ds.ServiceId);
            builder.Entity<Record>()
                .HasOne(r => r.Doctor)
                .WithMany(u => u.Records)
                .HasForeignKey(r => r.DoctorId);
            builder.Entity<Record>()
                .HasOne(r => r.Patient)
                .WithMany(u => u.Visits)
                .HasForeignKey(r => r.PatientId);
            builder.Entity<Record>()
                .HasOne(r => r.Service)
                .WithMany(s => s.Records)
                .HasForeignKey(r => r.ServiceId);
            builder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(dep => dep.Doctors)
                .HasForeignKey(u => u.DepartmentId);
        }
    }
}