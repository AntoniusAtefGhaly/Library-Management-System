using LMS.Application.Dtos;
using LMS.Application.Dtos.User;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace LMS.Application;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEncryptionService _encryptionService;
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _manager;
    private readonly IHelperService _helperService;
    public UserService(
        IUnitOfWork unitOfWork,
        IEncryptionService encryptionService,
        IConfiguration configuration,
         UserManager<User> manager,
         IHelperService helperService)
    {
        _unitOfWork = unitOfWork;
        _encryptionService = encryptionService;
        _configuration = configuration;
        _manager = manager;
        _helperService = helperService;
    }

    public async Task<ApiResult> RegisterUserAsync(UserRegisterDto registerCredientials)
    {
        try
        {
            if (registerCredientials is null)
            {
                return new ApiResult { Message = "Invalid Date Provided!!!", IsSuccess = false, };
            }
            //chcek email by id in db

            User user = new()
            {
                Email = registerCredientials.Email.Trim(),
                FirstName = registerCredientials.FirstName.Trim(),
                LastName = registerCredientials.LastName.Trim(),
                UserName = registerCredientials.Email,
                PhoneNumber = registerCredientials.PhoneNumber,
                Role = Roles.Member.ToString(),
                InsertedTime = DateTime.Now,
                IsActive = true,
            };

            await _unitOfWork.UserRepository.AddAsync(user);

            var createUserResult = await _manager.CreateAsync(user, registerCredientials.Password);
            if (!createUserResult.Succeeded)
            {
                return new ApiResult { ErrorList = createUserResult.Errors.Select(x => new ApiError { Key = x.Code, Message = x.Description }).ToList(), IsSuccess = false, };
            }

            List<Claim> claims = new()
            {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Email, user.Email.ToString()),
                 new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            var claimsResult = await _manager.AddClaimsAsync(user, claims);
            if (!claimsResult.Succeeded)
            {
                return new ApiResult { ErrorList = claimsResult.Errors.Select(x => new ApiError { Key = x.Code, Message = x.Description }).ToList(), IsSuccess = false, };
            }

            await _unitOfWork.SaveChangesAsync();
            return new ApiResult
            {
                Message = "Register Successfully",
                IsSuccess = true,
                Data = new GetUserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = user.Role,
                    PhoneNumber = user.PhoneNumber,
                }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult { Message = ex.Message, IsSuccess = false, };
        }
    }
    public async Task<byte[]> ExportToExcel(List<SelectedFilters> selectedFilters)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage())
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            List<UserExcellData> userExcelDataList = users.Select(u => new UserExcellData() { FirstName = u.FirstName, LastName = u.LastName, Address = u.Address, DateOfBirth = u.DateOfBirth?.ToString("d"), Email = u.Email, PhoneNumber = u.PhoneNumber }).ToList();
            var stream = new MemoryStream();
            var UsersSheet = package.Workbook.Worksheets.Add("Books");
            UsersSheet.Row(1).Height = 35;
            UsersSheet.Row(1).Style.Locked = true;
            // Unlock all cells
            UsersSheet.Cells.Style.Locked = false;
            UsersSheet.Cells[1, 1, 1, selectedFilters.Count].Style.Locked = true;
            // Protect the sheet
            UsersSheet.Cells[1, 1, 1, selectedFilters.Count].Style.Locked = true;
            UsersSheet.Protection.IsProtected = true;
            UsersSheet.Protection.SetPassword("54321");
            UsersSheet.Protection.AllowSelectLockedCells = true;
            UsersSheet.Protection.AllowSelectUnlockedCells = true;
            UsersSheet.Columns[1, 10].Width = 20;
            UsersSheet.Row(1).Style.Font.Size = 15;
            UsersSheet.Row(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            UsersSheet.Row(1).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            UsersSheet.Cells[1, 1, 1, selectedFilters.Count].Style.Fill.PatternType = ExcelFillStyle.Solid;
            UsersSheet.Cells[1, 1, 1, selectedFilters.Count].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
            UsersSheet.Row(1).Style.Font.Bold = true;
            // set columns headers
            for (int i = 0; i < selectedFilters.Count; i++)
            {
                UsersSheet.Cells[1, i + 1].Value = selectedFilters[i].name;
            }
            // set Users Records
            var row = 2;
            List<string> list = new List<string>();
            for (int b = 0; b < userExcelDataList?.Count(); b++)
            {
                for (int i = 0; i < selectedFilters.Count; i++)
                {

                    var bookType = userExcelDataList[b].GetType();
                    var property = bookType.GetProperty(selectedFilters[i].name);
                    if (property != null) UsersSheet.Cells[row, i + 1].Value = property.GetValue(userExcelDataList[b]);
                }
                row++;
            }
            // Auto-fit columns
            UsersSheet.Cells.AutoFitColumns();
            return package.GetAsByteArray();
        }
    }
    public async Task<ApiResult> LoginAsync(UserLoginDto loginCredentials)
    {
        try
        {
            if (loginCredentials is null)
            {
                return new ApiResult { Message = "invalid credentials!!!", IsSuccess = false, };
            }

            User? _user = await _manager.FindByEmailAsync(loginCredentials.Email);
            if (_user is null)
            {
                return new ApiResult { Message = "invalid credentials!!!", IsSuccess = false, };
            }

            if (!_user.IsActive)
            {
                return new ApiResult { Message = "User Not Active", IsSuccess = false, };
            }

            bool _isValiduser = await _manager.CheckPasswordAsync(_user, loginCredentials.Password);
            if (!_isValiduser)
            {
                return new ApiResult { Message = "invalid credentials", IsSuccess = false, };
            }

            // Get claims
            var _claims = await _manager.GetClaimsAsync(_user);
            if (_claims is null || _claims.Count == 0)
            {
                return new ApiResult { Message = "invalid credentials", IsSuccess = true, };
            }

            var _token = GenerateUserTokenAsync(_claims);

            return new ApiResult
            {
                Message = "User Logged in Successfully",
                IsSuccess = true,
                Data = new TokenDto
                {
                    UserId = _user.Id,
                    Role = _user.Role,
                    Email = _user.Email!,
                    FirstName = _user.FirstName,
                    LastName = _user.LastName,
                    UserImageUrl = _user.ProfileImageUrl,
                    ExpiresIn = _token.Expires,
                    Token = _token.Token,
                },
            };
        }
        catch (Exception ex)
        {
            return new ApiResult { Message = ex.Message, IsSuccess = false, };
        }
    }

    public async Task<ApiResult> GetAllUsersAsync()
    {
        try
        {
            var users = (await _unitOfWork.UserRepository.GetAllAsync()).Select(u => new GetUserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Role = u.Role,
                IsActive = u.IsActive,
                PhoneNumber = u.PhoneNumber,
                ProfileImageUrl = u.ProfileImageUrl
            }).ToList();

            return new ApiResult { IsSuccess = true, Data = users };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }
    public async Task<ApiResult> GetAllRolesAsync()
    {
        try
        {
            var roles = Enum.GetNames(typeof(Roles)).ToList();
            return new ApiResult { IsSuccess = true, Data = roles };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> AddRoleToUserAsync(UserRoleDto request)
    {
        try
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(int.Parse(request.UserId));
            if (user == null)
            {
                return new ApiResult { IsSuccess = false, Message = "User not found." };
            }

            // Update the role directly in the user table
            user.Role = request.Role;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return new ApiResult { IsSuccess = true, Message = "Role updated successfully." };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> RemoveRoleFromUserAsync(UserRoleDto request)
    {
        try
        {
            var user = await _manager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return new ApiResult { IsSuccess = false, Message = "User not found." };
            }

            var result = await _manager.RemoveFromRoleAsync(user, request.Role);
            if (!result.Succeeded)
            {
                return new ApiResult { IsSuccess = false, ErrorList = result.Errors.Select(e => new ApiError { Key = e.Code, Message = e.Description }).ToList() };
            }

            return new ApiResult { IsSuccess = true, Message = "Role removed successfully." };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> ActivateDeactivateUserAsync(ToggleUserActivationDto request)
    {
        try
        {
            var user = await _manager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return new ApiResult { IsSuccess = false, Message = "User not found." };
            }

            user.IsActive = request.IsActive;
            var result = await _manager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return new ApiResult { IsSuccess = false, ErrorList = result.Errors.Select(e => new ApiError { Key = e.Code, Message = e.Description }).ToList() };
            }

            return new ApiResult { IsSuccess = true, Message = $"User {(request.IsActive ? "activated" : "deactivated")} successfully." };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    private (string Token, long Expires) GenerateUserTokenAsync(IList<Claim> claims)
    {
        string? secretKey = _configuration.GetSection("SecretKey").Value;
        byte[] keyAsBytes = Encoding.ASCII.GetBytes(secretKey!);
        SymmetricSecurityKey key = new(keyAsBytes);

        SigningCredentials signingCredentials = new(key, SecurityAlgorithms.HmacSha256Signature);

        DateTime exp = DateTime.Now.AddMinutes(1000);
        DateTimeOffset dateTimeOffset = new DateTimeOffset(exp);
        var expires = dateTimeOffset.ToUnixTimeSeconds();
        JwtSecurityToken jwtSecurity = new(claims: claims, signingCredentials: signingCredentials, expires: exp);

        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
        return (jwtSecurityTokenHandler.WriteToken(jwtSecurity), expires);
    }

    public async Task<ApiResult> AddUserAsync(AddUserDto userDto, HttpContext httpContext)
    {
        try
        {
            if (userDto is null)
            {
                return new ApiResult { Message = "Invalid data provided!", IsSuccess = false };
            }

            // Generate a random password
            //            string generatedPassword = GenerateRandomPassword(12);
            string generatedPassword = "Pass@123";

            User user = new()
            {
                Email = userDto.Email.Trim(),
                FirstName = userDto.FirstName.Trim(),
                LastName = userDto.LastName.Trim(),
                UserName = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                Role = userDto.Role,
                InsertedTime = DateTime.Now,
                IsActive = true,
            };
            if (userDto.ProfileImageUrl is not null)
            {
                user.ProfileImageUrl = await _helperService.SaveFileAsync(userDto.ProfileImageUrl, "Users", httpContext);
            }
            // Save user in the repository
            await _unitOfWork.UserRepository.AddAsync(user);

            // Create the user with the generated password
            var createUserResult = await _manager.CreateAsync(user, generatedPassword);
            if (!createUserResult.Succeeded)
            {
                return new ApiResult
                {
                    ErrorList = createUserResult.Errors.Select(x => new ApiError { Key = x.Code, Message = x.Description }).ToList(),
                    IsSuccess = false
                };
            }

            // Assign claims
            List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };

            var claimsResult = await _manager.AddClaimsAsync(user, claims);
            if (!claimsResult.Succeeded)
            {
                return new ApiResult
                {
                    ErrorList = claimsResult.Errors.Select(x => new ApiError { Key = x.Code, Message = x.Description }).ToList(),
                    IsSuccess = false
                };
            }

            await _unitOfWork.SaveChangesAsync();
            return new ApiResult
            {
                Message = "User added successfully with a generated password.",
                IsSuccess = true,
                Data = new
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = user.Role,
                    PhoneNumber = user.PhoneNumber,
                    GeneratedPassword = generatedPassword // Include the generated password in response
                }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult { Message = ex.Message, IsSuccess = false };
        }
    }
    private string GenerateRandomPassword(int length)
    {
        const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?";
        Random random = new();
        return new string(Enumerable.Repeat(validChars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public async Task<ApiResult> GetUserById(int id)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
        if (user == null)
        {
            return new ApiResult { IsSuccess = false, Message = $"not found user by id {id}" };
        }
        return new ApiResult { IsSuccess = true, Data = new UserDetailsDto { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, PhoneNumber = user.PhoneNumber, ProfileImageUrl = user.ProfileImageUrl, Address = user.Address, DateofBirth = user.DateOfBirth } };
    }
    public async Task<ApiResult> updateUserProfile(UpdateUserProfileDto updateUserProfile, HttpContext httpContext)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(updateUserProfile.Id);
        if (user == null)
        {
            return new ApiResult { IsSuccess = true };
        }

        user.FirstName = updateUserProfile.FirstName;
        user.LastName = updateUserProfile.LastName;
        user.PhoneNumber = updateUserProfile.PhoneNumber;
        user.Address = updateUserProfile.Address;
        user.DateOfBirth = updateUserProfile.DateOfBirth;
        if (updateUserProfile.ProfileImageUrl != null)
        {
            user.ProfileImageUrl = await _helperService.SaveFileAsync(updateUserProfile.ProfileImageUrl, "Users", httpContext);
        }
        // If Role is provided and different, update it
        if (!string.IsNullOrWhiteSpace(updateUserProfile.Role) && user.Role != updateUserProfile.Role)
        {
            user.Role = updateUserProfile.Role;
        }
        _unitOfWork.UserRepository.Update(user);
        await _unitOfWork.SaveChangesAsync();
        return new ApiResult { IsSuccess = true };
    }

    public async Task<ApiResult> GetAllUsersByRoleAsync(string role)
    {
        try
        {
            var users = (await _unitOfWork.UserRepository.GetAllAsync())
                .Where(u => u.Role == role)
                .Select(u => new GetUserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    PhoneNumber = u.PhoneNumber,
                    ProfileImageUrl = u.ProfileImageUrl
                }).ToList();

            return new ApiResult { IsSuccess = true, Data = users };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> UpdateUserDetailsAsync(UpdateUserDetailsDto updateUserDetails, HttpContext httpContext)
    {
        try
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(updateUserDetails.Id);
            if (user == null)
            {
                return new ApiResult { IsSuccess = false, Message = "User not found" };
            }

            // Update user details
            user.FirstName = updateUserDetails.FirstName.Trim();
            user.LastName = updateUserDetails.LastName.Trim();
            user.PhoneNumber = updateUserDetails.PhoneNumber.Trim();
            user.UserName = user.Email; // Keep username same as email

            // Handle profile image if provided
            if (updateUserDetails.ProfileImage is not null)
            {
                user.ProfileImageUrl = await _helperService.SaveFileAsync((IFormFile)updateUserDetails.ProfileImage, "Users", httpContext);
            }

            // Update the user
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return new ApiResult
            {
                IsSuccess = true,
                Message = "User details updated successfully",
                Data = new GetUserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    ProfileImageUrl = user.ProfileImageUrl,
                    Role = user.Role,
                    IsActive = user.IsActive
                }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }
    public async Task<ApiResult> UpdateUserData(UpdateUserDto UpdateUserDto, HttpContext httpContext)
    {
        try
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(UpdateUserDto.Id);
            if (user == null)
            {
                return new ApiResult { IsSuccess = false, Message = "User not found" };
            }

            // Update user details
            user.FirstName = UpdateUserDto.FirstName.Trim();
            user.LastName = UpdateUserDto.LastName.Trim();
            user.PhoneNumber = UpdateUserDto.PhoneNumber.Trim();
            user.UserName = user.Email; // Keep username same as email
            user.Role = UpdateUserDto.Role.Trim();
            // Handle profile image if provided
            if (UpdateUserDto.ProfileImageUrl is not null)
            {
                user.ProfileImageUrl = await _helperService.SaveFileAsync(UpdateUserDto.ProfileImageUrl, "Users", httpContext);
            }
            //update role
            var existingClaims = await _manager.GetClaimsAsync(user);
            var result = await _manager.RemoveClaimsAsync(user, existingClaims);
            var newClaims = new List<Claim>
                {
                  new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                  new Claim(ClaimTypes.Email, user.Email.ToString()),
                  new Claim(ClaimTypes.Role, UpdateUserDto.Role.ToString()),
             };

            var resultC = await _manager.AddClaimsAsync(user, newClaims);
            // Update the user
            _unitOfWork.UserRepository.Update(user);

            await _unitOfWork.SaveChangesAsync();

            return new ApiResult
            {
                IsSuccess = true,
                Message = "User details updated successfully",
                Data = new GetUserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    ProfileImageUrl = user.ProfileImageUrl,
                    Role = user.Role,
                    IsActive = user.IsActive
                }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

}
