using MedClinical.API.Data.DTOs;
using MedClinical.API.Features.Commands.RecordCRUD.CreateRecord;
using MedClinical.API.Features.Queries.RecordCRUD.GetDoctorRecord;
using MedClinical.API.Features.Queries.RecordCRUD.GetPatientRecord;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedClinical.API.Controllers
{
    [Route("api/records")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRecordRequest record)
        {
            var createRecordCommand = new CreateRecord.Command(record);
            var res = await _mediator.Send(createRecordCommand);
            return Ok(res);
        }

        [HttpGet("doctor")]
        public async Task<IActionResult> GetByDoctorAsync(string id)
        {
            var getQuery = new GetDoctorRecords.Query(id);
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpGet("patient")]
        public async Task<IActionResult> GetByPatientAsync(string id)
        {
            var getQuery = new GetPatientRecords.Query(id);
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }
    }
}