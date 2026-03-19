using LMS.Application;
using LMS.Application.Dtos;
using LMS.Application.Dtos.User;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly UserManager<User> userManager;

    public UserController(IUserService userService, UserManager<User> _userManager)
    {
        _userService = userService;
        userManager = _userManager;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(UserLoginDto loginCredentials)
    {
        var result = await _userService.LoginAsync(loginCredentials);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPost("changePassword")]
    [Authorize]
    public async Task<ActionResult> changePassword(ChangePasswordDto changePasswordDto)
    {
        var userId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userId != null)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await userManager.ChangePasswordAsync(user, changePasswordDto.currentPassword, changePasswordDto.newPassword);
                return result.Succeeded ? Ok(result) : BadRequest(result);
            }
        }
        return BadRequest();

    }
    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto registerCredentials)
    {
        var result = await _userService.RegisterUserAsync(registerCredentials);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("GetAllUsers")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _userService.GetAllUsersAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("GetAllRoles")]

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllRoles()
    {
        var result = await _userService.GetAllRolesAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost("AddRoleToUser")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddRoleToUser([FromBody] UserRoleDto request)
    {
        var result = await _userService.AddRoleToUserAsync(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPost("ExportToExcel")]
    public async Task<ActionResult> ExportToExcel(List<SelectedFilters> selectedFilters)
    {
        try
        {
            var stream = await _userService.ExportToExcel(selectedFilters);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserRecords");
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    [HttpPost("RemoveRoleFromUser")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveRoleFromUser([FromBody] UserRoleDto request)
    {
        var result = await _userService.RemoveRoleFromUserAsync(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost("ActivateDeactivateUser")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ToggleUserActivation([FromBody] ToggleUserActivationDto request)
    {
        var result = await _userService.ActivateDeactivateUserAsync(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost("AddUserWithDefaultPassword")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddUser([FromForm] AddUserDto request)
    {
        var result = await _userService.AddUserAsync(request,HttpContext);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpGet("GetCurrentUserDetails")]
    [Authorize]
    public async Task<ActionResult> GetUserById()
    {
        var userId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userId != null)
        {
            var result = await _userService.GetUserById(int.Parse(userId));
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        return BadRequest();
    }
    [HttpPut]
    [Authorize]
    public async Task<ActionResult> updateUserProfile([FromForm] UpdateUserProfileDto updateUserProfile)
    {
        var result = await _userService.GetUserById(updateUserProfile.Id);
        if (result.IsSuccess)
        {
            await _userService.updateUserProfile(updateUserProfile, HttpContext);
        }
        return result.IsSuccess ? Ok(result) : BadRequest(result);

    }

    [HttpGet("GetAllUsersByRole/{role}")]
    [Authorize(Roles = "Admin,Librarian")]
    public async Task<IActionResult> GetAllUsersByRole(string role)
    {
        var result = await _userService.GetAllUsersByRoleAsync(role);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut("Profile")]
    [Authorize]
    public async Task<IActionResult> UpdateUserDetails([FromForm] UpdateUserDetailsDto updateUserDetails)
    {
        var userId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userId == null || int.Parse(userId) != updateUserDetails.Id)
        {
            return BadRequest(new ApiResult { IsSuccess = false, Message = "You can only update your own details" });
        }

        var result = await _userService.UpdateUserDetailsAsync(updateUserDetails, HttpContext);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPut("admin")]
    [Authorize]
    public async Task<IActionResult> UpdateUserData([FromForm] UpdateUserDto Userdata)
    {
        var userId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
       

        var result = await _userService.UpdateUserData(Userdata, HttpContext);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

}
