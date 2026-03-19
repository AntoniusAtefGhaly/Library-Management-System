using LMS.Application.Dtos.Author;
using LMS.Application.Managers.Interfaces;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Domain.Entities;
using LMS.Domain.Interfaces;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Managers.Services
{
    public class AuthorService:IAuthorService
    {
        private IUnitOfWork unitOfWork;
        private IHelperService helperService;
        public AuthorService(IUnitOfWork _unitOfWork, IHelperService _helperService)
        {
            unitOfWork = _unitOfWork;   
            helperService = _helperService;
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
        public async Task<pagedResult<GetAuthorDto>> GetAllAuthors(int first, int rows, AuthorParams authorParams)
        {
            var authors = await unitOfWork.AuthorRepository.GetAllAuthors(first,rows,authorParams.sortOrder,authorParams.sortField,authorParams.Search,authorParams.isActive);
            var authorIds = authors.Result.Select(a => a.Id).ToList();
            var books = await unitOfWork.BookRepository.GetBooksByAuthorIds(authorIds);
            return new pagedResult<GetAuthorDto> {
                TotalCount = authors.TotalCount,
                Result = authors.Result.Select(a => new GetAuthorDto {
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
        public async Task<byte[]> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var authors = await unitOfWork.AuthorRepository.GetAllAsync();
                List<Author> authorList = authors.ToList();
                var stream = new MemoryStream();
                var authorsSheet = package.Workbook.Worksheets.Add("authors");
                authorsSheet.Row(1).Height = 35;
                authorsSheet.Row(1).Style.Locked = true;
                // Unlock all cells
                authorsSheet.Cells.Style.Locked = false;
                authorsSheet.Cells[1, 1, 1, 3].Style.Locked = true;
                // Protect the sheet
                authorsSheet.Protection.IsProtected = true;
                authorsSheet.Protection.SetPassword("54321");
                authorsSheet.Protection.AllowSelectLockedCells = true;
                authorsSheet.Protection.AllowSelectUnlockedCells = true;
                authorsSheet.Columns[1, 3].Width = 20;
                authorsSheet.Row(1).Style.Font.Size = 15;
                authorsSheet.Row(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                authorsSheet.Row(1).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                authorsSheet.Cells[1, 1, 1, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                authorsSheet.Cells[1, 1, 1, 3].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                authorsSheet.Row(1).Style.Font.Bold = true;
                // set columns headers           
                authorsSheet.Cells[1, 1].Value = "Name";
                authorsSheet.Cells[1, 2].Value = "Description";
                authorsSheet.Cells[1, 3].Value = "Date Of Birth";
                // set Book Records
                var row = 2;
                for (int c = 0; c < authorList.Count(); c++)
                {
                    authorsSheet.Cells[row, 1].Value = authorList[c].FullName;
                    authorsSheet.Cells[row, 2].Value = authorList[c].Description;
                    authorsSheet.Cells[row, 3].Value = authorList[c].DateOfBirth;
                    row++;
                }
                // Auto-fit columns
                authorsSheet.Cells.AutoFitColumns();
                return package.GetAsByteArray();
            }
        }
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
                    newauthor.ImageUrl = await helperService.SaveFileAsync(author.imageUrl,"Authors",httpContext);
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
                author.Id = updateAuthorDto.id;
                author.FullName = updateAuthorDto.fullName;
                author.Description = updateAuthorDto.description;
                author.ImageUrl = updateAuthorDto.imageUrl is not null ? await helperService.SaveFileAsync(updateAuthorDto.imageUrl, "Authors", httpContext) : author.ImageUrl;
                author.DateOfBirth = updateAuthorDto.dateOfBirth;
                author.UpdateUserId = UserId;
                author.UpdateTime = DateTime.Now;
                if (updateAuthorDto.imageUrl != null)
                {
                    author.ImageUrl = await helperService.SaveFileAsync(updateAuthorDto.imageUrl, "Authors", httpContext);
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
