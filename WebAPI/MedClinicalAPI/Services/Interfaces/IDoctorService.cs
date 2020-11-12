using MedClinical.API.Data.DTOs;
using MedClinicalAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedClinical.API.Services.Interfaces
{
    public interface IDoctorService
    {
        IEnumerable<UserDto> GetDoctorsWithHours(int id);

        Task<IEnumerable<double>> GetDoctorHours(string id, long date);
    }
}