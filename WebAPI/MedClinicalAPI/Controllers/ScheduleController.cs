using MedClinical.API.Features.Commands.ScheduleCRUD.CreateSchedule;
using MedClinical.API.Features.Commands.ScheduleCRUD.DeleteSchedule;
using MedClinical.API.Features.Commands.ScheduleCRUD.UpdateSchedule;
using MedClinical.API.Features.Queries.ScheduleCRUD.GetAllSchedule;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedClinical.API.Controllers
{
    [Route("api/schedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var getQuery = new GetAllSchedule.Query();
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Schedule schedule)
        {
            var command = new CreateSchedule.Command(schedule);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Schedule schedule)
        {
            var command = new UpdateSchedule.Command(schedule);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteSchedule.Command(id);
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}