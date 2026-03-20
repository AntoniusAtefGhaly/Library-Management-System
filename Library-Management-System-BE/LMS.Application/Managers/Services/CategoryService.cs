using LMS.Application.Dtos;
using LMS.Application.Dtos.Author;
using LMS.Application.Dtos.Book;
using LMS.Application.Dtos.Category;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;



namespace LMS.Application;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHelperService _helperService;
    private readonly ICurrentUserService _currentUserService;
    private readonly IReportService _reportService;

    public CategoryService(
        IUnitOfWork unitOfWork,
        IHelperService helperService,
        ICurrentUserService currentUserService, IReportService reportService) {
        _reportService = reportService;
        _unitOfWork = unitOfWork;
        _helperService = helperService;
        _currentUserService = currentUserService;

    }
    public async Task<pagedResult<Category>> GetAllCategoriesAsync(CategoryParams categoryParams)
    {
        return await _unitOfWork.CategoryRepository.GetAllCategoriesAsync(categoryParams.first, categoryParams.rows, categoryParams.sortOrder, categoryParams.sortField, categoryParams.Search, categoryParams.isActive); 
    }
    public async Task<ApiResult<List<GetCategoryDto>>> GetAllCategoriesAsync()
    {
        try
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllCategoriesWithBooks();
            var categoryList = categories.Select(c => new GetCategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                BooksCount = c.Books.Count(),
                ImageUrl = c.ImageUrl,

            }).ToList();

            return new ApiResult<List<GetCategoryDto>> { IsSuccess = true, Data = categoryList };
        }
        catch (Exception ex)
        {
            return new ApiResult<List<GetCategoryDto>> { IsSuccess = false, Message = ex.Message };
        }
    }
    public async Task<byte[]> ExportToExcel() { return await _reportService.ExportCategoriesAsync(); }
    public async Task<ApiResult> GetCategoryByIdAsync(int id)
    {
        try
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
                return new ApiResult { IsSuccess = false, Message = "Category not found" };

            return new ApiResult
            {
                IsSuccess = true,
                Data = new GetCategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    ImageUrl = category.ImageUrl
                }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> AddCategoryAsync(AddCategoryDto request, HttpContext httpContext)
    {
        try
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description,
                InsertedUserId = _currentUserService.UserId,
                InsertedTime = DateTime.Now,
            };
            if (request.ImageUrl is not null)
            {
                category.ImageUrl = await _helperService.SaveFileAsync(request.ImageUrl, "Categories");
            }

            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = "Category created successfully" };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> UpdateCategoryAsync(UpdateCategoryDto request, HttpContext httpContext)
    {
        try
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
            if (category == null)
                return new ApiResult { IsSuccess = false, Message = "Category not found" };

            category.Name = request.Name ?? category.Name;
            category.Description = request.Description ?? category.Description;
            category.ImageUrl = request.ImageUrl is not null ? await _helperService.SaveFileAsync(request.ImageUrl, "Categories") : category.ImageUrl;
            category.UpdateTime = DateTime.Now;
            category.UpdateUserId = _currentUserService.UserId;


            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = "Category updated successfully", Data = category };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> DeleteCategoryAsync(int id)
    {
        try
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
                return new ApiResult { IsSuccess = false, Message = "Category not found" };

            await _unitOfWork.CategoryRepository.DeleteAsync(category, _currentUserService.UserId!);
            return new ApiResult { IsSuccess = true, Message = "Category marked as deleted" };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> ActivateOrDeactivateCategoryAsync(int id)
    {
        try
        {

            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category is null)
                return new ApiResult { IsSuccess = false, Message = "Category not found" };

            category.ActivationTime = DateTime.Now;
            category.IsActive = !category.IsActive;


            _unitOfWork.CategoryRepository.Update(category);
            var result = await _unitOfWork.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = $"Category {(category.IsActive ? "activated" : "deactivated")} successfully", };

        }
        catch (Exception e)
        {
            return new ApiResult { IsSuccess = false, Message = e.Message };
        }
    }
}
