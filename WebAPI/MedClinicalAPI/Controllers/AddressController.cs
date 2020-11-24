using MedClinical.API.Features.Commands.AddressCRUD.DeleteAddress;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Features.Queries.AddressCRUD.GetAddressById;
using MedClinicalAPI.Features.Queries.AddressCRUD.GetAllAddresses;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
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
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] Address address)
        {
            throw new NotImplementedException();
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