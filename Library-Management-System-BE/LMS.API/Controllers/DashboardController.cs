using LMS.Application.Dtos;
using LMS.Application.Services;
using LMS.Application.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<ActionResult<DashboardDto>> GetDashboardData([FromQuery] int? count = 5)
        {
            var result = await _dashboardService.GetDashboardAsync(count ?? 5);
            return Ok(new ApiResult<DashboardDto> { IsSuccess = true, Data =result});
        }

    }
} 