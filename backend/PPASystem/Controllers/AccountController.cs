using Microsoft.AspNetCore.Mvc;
using PPASystem.DTOs;
using PPASystem.Entities;
using PPASystem.Interfaces;
using PPASystem.Services;
using System.Security.Cryptography;
using System.Text;
using static PPASystem.Entities.Subscription;

namespace PPASystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost, Route("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            try
            {
                return await _accountService.LoginAsync(loginDto);
            }
            catch (InvalidDataException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost, Route("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            try
            {
                return await _accountService.Register(registerDto);
            }
            catch (InvalidDataException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
