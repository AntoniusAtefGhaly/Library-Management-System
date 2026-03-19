using LMS.Application.Dtos;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LMS.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserRepository _userRepository;

        public DashboardService(ITransactionRepository transactionRepository, IUserRepository userRepository)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
        }

        public async Task<DashboardDto> GetDashboardAsync(int count = 5)
        {
            return new DashboardDto
            {
                TransactionCount = await _transactionRepository.CountAsync(),
                ReturnedCount = await _transactionRepository.CountAsync(t => t.Status == TransactionStatus.Returned.ToString()),
                OverdueCount = await _transactionRepository.CountAsync(t => t.Status == TransactionStatus.Overdue.ToString()),
                MembersCount = await _userRepository.CountAsync(t => t.Role == "Member"),

                TopBooks = await GetTopBorrowedBooksAsync(count),
                TopAuthers = await GetTopBorrowedAuthorsAsync(count),
                TopCategories = await GetTopBorrowedCategoriesAsync(count),
                TopUsers = await GetTopBorrowingUsersAsync(count)

            };
        }
        private async Task<List<ChartDto>> GetTopBorrowingUsersAsync(int count = 5)
        {
            var topUsers = await _transactionRepository.GetAll()
                .Where(t => t.Status != TransactionStatus.Pending.ToString())
                .GroupBy(t => new { t.UserId, t.User.FirstName, t.User.LastName })
                .Select(g => new ChartDto
                {
                    Text = $"{g.Key.FirstName} {g.Key.LastName}",
                    Value = g.Count()
                })
                .OrderByDescending(u => u.Value)
                .Take(count)
                .ToListAsync();

            return topUsers;
        }

        private async Task<List<ChartDto>> GetTopBorrowedBooksAsync(int? count = 5)
        {
            var actualCount = count ?? 5;
            var topBooks = await _transactionRepository.GetAll()
                .Where(t => t.Status != TransactionStatus.Pending.ToString())
                .GroupBy(t => new { t.BookId, t.Book.Title })
                .Select(g => new ChartDto
                {
                    Text = g.Key.Title,
                    Value = g.Count()
                })
                .OrderByDescending(b => b.Value)
                .Take(actualCount)
                .ToListAsync();

            return topBooks;
        }

        private async Task<List<ChartDto>> GetTopBorrowedCategoriesAsync(int? count = 5)
        {
            var actualCount = count ?? 5;
            var topCategories = await _transactionRepository.GetAll()
                .Where(t => t.Status != TransactionStatus.Pending.ToString())
                .GroupBy(t => new { t.Book.CategoryId, t.Book.Category.Name })
                .Select(g => new ChartDto
                {
                    Text = g.Key.Name,
                    Value = g.Count()
                })
                .OrderByDescending(c => c.Value)
                .Take(actualCount)
                .ToListAsync();

            return topCategories;
        }

        private async Task<List<ChartDto>> GetTopBorrowedAuthorsAsync(int? count = 5)
        {
            var actualCount = count ?? 5;
            var topAuthors = await _transactionRepository.GetAll()
                .Where(t => t.Status != TransactionStatus.Pending.ToString())
                .GroupBy(t => new { t.Book.AuthorId, t.Book.Author.FullName })
                .Select(g => new ChartDto
                {
                    Text = g.Key.FullName,
                    Value = g.Count()
                })
                .OrderByDescending(a => a.Value)
                .Take(actualCount)
                .ToListAsync();

            return topAuthors;
        }
    }
}