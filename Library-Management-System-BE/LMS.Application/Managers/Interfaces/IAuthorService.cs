using LMS.Application.Dtos.Author;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Managers.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<ReadAuthorDto>> GetAllAuthors();
        Task<pagedResult<GetAuthorDto>> GetAllAuthors(AuthorParams authorParams);
        Task<int> DeleteAuthorById(int id, string userId);
        Task<bool> checkAuthorHasBook(int id);
        Task<ReadAuthorDto?> GetAuthorById(int id);
        Task<ApiResult> ActivateOrDeactivateAuthor(int id);
        Task<ApiResult> CreateAuthor(CreateAuthorDto createAuthorDto,HttpContext httpContext, string UserId);
        Task<ApiResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto, HttpContext httpContext, string UserId);
        Task<byte[]> ExportToExcel();
    }
}
