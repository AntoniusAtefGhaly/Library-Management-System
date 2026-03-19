using LMS.Application.Managers.Interfaces;

using Microsoft.Extensions.Configuration;

namespace LMS.Application.Services
{
    public class OverdueNotificationService
    {
        private readonly ITransactionService _transactionService;
        private readonly IConfiguration _configuration;

        public OverdueNotificationService(
            ITransactionService transactionService,
            IConfiguration configuration)
        {
            _transactionService = transactionService;
            _configuration = configuration;
        }

        public async Task ProcessOverdueNotifications()
        {
            try
            {
                var sentCount = await _transactionService.SendOverdueNotificationsAsync();
                Console.WriteLine($"✅ Successfully sent {sentCount} overdue notifications.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error processing overdue notifications: {ex.Message}");
            }
        }
    }
}