using LMS.Application.Dtos;
using LMS.Application.Dtos.Book;
using LMS.Application.Shared.Models;

using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;



namespace LMS.Application;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHelperService _helperService;
    private readonly ICurrentUserService _currentUserService;
    private readonly IReportService _reportService;

    public BookService(
        IUnitOfWork unitOfWork,
        IHelperService helperService,
        ICurrentUserService currentUserService, IReportService reportService) {
        _reportService = reportService;
        _unitOfWork = unitOfWork;
        _helperService = helperService;
        _currentUserService = currentUserService;

    }
    public async Task<ApiResult<List<BookWithDetailsDto>>> getAllBooksWithAuthorandCategory()
    {
        try
        {
            var books = await _unitOfWork.BookRepository.getAllBooksWithAuthorandCategory();
            List<BookWithDetailsDto> booksWithDetails = books.Select(b => new BookWithDetailsDto() { 
                Title = b.Title, 
                Description = b.Description, 
                PublicationYear = b.PublicationYear, 
                AvailableCopies = b.AvailableCopies, 
                TotalCopies = b.TotalCopies, 
                Category = b.Category.Name, 
                Author = b.Author.FullName,
                HasAvailableCopies = b.AvailableCopies > 0
            }).ToList();
            return new ApiResult<List<BookWithDetailsDto>> { IsSuccess = true, Data = booksWithDetails };
        }
        catch (Exception ex)
        {
            return new ApiResult<List<BookWithDetailsDto>> { IsSuccess = false, Message = ex.Message };
        }
    }
    public async Task<byte[]> ExportToExcel(List<SelectedFilters> selectedFilters) { return await _reportService.ExportBooksAsync(selectedFilters); }
    public async Task<ApiResult<List<GetBookDto>>> GetAllBooksAsync()
    {
        try
        {
            var books = await _unitOfWork.BookRepository.getAllBooksWithAuthor();
            var bookList = books.Select(b => new GetBookDto
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

            return new ApiResult<List<GetBookDto>> { IsSuccess = true, Data = bookList };
        }
        catch (Exception ex)
        {
            return new ApiResult<List<GetBookDto>> { IsSuccess = false, Message = ex.Message };
        }
    }
    public async Task<ApiPagedResult<ReadBookDto>> GetBooksPaged(BookParams bookParams)
    {
        try
        {
            ApiPagedResult<ReadBookDto> pagedResultDto = new ApiPagedResult<ReadBookDto>();
            var pagedResult = await _unitOfWork.BookRepository.
                GetBooksPaged(bookParams.pageNumber, bookParams.pageSize, bookParams.sortOrder, bookParams.sortField, bookParams.Search, bookParams.categoryId, bookParams.authorId);
            pagedResultDto.Data = pagedResult.Result.Select(b => new ReadBookDto()
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                CoverImageUrl = b.ImageUrl,
                AuthorId = b.Author.Id,
                AuthorFullName = b.Author.FullName,
                AuthorImage = b.Author.ImageUrl,
                AvailableCopies = b.AvailableCopies,
                CategoryId = b.CategoryId,
                CategoryName = b.Category.Name,
                PublicationYear = b.PublicationYear,
                TotalCopies = b.TotalCopies,
                IsTrending = b.IsTrending,
                HasAvailableCopies = b.AvailableCopies > 0
            }).ToList();
            pagedResultDto.TotalCount = pagedResult.TotalCount;
            pagedResultDto.PageNumber = bookParams.pageNumber;
            pagedResultDto.PageSize = bookParams.pageSize;
            pagedResultDto.IsSuccess = true;
            return pagedResultDto;
        }
        catch (Exception ex)
        {
            return new ApiPagedResult<ReadBookDto> { IsSuccess = false, Message = ex.Message };
        }
    }
    public async Task<ApiResult<BookDetailsDto>> getBookDetailsById(int id)
    {
        try
        {
            var book = await _unitOfWork.BookRepository.getBookDetailsById(id);
            if (book == null)
            {
                return new ApiResult<BookDetailsDto>() { IsSuccess = false, Message = $"Not found any book by this Id {id}" };
            }

            // Check if the current user has any active transactions for this book
            bool IsBorrowed = false;
            if (_currentUserService.UserId != null)
            {
                var userId = int.Parse(_currentUserService.UserId);
                IsBorrowed = await _unitOfWork.TransactionRepository.AnyAsync(t =>
                                        t.UserId == userId &&
                                        t.BookId == id &&
                                        t.Status == TransactionStatus.Returned.ToString());

            }

            return new ApiResult<BookDetailsDto>()
            {
                IsSuccess = true,
                Data = new BookDetailsDto()
                {
                    Title = book.Title,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl,
                    PublicationYear = book.PublicationYear,
                    AvailableCopies = book.AvailableCopies,
                    TotalCopies = book.TotalCopies,
                    IsBorrowed = IsBorrowed,
                    HasAvailableCopies = book.AvailableCopies > 0,
                    AuthorFullName = book.Author.FullName,
                    AuthorDescription = book.Author.Description,
                    AuthorImageUrl = book.Author.ImageUrl,
                    AuthorDateOfBirth = book.Author.DateOfBirth,
                    CategoryName = book.Category.Name,
                    CategoryDescription = book.Category.Description,
                    CategoryImageUrl = book.Category.ImageUrl
                }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult<BookDetailsDto>() { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> GetBookByIdAsync(int id)
    {
        try
        {
            var book = await _unitOfWork.BookRepository.GetBookWithAuthorByIdAsync(id);
            if (book == null)
            {
                return new ApiResult { IsSuccess = false, Message = "Book not found" };
            }

            // Check if the current user has any active transactions for this book
            bool IsBorrowed = false;
            if (_currentUserService.UserId != null)
            {
                var userId = int.Parse(_currentUserService.UserId);
                var transactions = await _unitOfWork.TransactionRepository.GetAllAsync();
                IsBorrowed = transactions.Any(t =>
                    t.UserId == userId &&
                    t.BookId == id &&
                    (t.Status == TransactionStatus.Issued.ToString() ||
                     t.Status == TransactionStatus.Overdue.ToString()));
            }

            return new ApiResult
            {
                IsSuccess = true,
                Data = new GetBookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    AuthorName = book.Author.FullName,
                    PublicationYear = book.PublicationYear,
                    AvailableCopies = book.AvailableCopies,
                    TotalCopies = book.TotalCopies,
                    CategoryId = book.CategoryId,
                    ImageUrl = book.ImageUrl,
                    IsBorrowed = IsBorrowed,
                    HasAvailableCopies = book.AvailableCopies > 0
                }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }
    public async Task<ApiResult> AddBookAsync(AddBookDto request, HttpContext httpContext)
    {
        try
        {
            var book = new Book
            {
                Title = request.Title,
                Description = request.Description,
                AuthorId = request.AuthorId,
                PublicationYear = request.PublicationYear,
                AvailableCopies = request.AvailableCopies,
                TotalCopies = request.TotalCopies,
                CategoryId = request.CategoryId,
                InsertedUserId = _currentUserService.UserId,
                InsertedTime = DateTime.Now
            };
            if (request.ImageUrl is not null)
            {
                book.ImageUrl = await _helperService.SaveFileAsync(request.ImageUrl, "Books");
            }

            await _unitOfWork.BookRepository.AddAsync(book);
            await _unitOfWork.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = "Book created successfully", Data = book };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> UpdateBookAsync(UpdateBookDto request, HttpContext httpContext)
    {
        try
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);
            if (book == null)
            {
                return new ApiResult { IsSuccess = false, Message = "Book not found" };
            }

            book.Title = request.Title ?? book.Title;
            book.Description = request.Description ?? book.Description;
            book.AuthorId = request.AuthorId;
            book.PublicationYear = request.PublicationYear;
            book.AvailableCopies = request.AvailableCopies;
            book.TotalCopies = request.TotalCopies;
            book.CategoryId = request.CategoryId;
            book.ImageUrl = request.ImageUrl is not null ? await _helperService.SaveFileAsync(request.ImageUrl, "Books") : book.ImageUrl;
            book.UpdateUserId = _currentUserService.UserId;
            book.UpdateTime = DateTime.Now;

            _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = "Book updated successfully", Data = book };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> DeleteBookAsync(int bookId)
    {
        try
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(bookId);
            if (book == null)
            {
                return new ApiResult { IsSuccess = false, Message = "Book not found" };
            }

            await _unitOfWork.BookRepository.DeleteAsync(book, _currentUserService.UserId!);
            return new ApiResult { IsSuccess = true, Message = "Book marked as deleted" };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> ActivateOrDeactivateBookAsync(int id)
    {
        try
        {

            var book = await _unitOfWork.BookRepository.GetByIdAsync(id);
            if (book is null)
            {
                return new ApiResult { IsSuccess = false, Message = "Book not found" };
            }

            book.ActivationTime = DateTime.Now;
            book.IsActive = !book.IsActive;


            _unitOfWork.BookRepository.Update(book);
            var result = await _unitOfWork.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = $"Book {(book.IsActive ? "activated" : "deactivated")} successfully", };

        }
        catch (Exception e)
        {
            return new ApiResult { IsSuccess = false, Message = e.Message };
        }
    }

    public async Task<ApiResult<List<GetBookDto>>> GetBooksByCategoryExceptBookAsync(int bookId)
    {
        try
        {
            var books = await _unitOfWork.BookRepository.GetBooksByCategoryExceptBookAsync(bookId);

            var bookList = books.Select(b => new GetBookDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                AuthorName = b.Author.FullName,
                PublicationYear = b.PublicationYear,
                AvailableCopies = b.AvailableCopies,
                TotalCopies = b.TotalCopies,
                CategoryId = b.CategoryId,
                CategoryName = b.Category.Name ?? "No Category",
                ImageUrl = b.ImageUrl,
                authorId = b.AuthorId,
                HasAvailableCopies = b.AvailableCopies > 0
            }).ToList();

            return new ApiResult<List<GetBookDto>>
            {
                IsSuccess = true,
                Data = bookList,
                Message = bookList.Any() ? "Related books found" : "No related books found in this category"
            };
        }
        catch (Exception ex)
        {
            return new ApiResult<List<GetBookDto>>
            {
                IsSuccess = false,
                Message = $"Error retrieving books: {ex.Message}"
            };
        }
    }
}
