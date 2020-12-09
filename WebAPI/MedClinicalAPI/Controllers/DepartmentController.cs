using MedClinical.API.Features.Commands.AddServiceToDepartment;
using MedClinical.API.Features.Commands.DepartmentCRUD.DeleteDepartment;
using MedClinical.API.Features.Commands.DepartmentCRUD.UpdateDepartment;
using MedClinical.API.Features.Commands.UploadDepartmentPhoto;
using MedClinical.API.Features.Queries.GetDepartmentPhoto;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Features.Commands.DepartmentCRUD.CreateDepartment;
using MedClinicalAPI.Features.Queries.DepartmentCRUD;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace MedClinicalAPI.Controllers
{
    [EnableCors]
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

        [HttpPost("services")]
        public async Task<IActionResult> AddServiceAsync([FromBody] DepartmentService model)
        {
            var createCommand = new AddServiceToDepartment.Command(model.DepartmentId, model.ServiceId);
            var res = await _mediator.Send(createCommand);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Department department)
        {
            var command = new UpdateDepartment.Command(department);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteDepartment.Command(id);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        //[HttpPost("image"), DisableRequestSizeLimit]
        //public async Task<IActionResult> UploadImage()
        //{
        //    var file = Request.Form.Files[0];
        //    var userId = Request.Form["user"];
        //    var command = new UploadUserAvatar.Command(file, userId);
        //    var res = await _mediator.Send(command);
        //    return Ok(res);
        //}

        [HttpGet("image/{id}")]
        public async Task<IActionResult> GetImage(int Id)
        {
            var query = new GetDepartmentPhoto.Query(Id);
            var res = await _mediator.Send(query);

            return new FileStreamResult(new FileStream(res, FileMode.Open), "image/jpeg");
        }

        [HttpPost("avatar"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadImage()
        {
            var file = Request.Form.Files[0];
            var depId = Request.Form["department"];
            var command = new UploadDepartmentPhoto.Command(file, int.Parse(depId.ToString()));
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}