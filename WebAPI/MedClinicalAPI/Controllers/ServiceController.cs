using MedClinical.API.Features.Commands.ServiceCRUD.CreateService;
using MedClinical.API.Features.Commands.ServiceCRUD.DeleteService;
using MedClinical.API.Features.Commands.ServiceCRUD.UpdateService;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Features.Queries.ServiceCRUD.GetAllServices;
using MedClinicalAPI.Features.Queries.ServiceCRUD.GetServicesById;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedClinicalAPI.Controllers
{
    [EnableCors]
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var getQuery = new GetAllServices.Query();
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var getQuery = new GetServicesById.Query(id);
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Service service)
        {
            var command = new CreateService.Command(service);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Service service)
        {
            var command = new UpdateService.Command(service);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteService.Command(id);
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}