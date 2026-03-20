using LMS.Application.Shared.Models;
using LMS.Application.Dtos.Book;
using LMS.Domain.Entities;

namespace LMS.Application;

public interface ITrendingBooksService
{

    Task<ApiResult<pagedResult<GetBookDto>>> GetAllTrendingBooksAsync(BookParams bookParams);

    Task<ApiResult> SetTrendingBookAsync(int bookId);
}
