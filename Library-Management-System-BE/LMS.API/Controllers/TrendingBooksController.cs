using LMS.Application;
using LMS.Application.Dtos.Book;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[Route("api/trending-books")]
[ApiController]
public class TrendingBooksController : ControllerBase
{
    private readonly ITrendingBooksService _trendingBooksService;

    public TrendingBooksController(ITrendingBooksService trendingBooksService)
    {
        _trendingBooksService = trendingBooksService;
    }

    [HttpGet("paged")]
    public async Task<ActionResult> GetAllTrendingBooks([FromQuery] BookParams bookParams)
    {
        var result = await _trendingBooksService.GetAllTrendingBooksAsync(bookParams);      
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost("{bookId}")]
    public async Task<IActionResult> SetTrendingBook(int bookId)
    {
        var result = await _trendingBooksService.SetTrendingBookAsync(bookId);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
