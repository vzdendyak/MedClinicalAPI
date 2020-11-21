using MedClinical.API.Data.DTOs;
using MedClinical.API.Features.Commands.Roles;
using MedClinical.API.Features.Commands.UploadUserAvatar;
using MedClinical.API.Features.Queries.GetUserAvatar;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
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

        [HttpPost("avatar"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadImage()
        {
            var file = Request.Form.Files[0];
            var userId = Request.Form["user"];
            var command = new UploadUserAvatar.Command(file, userId);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpGet("avatar/{id}")]
        public async Task<IActionResult> GetImage(string Id)
        {
            var query = new GetUserAvatar.Query(Id);
            var res = await _mediator.Send(query);

            return new FileStreamResult(new FileStream(res, FileMode.Open), "image/jpeg");
        }
    }
}