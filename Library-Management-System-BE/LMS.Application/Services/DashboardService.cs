using LMS.Application.Dtos;
using LMS.Domain.Interfaces.Repositories;

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
            var topBooks = await _transactionRepository.GetTopBorrowedBookNamesAsync(count);
            var topAuthors = await _transactionRepository.GetTopBorrowedAuthorNamesAsync(count);
            var topCategories = await _transactionRepository.GetTopBorrowedCategoryNamesAsync(count);
            var topUsers = await _transactionRepository.GetTopBorrowingUserNamesAsync(count);

            return new DashboardDto
            {
                TransactionCount = await _transactionRepository.GetTransactionCountByStatusAsync(),
                ReturnedCount = await _transactionRepository.GetTransactionCountByStatusAsync(TransactionStatus.Returned.ToString()),
                OverdueCount = await _transactionRepository.GetTransactionCountByStatusAsync(TransactionStatus.Overdue.ToString()),
                MembersCount = await _userRepository.CountAsync(t => t.Role == "Member"),

                TopBooks = topBooks.Select(x => new ChartDto { Text = x.Key, Value = x.Value }).ToList(),
                TopAuthers = topAuthors.Select(x => new ChartDto { Text = x.Key, Value = x.Value }).ToList(),
                TopCategories = topCategories.Select(x => new ChartDto { Text = x.Key, Value = x.Value }).ToList(),
                TopUsers = topUsers.Select(x => new ChartDto { Text = x.Key, Value = x.Value }).ToList(),
            };
        }
    }
}