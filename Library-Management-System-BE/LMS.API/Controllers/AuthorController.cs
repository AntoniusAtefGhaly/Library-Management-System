using LMS.Application.Dtos.Author;
using LMS.Application.Managers.Interfaces;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetAllAuthors()
        {
            try
            {
                var authors = await _authorService.GetAllAuthors();
                return Ok(new ApiResult { IsSuccess = true, Data = authors });
            }
            catch (Exception ex)
            {
                return new ApiResult { IsSuccess = false, Message = ex.Message };
            }
        }
        [HttpGet("paged")]
        public async Task<ActionResult<ApiPagedResult<GetAuthorDto>>> GetAllAuthorsPaged([FromQuery] AuthorParams authorParams)
        {
            try
            {
                ApiPagedResult<GetAuthorDto> authors = await _authorService.GetAllAuthors(authorParams);
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return new ApiPagedResult<GetAuthorDto> { IsSuccess = false, Message = ex.Message };
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> DeleteAuthorById(int id)
        {
            try
            {
                var author = await _authorService.GetAuthorById(id);
                if (author == null)
                {
                    return NotFound(new ApiResult { IsSuccess = false, Data = $"not found author by {id}" });
                }

                var hasBooks = await _authorService.checkAuthorHasBook(id);
                if (hasBooks)
                {
                    return BadRequest(new ApiResult { IsSuccess = false, Message = $"This author cannot be deleted because it has books associated with it" });
                }

                var UserId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (UserId == null)
                {
                    return Unauthorized(new ApiResult { IsSuccess = false });
                }

                var deleted = await _authorService.DeleteAuthorById(id, UserId);
                return Ok(new ApiResult { IsSuccess = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResult { IsSuccess = false, Message = ex.Message });
            }
        }
        [HttpGet("export-excel")]
        public async Task<ActionResult> ExportToExcel()
        {
            try
            {
                var stream = await _authorService.ExportToExcel();
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AuthorRecords");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("{id}/toggle-status")]
        public async Task<IActionResult> ActivateOrDeactivateAuthor(int id)
        {
            var result = await _authorService.ActivateOrDeactivateAuthor(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var UserId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (UserId == null)
            {
                return Unauthorized(new ApiResult { IsSuccess = false });
            }

            var result = await _authorService.CreateAuthor(createAuthorDto, HttpContext, UserId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            var UserId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (UserId == null)
            {
                return Unauthorized(new ApiResult { IsSuccess = false });
            }

            var result = await _authorService.UpdateAuthor(updateAuthorDto, HttpContext, UserId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}

