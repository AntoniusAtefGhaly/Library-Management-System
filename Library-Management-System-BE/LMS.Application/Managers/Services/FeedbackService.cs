using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;

namespace LMS.Application;
public class FeedbackService : IFeedbackService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public FeedbackService(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<ApiResult> GetAllFeedbacksAsync()
    {
        try
        {
            var feedbacks = await _unitOfWork.FeedbackRepository.GetAllAsync();
            var feedbackList = feedbacks.Select(f => new GetFeedbackDto
            {
                Id = f.Id,
                UserId = f.UserId,
                BookId = f.BookId,
                Rating = f.Rating,
                Comment = f.Comment
            }).ToList();

            return new ApiResult { IsSuccess = true, Data = feedbackList };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }
    public async Task<ApiResult> GetAllFeedbacksByBookIdAsync(int bookId)
    {
        try
        {
            var feedbacks = await _unitOfWork.FeedbackRepository.GetAllFeedbacksByBookIdAsync(bookId);
            var feedbackList = feedbacks.Select(f => new GetFeedbackDto
            {
                Id = f.Id,
                UserId = f.UserId,
                UserFirstName = f.User?.FirstName ?? "Unknown",
                UserLastName = f.User?.LastName ?? "User",
                BookId = f.BookId,
                Rating = f.Rating,
                Comment = f.Comment
            }).ToList();

            return feedbackList.Any()
                ? new ApiResult { IsSuccess = true, Data = feedbackList }
                : new ApiResult { IsSuccess = true, Message = "No feedbacks found for this book" };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }
    public async Task<ApiResult> AddFeedbackAsync(AddFeedbackDto request)
    {
        try
        {
            var userId = int.Parse(_currentUserService.UserId!);

            // Check if user has borrowed and returned the book
            var hasBorrowed = await _unitOfWork.TransactionRepository.HasUserBorrowedBookAsync(userId, request.BookId);
            if (!hasBorrowed)
            {
                return new ApiResult 
                { 
                    IsSuccess = false, 
                    Message = "You can only review books that you have borrowed and returned" 
                };
            }

            // Check if user has already reviewed this book
            var existingFeedback = (await _unitOfWork.FeedbackRepository.GetAllAsync())
                .FirstOrDefault(f => f.UserId == userId && f.BookId == request.BookId);
            
            if (existingFeedback != null)
            {
                return new ApiResult 
                { 
                    IsSuccess = false, 
                    Message = "You have already reviewed this book" 
                };
            }

            var feedback = new Feedback
            {
                UserId = userId,
                BookId = request.BookId,
                Rating = request.Rating,
                Comment = request.Comment,
                InsertedUserId = _currentUserService.UserId,
                InsertedTime = DateTime.Now
            };

            await _unitOfWork.FeedbackRepository.AddAsync(feedback);
            await _unitOfWork.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = "Feedback created successfully", Data = feedback };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }
}
