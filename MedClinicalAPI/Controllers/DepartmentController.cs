using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Features.Commands.DepartmentCRUD.CreateDepartment;
using MedClinicalAPI.Features.Queries.DepartmentCRUD;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MedClinicalAPI.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var getQuery = new GetAllDepartments.Query();
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var getQuery = new GetDepartmentById.Query(id);
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Department department)
        {
            var createCommand = new CreateDepartment.Command(department);
            var res = await _mediator.Send(createCommand);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] Department department)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}