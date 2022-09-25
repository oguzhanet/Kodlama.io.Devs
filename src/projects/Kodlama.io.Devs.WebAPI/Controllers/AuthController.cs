using Core.Security.Dtos;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Authorizations.Commands.Logins;
using Kodlama.io.Devs.Application.Features.Authorizations.Commands.Registers;
using Kodlama.io.Devs.Application.Features.Authorizations.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new RegisterCommand
            {
                UserForRegisterDto = userForRegisterDto,
                IPAddress = getIpAddress()
            };

            RegisterDto registeredDto = await Mediator.Send(registerCommand);
            setRefreshTokenToCookie(registeredDto.RefreshToken);
            return Created("", registeredDto.AccessToken);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new()
            {
                UserForLoginDto = userForLoginDto,
                IPAddress = getIpAddress()
            };

            TokenDto tokenDto = await Mediator.Send(loginCommand);

            if (tokenDto.RefreshToken is not null) setRefreshTokenToCookie(tokenDto.RefreshToken);

            return Ok(tokenDto.AccessToken);
        }

        private string getRefreshTokenFromCookies()
        {
            return Request.Cookies["refreshToken"];
        }


        private void setRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
