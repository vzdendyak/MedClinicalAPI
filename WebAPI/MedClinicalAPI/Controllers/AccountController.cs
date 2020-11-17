using MedClinical.API.Data.DTOs;
using MedClinical.API.Features.Commands.AddUserToRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedClinical.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("roles")]
        public async Task<IActionResult> CreateAsync(AddToRoleDto model)
        {
            var getQuery = new AddUserToRole.Command(model);
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }
    }
}