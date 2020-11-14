using MedClinical.API.Data.DTOs;
using MedClinical.API.Features.Commands.UserCRUD.UpdateUserWithoutPassword;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedClinical.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}/edit")]
        public async Task<IActionResult> EditAsync(string id)
        {
            return Ok(true);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UserDto model)
        {
            var updCommand = new UpdateUserWithoutPassword.Command(model);
            var res = _mediator.Send(updCommand);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(UserChangePasswordDto model)
        {
            return Ok();
        }
    }
}