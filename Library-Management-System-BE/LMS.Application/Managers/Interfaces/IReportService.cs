using LMS.Application.Dtos.User;
using LMS.Application.Shared.Models;
using LMS.Application.Dtos;

namespace LMS.Application;

public interface IReportService
{
    Task<byte[]> GenerateTransactionReportAsync(TransactionReportDto request);
    Task<byte[]> GenerateUserReportAsync(UserReportRequest request);
    Task<byte[]> GenerateUserBorrowingHistoryReportAsync(UserBorrowingHistoryRequest request);

    // Entity exports
    Task<byte[]> ExportAuthorsAsync();
    Task<byte[]> ExportBooksAsync(List<SelectedFilters> selectedFilters);
    Task<byte[]> ExportCategoriesAsync();
    Task<byte[]> ExportTransactionsAsync(List<SelectedFilters> selectedFilters);
    Task<byte[]> ExportUsersAsync(List<SelectedFilters> selectedFilters);
}