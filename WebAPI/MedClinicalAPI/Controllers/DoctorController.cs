using MedClinical.API.Features.Queries.GetHoursForDoctor;
using MedClinical.API.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedClinical.API.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMediator _mediator;

        public DoctorController(IDoctorService doctorService, IMediator mediator)
        {
            _doctorService = doctorService;
            _mediator = mediator;
        }

        [HttpGet("{id}/{date}")]
        public async Task<IActionResult> GetHoursForDoctor(string id, long date)
        {
            var command = new GetHoursForDoctor.Query(id, date);
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}