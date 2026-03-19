using LMS.Application.Shared.Models;

namespace LMS.Application;

public interface IFeedbackService
{
    Task<ApiResult> GetAllFeedbacksAsync();
    Task<ApiResult> GetAllFeedbacksByBookIdAsync(int bookId);
    Task<ApiResult> AddFeedbackAsync(AddFeedbackDto request);
}
