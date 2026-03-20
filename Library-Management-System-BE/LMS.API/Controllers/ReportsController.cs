using LMS.Application;
using LMS.Application.Dtos.User;
using LMS.Application.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[Route("api/reports")]
public class ReportsController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("transactions")]
    [Authorize(Roles = "Admin,Librarian")]
    public async Task<IActionResult> DownloadTransactionReport([FromQuery] TransactionReportDto request)
    {
        try
        {
            var reportBytes = await _reportService.GenerateTransactionReportAsync(request);
            
            string fileName;
            if (request.StartDate.HasValue && request.EndDate.HasValue)
            {
                fileName = $"TransactionReport_{request.StartDate:yyyy-MM-dd}_to_{request.EndDate:yyyy-MM-dd}.xlsx";
            }
            else
            {
                fileName = "TransactionReport_All.xlsx";
            }

            return File(reportBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("users")]
    [Authorize(Roles = "Admin,Librarian")]
    public async Task<IActionResult> DownloadUserReport([FromQuery] UserReportRequest request)
    {
        try
        {
            var reportBytes = await _reportService.GenerateUserReportAsync(request);
            
            string fileName;
            if (request.StartDate.HasValue && request.EndDate.HasValue)
            {
                fileName = $"UserReport_{request.StartDate:yyyy-MM-dd}_to_{request.EndDate:yyyy-MM-dd}.xlsx";
            }
            else
            {
                fileName = "UserReport_All.xlsx";
            }

            return File(reportBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("users/borrowing-history")]
    [Authorize(Roles = "Admin,Librarian")]
    public async Task<IActionResult> DownloadUserBorrowingHistory([FromQuery] UserBorrowingHistoryRequest request)
    {
        try
        {
            var reportBytes = await _reportService.GenerateUserBorrowingHistoryReportAsync(request);
            
            string fileName;
            if (request.StartDate.HasValue && request.EndDate.HasValue)
            {
                fileName = $"UserBorrowingHistory_{request.UserId}_{request.StartDate:yyyy-MM-dd}_to_{request.EndDate:yyyy-MM-dd}.xlsx";
            }
            else
            {
                fileName = $"UserBorrowingHistory_{request.UserId}_All.xlsx";
            }

            return File(reportBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
} 