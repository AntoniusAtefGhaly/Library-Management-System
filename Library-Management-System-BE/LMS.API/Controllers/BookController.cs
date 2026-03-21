using System.Drawing;
using LMS.Application;
using LMS.Application.Dtos;
using LMS.Application.Dtos.Book;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.DataValidation;
using OfficeOpenXml.Style;

namespace LMS.API.Controllers;

[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        ApiResult<List<GetBookDto>> result = await _bookService.GetAllBooksAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpGet("export-excel")]
    public async Task<ActionResult> ExportToExcel([FromQuery] List<SelectedFilters> selectedFilters)
    {
        try
        {
            var stream = await _bookService.ExportToExcel(selectedFilters);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BookRecords");
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    [HttpGet("paged")]
    public async Task<ActionResult> GetBooksPaged([FromQuery] BookParams bookParams)
    {
        ApiPagedResult<ReadBookDto> Books = await _bookService.GetBooksPaged(bookParams);
        return Ok(Books);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDetailsDto>> getBookDetailsById(int id)
    {
        var result = await _bookService.getBookDetailsById(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }



    // Combined with getBookDetailsById if needed, but keeping this for now as a simpler retrieval
    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var result = await _bookService.GetBookByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromForm] AddBookDto request)
    {
        var result = await _bookService.AddBookAsync(request, HttpContext);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook([FromForm] UpdateBookDto request)
    {
        var result = await _bookService.UpdateBookAsync(request, HttpContext);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await _bookService.DeleteBookAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id}/toggle-status")]
    public async Task<IActionResult> ActivateOrDeactivateBook(int id)
    {
        var result = await _bookService.ActivateOrDeactivateBookAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpGet("{bookId}/related")]
    public async Task<IActionResult> GetRelatedBooks(int bookId)
    {
        ApiResult<List<GetBookDto>> result = await _bookService.GetBooksByCategoryExceptBookAsync(bookId);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }


}
