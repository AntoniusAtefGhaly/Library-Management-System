using LMS.Application;
using LMS.Application.Dtos;
using LMS.Application.Dtos.Author;
using LMS.Application.Dtos.Category;
using LMS.Application.Shared.Models;
using LMS.Infrastructure;
using LMS.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpPost("{first}/{rows}")]
    public async Task<ActionResult<ApiResult>> GettAllAuthorsPaged(int first, int rows, CategoryParams categoryParams)
    {
        try
        {
            pagedResult<Category> authors = await _categoryService.GetAllCategoriesAsync(first, rows, categoryParams);
            return Ok(new ApiResult { IsSuccess = true, Data = authors });
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }
    [HttpGet("GetAllCategories")]
    public async Task<IActionResult> GetAllCategories()
    {
        ApiResult<List<GetCategoryDto>> result = await _categoryService.GetAllCategoriesAsync();    
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("GetCategoryById/{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var result = await _categoryService.GetCategoryByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost("AddCategory")]
    public async Task<IActionResult> AddCategory([FromForm] AddCategoryDto request)
    {
        var result = await _categoryService.AddCategoryAsync(request, HttpContext);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpGet("ExportToExcel")]
    public async Task<ActionResult> ExportToExcel()
    {
        try
        {
            var stream = await _categoryService.ExportToExcel();
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CategoryRecords");
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("UpdateCategory")]
    public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryDto request)
    {
        var result = await _categoryService.UpdateCategoryAsync(request, HttpContext);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var result = await _categoryService.DeleteCategoryAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut("ActivateOrDeactivateCategory/{id}")]
    public async Task<IActionResult> ActivateOrDeactivateCategory(int id)
    {
        var result = await _categoryService.ActivateOrDeactivateCategoryAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
