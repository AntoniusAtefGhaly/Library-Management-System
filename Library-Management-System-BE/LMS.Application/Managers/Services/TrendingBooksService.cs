using LMS.Application.Shared.Models;

using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
namespace LMS.Application;

public class TrendingBooksService : ITrendingBooksService
{
    private readonly IUnitOfWork _unitOfWork;

    public TrendingBooksService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResult<pagedResult<GetBookDto>>> GetAllTrendingBooksAsync(int first, int rows, int sortOrder, string? sortField, string? Search, int? categoryId, int? authorId)
    {
        try
        {
            pagedResult<GetBookDto> pagedResultDto = new pagedResult<GetBookDto>();
            var trendingbooks = await _unitOfWork.BookRepository.GetWhereIncludeAsync(b => b.IsTrending, "Author");
            var topBorrowIds = await _unitOfWork.TransactionRepository.GetTopBorrowedBooksAsync(20);

            var trendingBookIds = trendingbooks.Select(b => b.Id).ToList();
            topBorrowIds = topBorrowIds.Where(id => !trendingBookIds.Contains(id)).ToList();

            trendingbooks = trendingbooks.Take(20);
            var topBooksCount = 20 - trendingbooks.Count();
            if (topBooksCount > 0)
            {
                var topBorrowBooks = await _unitOfWork.BookRepository.GetWhereIncludeAsync(b => topBorrowIds.Contains(b.Id), "Author");
                trendingbooks = trendingbooks.Concat(topBorrowBooks.Take(topBooksCount)).ToList();
            }

            // Apply search filter
            if (!string.IsNullOrEmpty(Search))
            {
                trendingbooks = trendingbooks.Where(b => 
                    b.Title.Contains(Search, StringComparison.OrdinalIgnoreCase) || 
                    (b.Description != null && b.Description.Contains(Search, StringComparison.OrdinalIgnoreCase)) ||
                    b.Author.FullName.Contains(Search, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            // Apply category filter
            if (categoryId.HasValue)
            {
                trendingbooks = trendingbooks.Where(b => b.CategoryId == categoryId.Value).ToList();
            }

            // Apply author filter
            if (authorId.HasValue)
            {
                trendingbooks = trendingbooks.Where(b => b.AuthorId == authorId.Value).ToList();
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(sortField))
            {
                trendingbooks = sortField.ToLower() switch
                {
                    "title" => sortOrder == 1 ? 
                        trendingbooks.OrderBy(b => b.Title).ToList() : 
                        trendingbooks.OrderByDescending(b => b.Title).ToList(),
                    "publicationyear" => sortOrder == 1 ? 
                        trendingbooks.OrderBy(b => b.PublicationYear).ToList() : 
                        trendingbooks.OrderByDescending(b => b.PublicationYear).ToList(),
                    "author" => sortOrder == 1 ? 
                        trendingbooks.OrderBy(b => b.Author.FullName).ToList() : 
                        trendingbooks.OrderByDescending(b => b.Author.FullName).ToList(),
                    _ => trendingbooks
                };
            }

            var bookList = trendingbooks.Select(b => new GetBookDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                AuthorName = b.Author.FullName,
                PublicationYear = b.PublicationYear,
                AvailableCopies = b.AvailableCopies,
                TotalCopies = b.TotalCopies,
                CategoryId = b.CategoryId,
                ImageUrl = b.ImageUrl,
                authorId = b.AuthorId,
                HasAvailableCopies = b.AvailableCopies > 0
            }).ToList();

            var totalcount = bookList.Count;
            bookList = bookList.Skip(first).Take(rows).ToList();

            pagedResultDto.Result = bookList;
            pagedResultDto.TotalCount = totalcount;
            return new ApiResult<pagedResult<GetBookDto>> { IsSuccess = true, Data = pagedResultDto };
        }
        catch (Exception ex)
        {
            return new ApiResult<pagedResult<GetBookDto>> { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> SetTrendingBookAsync(int bookId)


    {
        try
        {
            var trendingBook = await _unitOfWork.BookRepository.GetByIdAsync(bookId);
            if (trendingBook == null)
            {
                return new ApiResult { IsSuccess = false, Message = "Invalid book", Data = null };

            }
            else
            {
                trendingBook.IsTrending = true;
            }

            await _unitOfWork.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = "Trending book updated successfully", Data = trendingBook };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }


}
