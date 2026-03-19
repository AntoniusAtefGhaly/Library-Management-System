using LMS.Application.Dtos;
using LMS.Application.Dtos.Author;
using LMS.Application.Dtos.Book;
using LMS.Application.Dtos.Category;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
namespace LMS.Application;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHelperService _helperService;
    private readonly ICurrentUserService _currentUserService;

    public CategoryService(
        IUnitOfWork unitOfWork,
        IHelperService helperService,
        ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _helperService = helperService;
        _currentUserService = currentUserService;

    }
    public async Task<pagedResult<Category>> GetAllCategoriesAsync(int first, int rows, CategoryParams CategoryParams)
    {
        return await _unitOfWork.CategoryRepository.GetAllCategoriesAsync(first, rows, CategoryParams.sortOrder, CategoryParams.sortField, CategoryParams.Search, CategoryParams.isActive); 
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
    public async Task<byte[]> ExportToExcel()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage())
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            List<Category> categoryList = categories.ToList();
            var stream = new MemoryStream();
            var categoriesSheet = package.Workbook.Worksheets.Add("categories");
            categoriesSheet.Row(1).Height = 35;
            categoriesSheet.Row(1).Style.Locked = true;
            // Unlock all cells
            categoriesSheet.Cells.Style.Locked = false;
            categoriesSheet.Cells[1, 1, 1,2].Style.Locked = true;
            // Protect the sheet
            categoriesSheet.Protection.IsProtected = true;
            categoriesSheet.Protection.SetPassword("54321");
            categoriesSheet.Protection.AllowSelectLockedCells = true;
            categoriesSheet.Protection.AllowSelectUnlockedCells = true;
            categoriesSheet.Columns[1, 10].Width = 20;
            categoriesSheet.Row(1).Style.Font.Size = 15;
            categoriesSheet.Row(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            categoriesSheet.Row(1).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            categoriesSheet.Cells[1, 1, 1,2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            categoriesSheet.Cells[1, 1, 1, 2].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
            categoriesSheet.Row(1).Style.Font.Bold = true;
            // set columns headers           
            categoriesSheet.Cells[1,1].Value = "Name";
            categoriesSheet.Cells[1, 2].Value = "Description";
            // set Book Records
            var row = 2;
            for (int c = 0; c < categoryList.Count(); c++)
            {             
                categoriesSheet.Cells[row, 1].Value = categoryList[c].Name;
                categoriesSheet.Cells[row, 2].Value = categoryList[c].Description;
                row++;
            }
            // Auto-fit columns
            categoriesSheet.Cells.AutoFitColumns();
            return package.GetAsByteArray();
        }
    }
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
                category.ImageUrl = await _helperService.SaveFileAsync(request.ImageUrl, "Categories", httpContext);
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
            category.ImageUrl = request.ImageUrl is not null ? await _helperService.SaveFileAsync(request.ImageUrl, "Categories", httpContext) : category.ImageUrl;
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
