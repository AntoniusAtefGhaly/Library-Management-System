using LMS.Application.Dtos.Author;
using LMS.Application.Managers.Interfaces;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Domain.Entities;
using LMS.Domain.Interfaces;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;


using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Managers.Services
{
    public class AuthorService:IAuthorService
    {
        private IUnitOfWork unitOfWork;
        private readonly IHelperService _helperService;
        private readonly IReportService _reportService;
        public AuthorService(IUnitOfWork _unitOfWork, IHelperService _helperService, IReportService reportService)
        {
            _reportService = reportService;
            unitOfWork = _unitOfWork;
            _helperService = _helperService;
        }
        public async Task<IEnumerable<ReadAuthorDto>> GetAllAuthors()
        {
            IEnumerable<Author> authors=await unitOfWork.AuthorRepository.GetAllAuthors();
            return authors.Select(a=>new ReadAuthorDto { Id=a.Id,FullName=a.FullName});
        }
        public async Task<bool> checkAuthorHasBook(int id)
        {
            return await unitOfWork.AuthorRepository.checkAuthorHasBook(id);
        }
        public async Task<ApiPagedResult<GetAuthorDto>> GetAllAuthors(AuthorParams authorParams)
        {
            var authors = await unitOfWork.AuthorRepository.GetAllAuthors(authorParams.pageNumber,authorParams.pageSize,authorParams.sortOrder,authorParams.sortField,authorParams.Search,true);
            var authorIds = authors.Result.Select(a => a.Id).ToList();
            var books = await unitOfWork.BookRepository.GetBooksByAuthorIds(authorIds);
            return new ApiPagedResult<GetAuthorDto> {
                IsSuccess = true,
                TotalCount = authors.TotalCount,
                PageNumber = authorParams.pageNumber,
                PageSize = authorParams.pageSize,
                Data = authors.Result.Select(a => new GetAuthorDto {
                    Id = a.Id,
                    FullName = a.FullName,
                    Description = a.Description,
                    ImageURL = a.ImageUrl,
                    DateOfBirth = a.DateOfBirth,
                    IsActive = a.IsActive,
                    BookCount = books.Count(b => b.AuthorId == a.Id)
                }).ToList()
            };
        }
        public async Task<byte[]> ExportToExcel() { return await _reportService.ExportAuthorsAsync(); }
        public async Task<int> DeleteAuthorById(int id, string userId)
        {
            var author = await unitOfWork.AuthorRepository.GetByIdAsync(id);
            if(author != null)
            {
                 await unitOfWork.AuthorRepository.DeleteAsync(author, userId);
                return 1;
            }
            return 0;
        }
        public async Task<ReadAuthorDto?> GetAuthorById(int id)
        {
            var author = await unitOfWork.AuthorRepository.GetByIdAsync(id);
            if (author == null)
                return null;
            return new ReadAuthorDto { Id=author.Id,FullName=author.FullName};
        }
        public async Task<ApiResult> ActivateOrDeactivateAuthor(int id)
        {
            try
            {

                var author = await unitOfWork.AuthorRepository.GetByIdAsync(id);
                if (author is null)
                    return new ApiResult { IsSuccess = false, Message = "author not found" };

                author.ActivationTime = DateTime.Now;
                author.IsActive = !author.IsActive;


                unitOfWork.AuthorRepository.Update(author);
                var result = await unitOfWork.SaveChangesAsync();
                return new ApiResult { IsSuccess = true, Message = $"author {(author.IsActive ? "activated" : "deactivated")} successfully", };

            }
            catch (Exception e)
            {
                return new ApiResult { IsSuccess = false, Message = e.Message };
            }
        }
        public async Task<ApiResult> CreateAuthor(CreateAuthorDto author, HttpContext httpContext,string UserId)
        {
            try
            {
                var newauthor = new Author() { FullName = author.fullName, Description = author.description, DateOfBirth = author.dateOfBirth, InsertedTime = DateTime.Now, IsActive = true,InsertedUserId=UserId,ActivationTime=DateTime.Now,ActivationUserId=UserId };
                if(author.imageUrl!=null)
                {
                    newauthor.ImageUrl = await _helperService.SaveFileAsync(author.imageUrl, "Authors");
                }
                await unitOfWork.AuthorRepository.AddAsync(newauthor);
                var effected = await unitOfWork.SaveChangesAsync();
                if(effected>0)
                     return new ApiResult { IsSuccess = true, Message = $"author Created successfully" };
                return new ApiResult { IsSuccess = false, Message = $"error in Create author" };
            }
            catch (Exception e)
            {
                return new ApiResult { IsSuccess = false, Message = e.Message };
            }
        }
        public async Task<ApiResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto, HttpContext httpContext, string UserId)
        {
            try
            {
                var author = await unitOfWork.AuthorRepository.GetByIdAsync(updateAuthorDto.id);
                if (author is null)
                    return new ApiResult { IsSuccess = false, Message = $"author by {updateAuthorDto.id} not found" };
                author.FullName = updateAuthorDto.fullName;
                author.Description = updateAuthorDto.description;
                author.ImageUrl = updateAuthorDto.imageUrl is not null ? await _helperService.SaveFileAsync(updateAuthorDto.imageUrl, "Authors") : author.ImageUrl;
                author.DateOfBirth = updateAuthorDto.dateOfBirth;
                author.UpdateUserId = UserId;
                author.UpdateTime = DateTime.Now;
                if (updateAuthorDto.imageUrl != null)
                {
                    author.ImageUrl = await _helperService.SaveFileAsync(updateAuthorDto.imageUrl, "Authors");
                }
                unitOfWork.AuthorRepository.Update(author);
                var effected = await unitOfWork.SaveChangesAsync();
                if (effected > 0)
                    return new ApiResult { IsSuccess = true, Message = $"author Updated successfully" };
                return new ApiResult { IsSuccess = false, Message = $"error in Update author" };
            }
            catch (Exception e)
            {
                return new ApiResult { IsSuccess = false, Message = e.Message };
            }
        }

    }
}
