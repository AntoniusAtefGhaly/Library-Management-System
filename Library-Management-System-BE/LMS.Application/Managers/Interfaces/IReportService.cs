using LMS.Application.Dtos.User;
using LMS.Application.Shared.Models;

namespace LMS.Application;

public interface IReportService
{
    Task<byte[]> GenerateTransactionReportAsync(TransactionReportDto request);
    Task<byte[]> GenerateUserReportAsync(UserReportRequest request);
    Task<byte[]> GenerateUserBorrowingHistoryReportAsync(UserBorrowingHistoryRequest request);
} 