using MedClinical.API.Features.Commands.RecordCRUD.CreateRecord;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedClinical.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Record record)
        {
            var createRecordCommand = new CreateRecord.Command(record);
            var res = await _mediator.Send(createRecordCommand);
            return Ok(res);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAsync()
        //{
        //    var getQuery = new GetAllDepartments.Query();
        //    var res = await _mediator.Send(getQuery);
        //    return Ok(res);
        //}
    }
}