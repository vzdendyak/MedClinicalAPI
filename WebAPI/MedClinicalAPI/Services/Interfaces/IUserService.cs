using MedClinical.API.Data.DTOs;
using MedClinicalAPI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedClinical.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<RecordDto>> GetUserRecords(User user);
    }
}