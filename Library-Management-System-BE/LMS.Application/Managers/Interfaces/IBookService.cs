using LMS.Application.Dtos;
using LMS.Application.Dtos.Book;
using LMS.Application.Shared.Models;

using LMS.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace LMS.Application;

public interface IBookService
{
    Task<ApiResult<List<GetBookDto>>> GetAllBooksAsync();
    Task<ApiResult<List<BookWithDetailsDto>>> getAllBooksWithAuthorandCategory();
    Task<ApiResult> GetBookByIdAsync(int id);
    Task<ApiResult<BookDetailsDto>> getBookDetailsById(int id);
    Task<ApiResult> AddBookAsync(AddBookDto request, HttpContext httpContext);
    Task<ApiResult> UpdateBookAsync(UpdateBookDto request, HttpContext httpContext);
    Task<ApiResult> DeleteBookAsync(int id);
    Task<ApiResult> ActivateOrDeactivateBookAsync(int id);
    Task<ApiResult<List<GetBookDto>>> GetBooksByCategoryExceptBookAsync(int bookId);
    Task<byte[]> ExportToExcel(List<SelectedFilters> selectedFilters);
    Task<ApiResult<pagedResult<ReadBookDto>>> GetBooksPaged(int first, int rows, int sortOrder, string? sortField, string? Search, int? categoryId, int? authorId);
}
