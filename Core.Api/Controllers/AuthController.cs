using Core.Infrastructure.Dtos.PostDtos;
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

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromForm]LoginUserDto model)
        {
            var result = _authService.Login(model);
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
