using LMS.Application;
using LMS.Application.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Infrastructure;
using LMS.Application.Dtos.Transaction;
using LMS.Application.Dtos;
using Hangfire;

namespace LMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;
    private readonly IBackgroundJobClient _backgroundJobClient;

    public TransactionController(ITransactionService transactionService, IBackgroundJobClient backgroundJobClient)
    {
        _transactionService = transactionService;
        _backgroundJobClient = backgroundJobClient;
    }

    [HttpGet("GetAllTransactions")]
    [Authorize(Roles = "Admin,Librarian")]
    public async Task<IActionResult> GetAllTransactions()
    {
        var result = await _transactionService.GetAllTransactionsAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPost("IssueBook")]
    [Authorize(Roles = "Admin,Librarian")]
    public async Task<IActionResult> IssueBook(IssueBookDto request)
    {
        var result = await _transactionService.IssueBookAsync(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPost("ReturnBook")]
    [Authorize(Roles = "Admin,Librarian")]
    public async Task<IActionResult> ReturnBook(ReturnBookDto request)
    {
        var result = await _transactionService.ReturnBookAsync(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("GetTransactionById/{id}")]
    [Authorize(Roles = "Admin,Librarian")]
    public async Task<IActionResult> GetTransactionById(string id)
    {
        var result = await _transactionService.GetTransactionByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost("AddTransaction")]
    [Authorize(Roles = "Admin,Librarian")]
    public async Task<IActionResult> AddTransaction(AddTransactionDto request)
    {
        var result = await _transactionService.AddTransactionAsync(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut("UpdateTransaction")]
    public async Task<IActionResult> UpdateTransaction(UpdateTransactionDto request)
    {
        var result = await _transactionService.UpdateTransactionAsync(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPost("ExportToExcel")]
    public async Task<ActionResult> ExportToExcel(List<SelectedFilters> selectedFilters)
    {
        try
        {
            var stream = await _transactionService.ExportToExcel(selectedFilters);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TansactionRecords");
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    [HttpDelete("DeleteTransaction/{id}")]
    public async Task<IActionResult> DeleteTransaction(string id)
    {
        var result = await _transactionService.DeleteTransactionAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("GetTransactionsByUserId/{userId}")]
    [Authorize(Roles = "Admin,Librarian")]
    public async Task<IActionResult> GetTransactionsByUserId(int userId)
    {
        var result = await _transactionService.GetTransactionsByUserIdAsync(userId);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("MyBorrowHistory")]
    [Authorize]
    public async Task<ActionResult<ApiResult>> GetCurrentUserTransactions()
    {
        var result = await _transactionService.GetCurrentUserTransactionsAsync();
        return Ok(result);
    }

    [HttpPost("BorrowBook")]
    [Authorize]
    public async Task<ActionResult<ApiResult>> BorrowBook(BorrowBookDto request)
    {
        var result = await _transactionService.BorrowBookAsync(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost("SendOverdueNotifications")]
    [Authorize(Roles = "Admin")]
    public IActionResult SendOverdueNotifications()
    {
        _backgroundJobClient.Enqueue(() => _transactionService.SendOverdueNotificationsAsync());
        return Ok(new ApiResult { IsSuccess = true, Message = "Overdue notifications job has been successfully queued." });
    }

    [HttpPost("send-issued-book-reminder/{transactionId}")]
    [Authorize(Roles = "Admin,Librarian")]
    public async Task<IActionResult> SendIssuedBookReminders(string transactionId)
    {
        int sent = await _transactionService.SendIssuedBookRemindersAsync(transactionId);
        return Ok(new ApiResult { IsSuccess = true, Message = $"Issued book reminder sent: {sent}" });
    }

    [HttpPut("ChangeStatus")]
    [Authorize(Roles = "Admin,Librarian")]
    public async Task<ActionResult<ApiResult>> ChangeTransactionStatus(ChangeTransactionStatusDto request)
    {
        var result = await _transactionService.ChangeTransactionStatusAsync(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
