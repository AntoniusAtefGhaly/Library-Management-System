using LMS.Application.Dtos;

namespace LMS.Application.Services
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardAsync(int count = 5);
    }
} 