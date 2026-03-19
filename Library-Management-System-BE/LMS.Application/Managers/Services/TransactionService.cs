using LMS.Application.Dtos;
using LMS.Application.Dtos.Transaction;
using LMS.Application.Managers.Interfaces;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
namespace LMS.Application;

public class TransactionService : ITransactionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITrendingBooksService _trendingBooksService;
    private readonly ICurrentUserService _currentUserService;
    private readonly IEmailService _emailService;


    public TransactionService(
        IUnitOfWork unitOfWork,
        ITrendingBooksService trendingBooksService,
        ICurrentUserService currentUserService,
        IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _trendingBooksService = trendingBooksService;
        _currentUserService = currentUserService;
        _emailService = emailService;
    }

    public async Task<ApiResult> GetAllTransactionsAsync()
    {
        try
        {
            var transactions = await _unitOfWork.TransactionRepository.GetAllAsync();
            var transactionList = transactions.Select(t => new GetTransactionDto
            {
                Id = t.Id,
                BookId = t.BookId,
                UserId = t.UserId,
                RequestDate = t.RequestDate,
                IssueDate = t.IssueDate,
                DueDate = t.DueDate,
                ReturnDate = t.ReturnDate,
                Status = t.Status,
                UserFullName = $"{t.User?.FirstName} {t.User?.LastName}",
                BookName = t.Book?.Title ?? "Unknown Book",
                BookImageUrl = t.Book?.ImageUrl,
                BorrowDays = t.BorrowDays
            }).ToList();

            return new ApiResult { IsSuccess = true, Data = transactionList };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }
    public async Task<byte[]> ExportToExcel(List<SelectedFilters> selectedFilters)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage())
        {
            var transactions = await _unitOfWork.TransactionRepository.GetAllAsync();
            List<TransactionExcellData> TransactionExcellDataList = transactions.Select(t => new TransactionExcellData() { Book = t.Book?.Title, User = string.Concat(t.User?.FirstName, t.User?.LastName), RequestDate = t.RequestDate.ToString("d"), IssueDate = t.IssueDate?.ToString("d"), DueDate = t.DueDate?.ToString("d"), ReturnDate = t.ReturnDate?.ToString("d"), Status = t.Status, IssuedByUser = string.Concat(t.IssuedByUser?.FirstName, t.IssuedByUser?.LastName), ReturnedByUser = string.Concat(t.ReturnedByUser?.FirstName, t.ReturnedByUser?.LastName), }).ToList();
            var stream = new MemoryStream();
            var UsersSheet = package.Workbook.Worksheets.Add("Books");
            UsersSheet.Row(1).Height = 35;
            UsersSheet.Row(1).Style.Locked = true;
            // Unlock all cells
            UsersSheet.Cells.Style.Locked = false;
            UsersSheet.Cells[1, 1, 1, selectedFilters.Count].Style.Locked = true;
            // Protect the sheet
            UsersSheet.Cells[1, 1, 1, selectedFilters.Count].Style.Locked = true;
            UsersSheet.Protection.IsProtected = true;
            UsersSheet.Protection.SetPassword("54321");
            UsersSheet.Protection.AllowSelectLockedCells = true;
            UsersSheet.Protection.AllowSelectUnlockedCells = true;
            UsersSheet.Columns[1, 10].Width = 20;
            UsersSheet.Row(1).Style.Font.Size = 15;
            UsersSheet.Row(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            UsersSheet.Row(1).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            UsersSheet.Cells[1, 1, 1, selectedFilters.Count].Style.Fill.PatternType = ExcelFillStyle.Solid;
            UsersSheet.Cells[1, 1, 1, selectedFilters.Count].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
            UsersSheet.Row(1).Style.Font.Bold = true;
            // set columns headers
            for (int i = 0; i < selectedFilters.Count; i++)
            {
                UsersSheet.Cells[1, i + 1].Value = selectedFilters[i].name;
            }
            // set transactions Records
            var row = 2;
            for (int b = 0; b < TransactionExcellDataList?.Count(); b++)
            {
                for (int i = 0; i < selectedFilters.Count; i++)
                {

                    var bookType = TransactionExcellDataList[b].GetType();
                    var property = bookType.GetProperty(selectedFilters[i].name);
                    if (property != null) UsersSheet.Cells[row, i + 1].Value = property.GetValue(TransactionExcellDataList[b]);
                }
                row++;
            }
            // Auto-fit columns
            UsersSheet.Cells.AutoFitColumns();
            return package.GetAsByteArray();
        }
    }
    public async Task<ApiResult> GetTransactionByIdAsync(string id)
    {
        try
        {
            var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(id);
            if (transaction == null)
            {
                return new ApiResult { IsSuccess = false, Message = "Transaction not found" };
            }

            return new ApiResult
            {
                IsSuccess = true,
                Data = new TransactionDetailsDto
                {
                    Id = transaction.Id,
                    UserId = transaction.UserId,
                    BookId = transaction.BookId,
                    RequestDate = transaction.RequestDate,
                    IssueDate = transaction.IssueDate,
                    DueDate = transaction.DueDate,
                    ReturnDate = transaction.ReturnDate,
                    Status = transaction.Status,
                    UserFullName = $"{transaction.User?.FirstName} {transaction.User?.LastName}",
                    BookName = transaction.Book?.Title ?? "Unknown Book",
                    BorrowDays = transaction.BorrowDays,
                    IssuedByUser = transaction.IssuedByUserId.HasValue ? $"{transaction.IssuedByUser?.FirstName} {transaction.IssuedByUser?.LastName}" : "",
                    ReturnedByUser = transaction.ReturnedByUserId.HasValue ? $"{transaction.ReturnedByUser?.FirstName} {transaction.ReturnedByUser?.LastName}" : "",
                    ReturnNotes = transaction.ReturnNotes

                }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> AddTransactionAsync(AddTransactionDto request)
    {
        try
        {
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                BookId = request.BookId,
                IssueDate = request.IssueDate,
                DueDate = request.DueDate,
                Status = TransactionStatus.Issued.ToString(),
                InsertedUserId = _currentUserService.UserId,
                InsertedTime = DateTime.Now
            };
            await _trendingBooksService.SetTrendingBookAsync(request.BookId);

            await _unitOfWork.TransactionRepository.AddAsync(transaction);
            await _unitOfWork.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = "Transaction created successfully", Data = transaction };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> UpdateTransactionAsync(UpdateTransactionDto request)
    {
        try
        {
            var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(request.Id);
            if (transaction == null)
            {
                return new ApiResult { IsSuccess = false, Message = "Transaction not found" };
            }

            transaction.ReturnDate = request.ReturnDate ?? transaction.ReturnDate;
            transaction.Status = request.Status ?? transaction.Status;
            transaction.UpdateUserId = _currentUserService.UserId;
            transaction.UpdateTime = DateTime.Now;

            _unitOfWork.TransactionRepository.Update(transaction);
            await _unitOfWork.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = "Transaction updated successfully", Data = transaction };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> DeleteTransactionAsync(string id)
    {
        try
        {
            var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(id);
            if (transaction == null)
            {
                return new ApiResult { IsSuccess = false, Message = "Transaction not found" };
            }

            await _unitOfWork.TransactionRepository.DeleteAsync(transaction, _currentUserService.UserId!);
            return new ApiResult { IsSuccess = true, Message = "Transaction marked as deleted" };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> GetTransactionsByUserIdAsync(int userId)
    {
        try
        {
            var transactions = await _unitOfWork.TransactionRepository.GetAllAsync();
            var transactionList = transactions
                .Where(t => t.UserId == userId)
                .Select(t => new GetTransactionDto
                {
                    Id = t.Id,
                    UserId = t.UserId,
                    BookId = t.BookId,
                    RequestDate = t.RequestDate,
                    UserFullName = $"{t.User?.FirstName} {t.User?.LastName}",
                    BookName = t.Book?.Title ?? "Unknown Book",
                    IssueDate = t.IssueDate,
                    DueDate = t.DueDate,
                    ReturnDate = t.ReturnDate,
                    Status = t.Status,
                    BookImageUrl = t.Book?.ImageUrl
                }).ToList();

            return new ApiResult { IsSuccess = true, Data = transactionList };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> GetCurrentUserTransactionsAsync()
    {
        try
        {
            var userId = int.Parse(_currentUserService.UserId!);
            var transactions = await _unitOfWork.TransactionRepository.GetAllAsync();
            var userTransactions = transactions
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.IssueDate)
                .Select(t => new UserTransactionHistoryDto
                {
                    Id = t.Id,
                    BookId = t.BookId,
                    BookName = t.Book.Title,
                    BookImageUrl = t.Book.ImageUrl,
                    IssueDate = t.IssueDate,
                    DueDate = t.DueDate,
                    ReturnDate = t.ReturnDate,
                    RequestDate = t.RequestDate,
                    Status = t.Status
                })
                .ToList();

            return new ApiResult
            {
                IsSuccess = true,
                Data = userTransactions
            };
        }
        catch (Exception ex)
        {
            return new ApiResult
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ApiResult> BorrowBookAsync(BorrowBookDto request)
    {
        try
        {
            // Get the current user's ID
            var userId = int.Parse(_currentUserService.UserId!);

            // Check if the book exists and is available
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.BookId);
            if (book == null)
            {
                return new ApiResult { IsSuccess = false, Message = "Book not found" };
            }

            if (book.AvailableCopies <= 0)
            {
                return new ApiResult { IsSuccess = false, Message = "Book is not available for borrowing" };
            }
            if (request.BorrowDays > 90)
            {
                return new ApiResult { IsSuccess = false, Message = "You can not borrow book for more than 90 days" };
            }
            // Check if user already has an active transaction for this book
            var hasActiveTransaction = await _unitOfWork.TransactionRepository.AnyAsync(t => t.UserId == userId &&
                         t.BookId == request.BookId &&
                         t.Status != TransactionStatus.Returned.ToString());

            if (hasActiveTransaction)
            {
                return new ApiResult { IsSuccess = false, Message = "You already have an active transaction for this book" };
            }

            // Create new transaction
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                BookId = request.BookId,
                BorrowDays = request.BorrowDays,
                RequestDate = DateTime.Now,
                Status = TransactionStatus.Pending.ToString(),
                InsertedUserId = _currentUserService.UserId,
                InsertedTime = DateTime.Now
            };

            // Update book availability
            book.AvailableCopies--;
            book.UpdateUserId = _currentUserService.UserId;
            book.UpdateTime = DateTime.Now;

            // Add transaction and update book
            await _unitOfWork.TransactionRepository.AddAsync(transaction);
            _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.SaveChangesAsync();

            // Increment trending book count
            await _trendingBooksService.SetTrendingBookAsync(request.BookId);

            return new ApiResult
            {
                IsSuccess = true,
                Message = "Book borrowed successfully",
                Data = new UserTransactionHistoryDto
                {
                    Id = transaction.Id,
                    BookId = book.Id,
                    BookName = book.Title,
                    BookImageUrl = book.ImageUrl,
                    IssueDate = transaction.IssueDate,
                    DueDate = transaction.DueDate,
                    Status = transaction.Status
                }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> IssueBookAsync(IssueBookDto request)
    {
        try
        {
            // Get the current user's ID
            var userId = int.Parse(_currentUserService.UserId!);

            var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(request.TransactionId);
            if (transaction == null)
            {
                return new ApiResult { IsSuccess = false, Message = "Transaction not found" };
            }
            if (transaction.Status != TransactionStatus.Pending.ToString())
            {
                return new ApiResult { IsSuccess = false, Message = "Transaction should be pending" };
            }

            //Validate Issue date eg. Issue date should be after request date
            if (request.IssueDate <= transaction.RequestDate)
            {
                return new ApiResult { IsSuccess = false, Message = "Issue date can't be before request date" };
            }
            //Validate Issue date eg. Issue date can't be in the future
            if (request.IssueDate >= DateTime.Now)
            {
                return new ApiResult { IsSuccess = false, Message = "Issue date can't be in the future" };
            }

            transaction.IssueDate = request.IssueDate;
            transaction.DueDate = request.IssueDate.AddDays(transaction.BorrowDays);
            transaction.Status = TransactionStatus.Issued.ToString();
            transaction.IssuedByUserId = userId; // Set the user who issued the book
            transaction.UpdateUserId = _currentUserService.UserId;
            transaction.UpdateTime = DateTime.Now;

            _unitOfWork.TransactionRepository.Update(transaction);
            await _unitOfWork.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = "Book has been Issued successfully" };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> ReturnBookAsync(ReturnBookDto request)
    {
        try
        {
            // Get the current user's ID
            var userId = int.Parse(_currentUserService.UserId!);

            var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(request.TransactionId);
            if (transaction == null)
            {
                return new ApiResult { IsSuccess = false, Message = "Transaction not found" };
            }
            if (transaction.Status != TransactionStatus.Issued.ToString() && transaction.Status != TransactionStatus.Overdue.ToString())
            {
                return new ApiResult { IsSuccess = false, Message = "Transaction should be issued" };
            }

            //Validate Return date eg. Return date should be after Issue date
            if (request.ReturnDate <= transaction.IssueDate)
            {
                return new ApiResult { IsSuccess = false, Message = "Return date can't be before issue date" };
            }
            //Validate Return date eg. Return date can't be in the future
            if (request.ReturnDate >= DateTime.Now)
            {
                return new ApiResult { IsSuccess = false, Message = "Return date can't be in the future" };
            }


            transaction.ReturnDate = request.ReturnDate;
            transaction.Status = TransactionStatus.Returned.ToString();
            transaction.ReturnNotes = request.Notes;
            transaction.ReturnedByUserId = userId; // Set the user who returned the book
            transaction.UpdateUserId = _currentUserService.UserId;
            transaction.UpdateTime = DateTime.Now;
            transaction.Book.AvailableCopies++; // Increment the book's available copies

            _unitOfWork.TransactionRepository.Update(transaction);
            await _unitOfWork.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = "Book has been Returned successfully" };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<byte[]> GenerateTransactionReportAsync(TransactionReportDto request)
    {
        // Set the license context for EPPlus 8+
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        var transactions = await _unitOfWork.TransactionRepository.GetAllAsync();
        var filteredTransactions = transactions
            .Where(t => t.IssueDate >= request.StartDate && t.IssueDate <= request.EndDate)
            .OrderBy(t => t.Book?.Title)
            .ThenBy(t => $"{t.User?.FirstName} {t.User?.LastName}")
            .ToList();

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Transactions");

        // Add headers
        worksheet.Cells[1, 1].Value = "Transaction ID";
        worksheet.Cells[1, 2].Value = "Book Title";
        worksheet.Cells[1, 3].Value = "User Name";
        worksheet.Cells[1, 4].Value = "Issue Date";
        worksheet.Cells[1, 5].Value = "Due Date";
        worksheet.Cells[1, 6].Value = "Return Date";
        worksheet.Cells[1, 7].Value = "Status";

        // Style the header row
        using (var range = worksheet.Cells[1, 1, 1, 7])
        {
            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
        }

        // Add transaction data
        int row = 2;
        foreach (var transaction in filteredTransactions)
        {
            var cell = worksheet.Cells[row, 1, row, 7];

            // Check if transaction is overdue
            bool isOverdue = transaction.Status == TransactionStatus.Overdue.ToString();

            if (isOverdue)
            {
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);
                cell.Style.Font.Color.SetColor(System.Drawing.Color.Red);
            }

            worksheet.Cells[row, 1].Value = transaction.Id;
            worksheet.Cells[row, 2].Value = transaction.Book?.Title;
            worksheet.Cells[row, 3].Value = $"{transaction.User?.FirstName} {transaction.User?.LastName}";
            worksheet.Cells[row, 4].Value = transaction.IssueDate;
            worksheet.Cells[row, 5].Value = transaction.DueDate;
            worksheet.Cells[row, 6].Value = transaction.ReturnDate;
            worksheet.Cells[row, 7].Value = transaction.Status;

            // Format date columns
            worksheet.Cells[row, 4].Style.Numberformat.Format = "yyyy-mm-dd";
            worksheet.Cells[row, 5].Style.Numberformat.Format = "yyyy-mm-dd";
            worksheet.Cells[row, 6].Style.Numberformat.Format = "yyyy-mm-dd";

            row++;
        }

        // Auto-fit columns
        worksheet.Cells.AutoFitColumns();

        return package.GetAsByteArray();
    }

    public async Task<int> SendOverdueNotificationsAsync()
    {
        int sent = 0;

        // First, update any issued books that are overdue to have "Overdue" status
        var overdueIssuedTransactions = await _unitOfWork.TransactionRepository.GetWhereAsync(
            t => t.Status == TransactionStatus.Issued.ToString() &&
                 t.DueDate.HasValue &&
                 t.DueDate.Value.Date < DateTime.Now.Date);

        foreach (var transaction in overdueIssuedTransactions)
        {
            transaction.Status = TransactionStatus.Overdue.ToString();
            transaction.UpdateUserId = _currentUserService.UserId;
            transaction.UpdateTime = DateTime.Now;
            _unitOfWork.TransactionRepository.Update(transaction);
        }



        // Save the status updates
        await _unitOfWork.SaveChangesAsync();

        // Now get all overdue transactions (including newly updated ones) for notification
        var overdueTransactions = await _unitOfWork.TransactionRepository.GetWhereIncludeAsync(
            t => t.Status == TransactionStatus.Overdue.ToString() &&
                 (t.LastOverdueNotified == null || t.LastOverdueNotified.Value.Date < DateTime.Now.AddHours(0)),
            "User", "Book");

        foreach (var transaction in overdueTransactions)
        {
            if (transaction.User?.Email != null)
            {
                // Check if email is a Gmail address
                if (!transaction.User.Email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Skipping non-Gmail address: {transaction.User.Email}");
                    continue;
                }

                var subject = "Library Book Overdue Notice";
                var daysOverdue = (DateTime.Now - transaction.DueDate.Value).Days;
                var body = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
                        <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
                            <h2 style='color: #d9534f;'>Overdue Book Notice</h2>
                            
                            <p>Dear {transaction.User.FirstName},</p>
                            
                            <p>This is a reminder that the following book is currently overdue:</p>
                            
                            <div style='background-color: #f8f9fa; padding: 15px; border-left: 4px solid #d9534f; margin: 20px 0;'>
                                <p style='margin: 0;'><strong>Book Title:</strong> {transaction.Book?.Title}</p>
                                <p style='margin: 5px 0;'><strong>Due Date:</strong> {transaction.DueDate:MMMM dd, yyyy}</p>
                                <p style='margin: 5px 0;'><strong>Days Overdue:</strong> {daysOverdue} day(s)</p>
                            </div>
                            
                            <p>Please return this book to the library as soon as possible to avoid any additional penalties.</p>
                            
                            <p>If you have already returned the book, please disregard this notice.</p>
                            
                            <div style='margin-top: 30px; padding-top: 20px; border-top: 1px solid #eee;'>
                                <p style='margin: 0;'>Best regards,</p>
                                <p style='margin: 5px 0;'><strong>Library Management System</strong></p>
                                <p style='margin: 0; color: #666;'>Your trusted source for knowledge</p>
                            </div>
                        </div>
                    </body>
                    </html>";

                try
                {
                    await _emailService.SendEmailAsync(transaction.User.Email, subject, body);
                    transaction.LastOverdueNotified = DateTime.Now;
                    sent++;
                    Console.WriteLine($"Successfully sent overdue notice to {transaction.User.Email}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send overdue notice to {transaction.User.Email}: {ex.Message}");
                }
            }
        }
        await _unitOfWork.SaveChangesAsync();
        return sent;
    }

    public async Task<int> SendIssuedBookRemindersAsync(string transactionId)
    {
        int sent = 0;

        // Get the specific transaction
        var transaction = await _unitOfWork.TransactionRepository.GetWhereIncludeAsync(
            t => t.Id.ToString() == transactionId &&
                 t.Status == TransactionStatus.Issued.ToString() &&
                 t.DueDate.HasValue &&
                 t.DueDate.Value.Date >= DateTime.Now.Date,
            "User", "Book");

        if (!transaction.Any())
        {
            return 0; // No valid transaction found
        }

        var targetTransaction = transaction.First();

        if (targetTransaction.User?.Email != null)
        {
            // Check if email is a Gmail address
            if (!targetTransaction.User.Email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Skipping non-Gmail address: {targetTransaction.User.Email}");
                return 0;
            }

            var subject = "Library Book Return Reminder";
            var daysRemaining = (targetTransaction.DueDate.Value - DateTime.Now).Days;
            var body = $@"
                <html>
                <body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
                    <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
                        <h2 style='color: #5bc0de;'>Book Return Reminder</h2>
                        
                        <p>Dear {targetTransaction.User.FirstName},</p>
                        
                        <p>This is a friendly reminder about your borrowed book:</p>
                        
                        <div style='background-color: #f8f9fa; padding: 15px; border-left: 4px solid #5bc0de; margin: 20px 0;'>
                            <p style='margin: 0;'><strong>Book Title:</strong> {targetTransaction.Book?.Title}</p>
                            <p style='margin: 5px 0;'><strong>Issue Date:</strong> {targetTransaction.IssueDate:MMMM dd, yyyy}</p>
                            <p style='margin: 5px 0;'><strong>Due Date:</strong> {targetTransaction.DueDate:MMMM dd, yyyy}</p>
                            <p style='margin: 5px 0;'><strong>Days Remaining:</strong> {daysRemaining} day(s)</p>
                        </div>
                        
                        <p>Please return this book to the library before the due date to avoid any late fees or penalties.</p>
                        
                        <p>If you need to extend your borrowing period, please contact the library staff.</p>
                        
                        <div style='margin-top: 30px; padding-top: 20px; border-top: 1px solid #eee;'>
                            <p style='margin: 0;'>Best regards,</p>
                            <p style='margin: 5px 0;'><strong>Library Management System</strong></p>
                            <p style='margin: 0; color: #666;'>Your trusted source for knowledge</p>
                        </div>
                    </div>
                </body>
                </html>";

            try
            {
                await _emailService.SendEmailAsync(targetTransaction.User.Email, subject, body);
                sent++;
                Console.WriteLine($"Successfully sent issued book reminder to {targetTransaction.User.Email}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send issued book reminder to {targetTransaction.User.Email}: {ex.Message}");
            }
        }
        await _unitOfWork.SaveChangesAsync();
        return sent;
    }

    public async Task<ApiResult> ChangeTransactionStatusAsync(ChangeTransactionStatusDto request)
    {
        try
        {
            var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(request.TransactionId);
            if (transaction == null)
            {
                return new ApiResult { IsSuccess = false, Message = "Transaction not found" };
            }

            // Validate status
            if (!Enum.TryParse<TransactionStatus>(request.Status, out var newStatus))
            {
                return new ApiResult { IsSuccess = false, Message = "Invalid status value" };
            }

            // Update transaction
            transaction.Status = newStatus.ToString();
            if (request.ReturnDate.HasValue)
            {
                transaction.ReturnDate = request.ReturnDate.Value;
            }
            else if (newStatus == TransactionStatus.Returned)
            {
                transaction.ReturnDate = DateTime.Now;
            }

            // If returning the book, update book availability
            if (newStatus == TransactionStatus.Returned)
            {
                var book = await _unitOfWork.BookRepository.GetByIdAsync(transaction.BookId);
                if (book != null)
                {
                    book.AvailableCopies++;
                    book.UpdateUserId = _currentUserService.UserId;
                    book.UpdateTime = DateTime.Now;
                    _unitOfWork.BookRepository.Update(book);
                }
            }

            transaction.UpdateUserId = _currentUserService.UserId;
            transaction.UpdateTime = DateTime.Now;

            _unitOfWork.TransactionRepository.Update(transaction);
            await _unitOfWork.SaveChangesAsync();

            return new ApiResult
            {
                IsSuccess = true,
                Message = $"Transaction status updated to {newStatus} successfully",
                Data = new GetTransactionDto
                {
                    Id = transaction.Id,
                    UserId = transaction.UserId,
                    BookId = transaction.BookId,
                    RequestDate = transaction.RequestDate,
                    IssueDate = transaction.IssueDate,
                    DueDate = transaction.DueDate,
                    ReturnDate = transaction.ReturnDate,
                    Status = transaction.Status,
                    UserFullName = $"{transaction.User?.FirstName} {transaction.User?.LastName}",
                    BookName = transaction.Book?.Title ?? "Unknown Book"
                }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }
}
