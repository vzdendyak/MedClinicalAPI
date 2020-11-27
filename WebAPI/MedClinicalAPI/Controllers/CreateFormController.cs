using MedClinical.API.Features.Queries.GetAddressAndShedules;
using MedClinical.API.Features.Queries.GetRolesAndDepartments;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedClinical.API.Controllers
{
    [Route("api/createForm")]
    [ApiController]
    public class CreateFormController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateFormController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("addressAndShedules")]
        public async Task<IActionResult> GetAddressAndShedulesAsync()
        {
            var getQuery = new GetAddressAndShedules.Query();
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpGet("rolesAndDepartments")]
        public async Task<IActionResult> GetRolesAndDepartmentsAsync()
        {
            var getQuery = new GetRolesAndDepartments.Query();
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }
    }
}