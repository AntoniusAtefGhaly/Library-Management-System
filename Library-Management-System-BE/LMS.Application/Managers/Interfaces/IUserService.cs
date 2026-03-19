using LMS.Application.Dtos.Book;
using LMS.Application.Dtos;
using LMS.Application.Dtos.User;
using LMS.Application.Shared.Models;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Drawing;
using System.Threading.Tasks;

namespace LMS.Application
{
    public interface IUserService
    {
        Task<ApiResult> GetAllUsersAsync();
        Task<ApiResult> GetAllUsersByRoleAsync(string role);
        Task<ApiResult> RegisterUserAsync(UserRegisterDto registerCredientials);
        Task<ApiResult> LoginAsync(UserLoginDto loginCredientials);
        Task<ApiResult> GetAllRolesAsync();
        Task<ApiResult> AddRoleToUserAsync(UserRoleDto updateUserRoleDto);
        Task<ApiResult> RemoveRoleFromUserAsync(UserRoleDto updateUserRoleDto);
        Task<byte[]> ExportToExcel(List<SelectedFilters> selectedFilters);
        Task<ApiResult> ActivateDeactivateUserAsync(ToggleUserActivationDto updateUserStatusDto);
        Task<ApiResult> AddUserAsync(AddUserDto userDto,HttpContext httpContext);
        Task<ApiResult> GetUserById(int id);
        Task<ApiResult> updateUserProfile(UpdateUserProfileDto updateUserProfile,HttpContext httpContext);
        Task<ApiResult> UpdateUserDetailsAsync(UpdateUserDetailsDto updateUserDetails, HttpContext httpContext);
        Task<ApiResult> UpdateUserData(UpdateUserDto UpdateUserDto, HttpContext httpContext);
    }
}
