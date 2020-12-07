using MedClinical.API.Features.Commands.AddressCRUD.CreateAddress;
using MedClinical.API.Features.Commands.AddressCRUD.DeleteAddress;
using MedClinical.API.Features.Commands.AddressCRUD.UpdateAddress;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Features.Queries.AddressCRUD.GetAddressById;
using MedClinicalAPI.Features.Queries.AddressCRUD.GetAllAddresses;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedClinicalAPI.Controllers
{
    [EnableCors]
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var getQuery = new GetAllAddresses.Query();
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var getQuery = new GetAddressById.Query(id);
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Address address)
        {
            var createCommand = new CreateAddress.Command(address);
            var res = await _mediator.Send(createCommand);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Address address)
        {
            var command = new UpdateAddress.Command(address);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteAddress.Command(id);
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}