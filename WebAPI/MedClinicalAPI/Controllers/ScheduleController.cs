using MedClinical.API.Features.Commands.ScheduleCRUD.DeleteSchedule;
using MedClinical.API.Features.Queries.ScheduleCRUD.GetAllSchedule;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteSchedule.Command(id);
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}