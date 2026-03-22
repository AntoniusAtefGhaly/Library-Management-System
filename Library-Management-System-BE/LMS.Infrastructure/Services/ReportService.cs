using LMS.Application;
using LMS.Application.Dtos;
using LMS.Application.Dtos.Book;
using LMS.Application.Dtos.Transaction;
using LMS.Application.Dtos.User;
using LMS.Domain.Entities;
using LMS.Domain.Enums;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace LMS.Infrastructure.Services;

public class ReportService : IReportService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public ReportService(IUnitOfWork unitOfWork, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task<byte[]> GenerateTransactionReportAsync(TransactionReportDto request)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var transactions = await _unitOfWork.TransactionRepository.GetAllAsync();
        var filteredTransactions = transactions
            .Where(t => (!request.StartDate.HasValue || t.IssueDate >= request.StartDate.Value) &&
                       (!request.EndDate.HasValue || t.IssueDate <= request.EndDate.Value))
            .OrderBy(t => t.Book?.Title)
            .ThenBy(t => $"{t.User?.FirstName} {t.User?.LastName}")
            .ToList();

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Transactions");

        worksheet.Cells[1, 1].Value = "Transaction ID";
        worksheet.Cells[1, 2].Value = "Book Title";
        worksheet.Cells[1, 3].Value = "User Name";
        worksheet.Cells[1, 4].Value = "Issue Date";
        worksheet.Cells[1, 5].Value = "Due Date";
        worksheet.Cells[1, 6].Value = "Return Date";
        worksheet.Cells[1, 7].Value = "Status";

        using (var range = worksheet.Cells[1, 1, 1, 7])
        {
            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
        }

        int row = 2;
        foreach (var transaction in filteredTransactions)
        {
            var cell = worksheet.Cells[row, 1, row, 7];
            bool isOverdue = transaction.Status == TransactionStatus.Overdue.ToString();
            if (isOverdue)
            {
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor(Color.LightPink);
                cell.Style.Font.Color.SetColor(Color.Red);
            }

            worksheet.Cells[row, 1].Value = transaction.Id;
            worksheet.Cells[row, 2].Value = transaction.Book?.Title;
            worksheet.Cells[row, 3].Value = $"{transaction.User?.FirstName} {transaction.User?.LastName}";
            worksheet.Cells[row, 4].Value = transaction.IssueDate;
            worksheet.Cells[row, 5].Value = transaction.DueDate;
            worksheet.Cells[row, 6].Value = transaction.ReturnDate;
            worksheet.Cells[row, 7].Value = transaction.Status;

            worksheet.Cells[row, 4].Style.Numberformat.Format = "yyyy-mm-dd";
            worksheet.Cells[row, 5].Style.Numberformat.Format = "yyyy-mm-dd";
            worksheet.Cells[row, 6].Style.Numberformat.Format = "yyyy-mm-dd";
            row++;
        }
        worksheet.Cells.AutoFitColumns();
        return package.GetAsByteArray();
    }

    public async Task<byte[]> GenerateUserReportAsync(UserReportRequest request)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var users = await _unitOfWork.UserRepository.GetWhereAsync
             (u => (!request.StartDate.HasValue || u.InsertedTime >= request.StartDate.Value) && (!request.EndDate.HasValue || u.InsertedTime <= request.EndDate.Value));
        users = users
            .OrderBy(u => u.Role == "Admin" ? 0 : u.Role == "Librarian" ? 1 : 2)
            .ThenBy(u => u.FirstName + " " + u.LastName)
            .ToList();

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Users");

        worksheet.Cells[1, 1].Value = "User ID";
        worksheet.Cells[1, 2].Value = "Full Name";
        worksheet.Cells[1, 3].Value = "Email";
        worksheet.Cells[1, 4].Value = "Role";
        worksheet.Cells[1, 5].Value = "Books Borrowed";
        worksheet.Cells[1, 6].Value = "Joined Date";

        using (var range = worksheet.Cells[1, 1, 1, 6])
        {
            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
        }

        int row = 2;
        foreach (var user in users)
        {
            var booksBorrowed = (await _unitOfWork.TransactionRepository.GetAllAsync())
                .Count(t => t.UserId == user.Id && t.Status != TransactionStatus.Returned.ToString());

            worksheet.Cells[row, 1].Value = user.Id;
            worksheet.Cells[row, 2].Value = user.FirstName + " " + user.LastName;
            worksheet.Cells[row, 3].Value = user.Email;
            worksheet.Cells[row, 4].Value = user.Role;
            worksheet.Cells[row, 5].Value = booksBorrowed;
            worksheet.Cells[row, 6].Value = user.InsertedTime;
            worksheet.Cells[row, 6].Style.Numberformat.Format = "yyyy-mm-dd";
            row++;
        }
        worksheet.Cells.AutoFitColumns();
        return package.GetAsByteArray();
    }

    public async Task<byte[]> GenerateUserBorrowingHistoryReportAsync(UserBorrowingHistoryRequest request)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var transactionsQuery = await _unitOfWork.TransactionRepository.GetAllAsync();
        if (request.UserId.HasValue)
        {
            transactionsQuery = transactionsQuery.Where(t => t.UserId == request.UserId.Value);
        }
        if (request.StartDate.HasValue)
        {
            transactionsQuery = transactionsQuery.Where(t => t.IssueDate >= request.StartDate.Value);
        }
        if (request.EndDate.HasValue)
        {
            transactionsQuery = transactionsQuery.Where(t => t.IssueDate <= request.EndDate.Value);
        }

        var transactions = transactionsQuery
            .OrderBy(t => t.User.FirstName + " " + t.User.LastName)
            .ThenByDescending(t => t.IssueDate)
            .ToList();

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Borrowing History");

        worksheet.Cells[1, 1].Value = request.UserId.HasValue ? "User Borrowing History" : "All Users Borrowing History";
        worksheet.Cells[1, 1, 1, 7].Merge = true;
        worksheet.Cells[1, 1, 1, 7].Style.Font.Bold = true;
        worksheet.Cells[1, 1, 1, 7].Style.Font.Size = 14;
        worksheet.Cells[1, 1, 1, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
        worksheet.Cells[1, 1, 1, 7].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
        worksheet.Cells[1, 1, 1, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

        int headerRow = 3;
        worksheet.Cells[headerRow, 1].Value = "User Name";
        worksheet.Cells[headerRow, 2].Value = "Email";
        worksheet.Cells[headerRow, 3].Value = "Book Title";
        worksheet.Cells[headerRow, 4].Value = "Issue Date";
        worksheet.Cells[headerRow, 5].Value = "Due Date";
        worksheet.Cells[headerRow, 6].Value = "Return Date";
        worksheet.Cells[headerRow, 7].Value = "Status";
        worksheet.Cells[headerRow, 8].Value = "Days Overdue";

        using (var range = worksheet.Cells[headerRow, 1, headerRow, 8])
        {
            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
        }

        int row = headerRow + 1;
        foreach (var transaction in transactions)
        {
            var cell = worksheet.Cells[row, 1, row, 8];
            bool isOverdue = transaction.Status == LMS.Domain.Enums.TransactionStatus.Overdue.ToString();
            bool isReturned = transaction.Status == TransactionStatus.Returned.ToString();
            bool isIssued = transaction.Status == TransactionStatus.Issued.ToString();

            if (isOverdue)
            {
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor(Color.LightPink);
                cell.Style.Font.Color.SetColor(Color.Red);
            }
            else if (isReturned)
            {
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
            }
            else if (isIssued)
            {
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor(Color.LightYellow);
            }

            worksheet.Cells[row, 1].Value = transaction.User.FirstName + " " + transaction.User.LastName;
            worksheet.Cells[row, 2].Value = transaction.User.Email;
            worksheet.Cells[row, 3].Value = transaction.Book?.Title;
            worksheet.Cells[row, 4].Value = transaction.IssueDate;
            worksheet.Cells[row, 5].Value = transaction.DueDate;
            worksheet.Cells[row, 6].Value = transaction.ReturnDate;
            worksheet.Cells[row, 7].Value = transaction.Status;

            int daysOverdue = 0;
            if (isOverdue && transaction.DueDate.HasValue)
            {
                daysOverdue = (DateTime.Now - transaction.DueDate!.Value).Days;
            }
            else if (isReturned && transaction.DueDate.HasValue && transaction.ReturnDate > transaction.DueDate)
            {
                daysOverdue = (transaction.ReturnDate.Value - transaction.DueDate!.Value).Days;
            }
            worksheet.Cells[row, 8].Value = daysOverdue;

            worksheet.Cells[row, 4].Style.Numberformat.Format = "yyyy-mm-dd";
            worksheet.Cells[row, 5].Style.Numberformat.Format = "yyyy-mm-dd";
            worksheet.Cells[row, 6].Style.Numberformat.Format = "yyyy-mm-dd";
            row++;
        }
        worksheet.Cells.AutoFitColumns();
        return package.GetAsByteArray();
    }

    public async Task<byte[]> ExportAuthorsAsync()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage())
        {
            var authors = await _unitOfWork.AuthorRepository.GetAllAsync();
            var authorList = authors.ToList();
            var sheet = package.Workbook.Worksheets.Add("Authors");
            StyleHeader(sheet, 3);
            sheet.Cells[1, 1].Value = "Name";
            sheet.Cells[1, 2].Value = "Description";
            sheet.Cells[1, 3].Value = "Date Of Birth";

            int row = 2;
            foreach (var author in authorList)
            {
                sheet.Cells[row, 1].Value = author.FullName;
                sheet.Cells[row, 2].Value = author.Description;
                sheet.Cells[row, 3].Value = author.DateOfBirth;
                sheet.Cells[row, 3].Style.Numberformat.Format = "yyyy-mm-dd";
                row++;
            }
            sheet.Cells.AutoFitColumns();
            return package.GetAsByteArray();
        }
    }

    public async Task<byte[]> ExportBooksAsync(List<SelectedFilters> selectedFilters)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage())
        {
            var books = await _unitOfWork.BookRepository.getAllBooksWithAuthorandCategory();
            var dataList = books.Select(b => new BookWithDetailsDto()
            {
                Title = b.Title,
                Description = b.Description,
                PublicationYear = b.PublicationYear,
                AvailableCopies = b.AvailableCopies,
                TotalCopies = b.TotalCopies,
                Category = b.Category.Name,
                Author = b.Author.FullName
            }).ToList();

            var sheet = package.Workbook.Worksheets.Add("Books");
            StyleHeader(sheet, selectedFilters.Count);

            for (int i = 0; i < selectedFilters.Count; i++)
                sheet.Cells[1, i + 1].Value = selectedFilters[i].name;

            int row = 2;
            foreach (var item in dataList)
            {
                for (int i = 0; i < selectedFilters.Count; i++)
                {
                    var property = item.GetType().GetProperty(selectedFilters[i].name);
                    if (property != null) sheet.Cells[row, i + 1].Value = property.GetValue(item);
                }
                row++;
            }
            sheet.Cells.AutoFitColumns();
            return package.GetAsByteArray();
        }
    }

    public async Task<byte[]> ExportCategoriesAsync()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage())
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            var sheet = package.Workbook.Worksheets.Add("Categories");
            StyleHeader(sheet, 2);
            sheet.Cells[1, 1].Value = "Name";
            sheet.Cells[1, 2].Value = "Description";

            int row = 2;
            foreach (var cat in categories)
            {
                sheet.Cells[row, 1].Value = cat.Name;
                sheet.Cells[row, 2].Value = cat.Description;
                row++;
            }
            sheet.Cells.AutoFitColumns();
            return package.GetAsByteArray();
        }
    }

    public async Task<byte[]> ExportTransactionsAsync(List<SelectedFilters> selectedFilters)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage())
        {
            var transactions = await _unitOfWork.TransactionRepository.GetAllAsync();
            var dataList = transactions.Select(t => new TransactionExcellData()
            {
                Book = t.Book?.Title,
                User = $"{t.User?.FirstName} {t.User?.LastName}",
                RequestDate = t.RequestDate.ToString("d"),
                IssueDate = t.IssueDate?.ToString("d"),
                DueDate = t.DueDate?.ToString("d"),
                ReturnDate = t.ReturnDate?.ToString("d"),
                Status = t.Status,
                IssuedByUser = $"{t.IssuedByUser?.FirstName} {t.IssuedByUser?.LastName}",
                ReturnedByUser = $"{t.ReturnedByUser?.FirstName} {t.ReturnedByUser?.LastName}",
            }).ToList();

            var sheet = package.Workbook.Worksheets.Add("Transactions");
            StyleHeader(sheet, selectedFilters.Count);

            for (int i = 0; i < selectedFilters.Count; i++)
                sheet.Cells[1, i + 1].Value = selectedFilters[i].name;

            int row = 2;
            foreach (var item in dataList)
            {
                for (int i = 0; i < selectedFilters.Count; i++)
                {
                    var property = item.GetType().GetProperty(selectedFilters[i].name);
                    if (property != null) sheet.Cells[row, i + 1].Value = property.GetValue(item);
                }
                row++;
            }
            sheet.Cells.AutoFitColumns();
            return package.GetAsByteArray();
        }
    }

    public async Task<byte[]> ExportUsersAsync(List<SelectedFilters> selectedFilters)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage())
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            var dataList = users.Select(u => new UserExcellData()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Role = u.Role,
                InsertedTime = u.InsertedTime.Value,
                IsActive = u.IsActive
            }).ToList();

            var sheet = package.Workbook.Worksheets.Add("Users");
            StyleHeader(sheet, selectedFilters.Count);

            for (int i = 0; i < selectedFilters.Count; i++)
                sheet.Cells[1, i + 1].Value = selectedFilters[i].name;

            int row = 2;
            foreach (var item in dataList)
            {
                for (int i = 0; i < selectedFilters.Count; i++)
                {
                    var property = item.GetType().GetProperty(selectedFilters[i].name);
                    if (property != null) sheet.Cells[row, i + 1].Value = property.GetValue(item);
                }
                row++;
            }
            sheet.Cells.AutoFitColumns();
            return package.GetAsByteArray();
        }
    }

    private void StyleHeader(ExcelWorksheet sheet, int columnCount)
    {
        sheet.Row(1).Height = 35;
        sheet.Row(1).Style.Locked = true;
        sheet.Cells.Style.Locked = false;
        sheet.Cells[1, 1, 1, columnCount].Style.Locked = true;
        sheet.Protection.IsProtected = true;
        sheet.Protection.SetPassword("54321");
        sheet.Protection.AllowSelectLockedCells = true;
        sheet.Protection.AllowSelectUnlockedCells = true;
        sheet.Columns[1, 10].Width = 20;
        sheet.Row(1).Style.Font.Size = 15;
        sheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        sheet.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        sheet.Cells[1, 1, 1, columnCount].Style.Fill.PatternType = ExcelFillStyle.Solid;
        sheet.Cells[1, 1, 1, columnCount].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
        sheet.Row(1).Style.Font.Bold = true;
    }
}
