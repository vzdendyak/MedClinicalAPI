using MedClinical.API.Data.Models.Auth;
using MedClinical.API.Features.Commands.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedClinical.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(e => e.Value.Errors.Select(e => e.ErrorMessage)));
            }
            if (model == null)
                return BadRequest("Invalid client request");

            var loginCommand = new LoginUser.Command(model);
            var loginResponse = await _mediator.Send(loginCommand);
            if (!loginResponse.Success)
            {
                return BadRequest(loginResponse.ErrorMessages);
            }
            //HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", authResponse.Token,
            //  new CookieOptions
            //  {
            //      //MaxAge = TimeSpan.FromMinutes(2)
            //      //Expires = DateTime.UtcNow.AddMinutes(2)
            //  }); ;
            //HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id-refresh", authResponse.RefreshToken,
            //new CookieOptions
            //{
            //    MaxAge = TimeSpan.FromHours(48)
            //});
            //HttpContext.Response.Cookies.Append("User-email", model.Email,
            //new CookieOptions
            //{
            //});
            return Ok(new
            {
                loginResponse.Token,
                loginResponse.RefreshToken
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(e => e.Value.Errors.Select(e => e.ErrorMessage)));
            }

            if (model == null)
                return BadRequest("Invalid client request");

            if (!string.Equals(model.ConfirmedPassword, model.Password))
            {
                return BadRequest(new string[] { "Confirmed password not match" });
            }
            model.Username = model.Username.Trim();
            model.Email = model.Email.Trim();

            var registerRequest = new RegisterUser.Command(model);
            var registerResponse = await _mediator.Send(registerRequest);

            if (!registerResponse.Success)
            {
                return BadRequest(registerResponse.ErrorMessages);
            }
            return Ok(new { Message = "Registered" });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(e => e.Value.Errors.Select(e => e.ErrorMessage)));
            }
            if (model == null)
                return BadRequest("Invalid client request");
            return Ok();
            //var authResponse = await _authBl.RefreshTokenAsync(model.Token, model.RefreshToken);
            //if (!authResponse.Success)
            //{
            //    return BadRequest(authResponse.ErrorMessages);
            //}

            //return Ok(new
            //{
            //    Token = authResponse.Token,
            //    RefreshToken = authResponse.RefreshToken
            //});
        }
    }
}