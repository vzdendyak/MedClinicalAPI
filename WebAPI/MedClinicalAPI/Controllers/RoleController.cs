using MedClinical.API.Features.Commands.Roles;
using MedClinical.API.Features.Queries.Roles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedClinical.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var getQuery = new GetAllRoles.Query();
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(string Name)
        {
            var createCommand = new CreateRole.Command(Name);
            var res = await _mediator.Send(createCommand);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string Name)
        {
            var createCommand = new DeleteRole.Command(Name);
            var res = await _mediator.Send(createCommand);
            return Ok(res);
        }
    }
}