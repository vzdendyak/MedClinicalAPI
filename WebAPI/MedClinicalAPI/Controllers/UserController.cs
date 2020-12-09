using MedClinical.API.Data.DTOs;
using MedClinical.API.Features.Commands.UserCRUD;
using MedClinical.API.Features.Commands.UserCRUD.ChangeUserPassword;
using MedClinical.API.Features.Commands.UserCRUD.DeleteUser;
using MedClinical.API.Features.Commands.UserCRUD.UpdateUserWithoutPassword;
using MedClinical.API.Features.Queries.UserCRUD.GetShortUserById;
using MedClinical.API.Features.Queries.UserCRUD.GetUserById;
using MedClinicalAPI.Features.Queries.UserCRUD;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedClinical.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var getQuery = new GetUserById.Query(id);
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getQuery = new GetAllUsers.Query();
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpGet("{id}/short")]
        public async Task<IActionResult> GetShortAsync(string id)
        {
            var getQuery = new GetShortUserById.Query(id);
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserDto model)
        {
            var updCommand = new CreateUser.Command(model);
            var res = await _mediator.Send(updCommand);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UserDto model)
        {
            var updCommand = new UpdateUserWithoutPassword.Command(model);
            var res = await _mediator.Send(updCommand);
            return Ok(res);
        }

        [HttpPut("password")]
        public async Task<IActionResult> ChangePasswordAsync(UserChangePasswordDto model)
        {
            var changePassword = new ChangeUserPassword.Command(model);
            var res = await _mediator.Send(changePassword);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string Id)
        {
            var delCommand = new DeleteUser.Command(Id);
            var res = await _mediator.Send(delCommand);
            return Ok(res);
        }
    }
}