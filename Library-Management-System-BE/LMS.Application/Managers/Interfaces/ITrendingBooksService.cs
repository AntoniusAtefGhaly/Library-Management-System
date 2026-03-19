using LMS.Application.Shared.Models;
using LMS.Domain.Entities;

namespace LMS.Application;

public interface ITrendingBooksService
{

    Task<ApiResult<pagedResult<GetBookDto>>> GetAllTrendingBooksAsync(int first, int rows, int sortOrder, string? sortField, string? Search, int? categoryId, int? authorId);

    Task<ApiResult> SetTrendingBookAsync(int bookId);
}
