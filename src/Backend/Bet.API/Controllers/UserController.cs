using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bet.Application.DTOs;
using Bet.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] PlaceUserDTO request)
        {
            var result = await _userService.RegisterUser(request);

            return result.Match<IActionResult>(
                sucess => Ok(sucess.Username),
                error => BadRequest(new { error.ErrorCode, error.ErrorMessage })
            );
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            var result = await _userService.Login(request);

            return result.Match<IActionResult>(
                sucess => Ok(sucess),
                error => BadRequest(new { error.ErrorCode, error.ErrorMessage })
            );
        }
    }
}