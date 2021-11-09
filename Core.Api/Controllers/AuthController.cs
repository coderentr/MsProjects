using Core.Infrastructure.Dtos.PostDtos;
using Core.Infrastructure.Utilities.Security.JwtToken;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenHelper _tokenHelper;

        public AuthController(IAuthService authService, ITokenHelper tokenHelper)
        {
            _authService = authService;
            _tokenHelper = tokenHelper;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromForm]LoginUserDto model)
        {
            var result = _authService.Login(model);
            if (result.IsSuccess)
            {
                var token = _tokenHelper.CreateToken(result.Data);
                result.Data.Token = token;
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpPost("Register")]
        public IActionResult Register([FromForm] RegisterUserDto model)
        {
            var result = _authService.Register(model);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
