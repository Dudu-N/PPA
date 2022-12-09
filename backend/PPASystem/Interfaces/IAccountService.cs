using Microsoft.AspNetCore.Mvc;
using PPASystem.DTOs;

namespace PPASystem.Interfaces
{
    public interface IAccountService
    {
        Task<UserDto> LoginAsync(LoginDto loginDto);
        Task<ActionResult<UserDto>> Register(RegisterDto registerDto);
    }
}
