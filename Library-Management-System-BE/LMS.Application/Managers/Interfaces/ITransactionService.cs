using LMS.Application.Dtos;
using LMS.Application.Dtos.Transaction;
using LMS.Application.Shared.Models;

namespace LMS.Application;

public interface ITransactionService
{
    Task<ApiResult> GetAllTransactionsAsync();
    Task<ApiResult> GetTransactionByIdAsync(string id);
    Task<ApiResult> GetTransactionsByUserIdAsync(int userId);
    Task<ApiResult> GetCurrentUserTransactionsAsync();
    Task<ApiResult> AddTransactionAsync(AddTransactionDto request);
    Task<ApiResult> UpdateTransactionAsync(UpdateTransactionDto request);
    Task<ApiResult> DeleteTransactionAsync(string id);
    Task<ApiResult> BorrowBookAsync(BorrowBookDto request);
    Task<ApiResult> IssueBookAsync(IssueBookDto request);

    Task<ApiResult> ReturnBookAsync(ReturnBookDto request);
    Task<byte[]> ExportToExcel(List<SelectedFilters> selectedFilters);
    Task<byte[]> GenerateTransactionReportAsync(TransactionReportDto request);
    Task<int> SendOverdueNotificationsAsync();
    Task<int> SendIssuedBookRemindersAsync(string transactionId);
    Task<ApiResult> ChangeTransactionStatusAsync(ChangeTransactionStatusDto request);
}
