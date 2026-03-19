//using LMS.Application.Managers.Interfaces;
//
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//namespace LMS.BL;

//public class OverdueNotificationBackgroundService : BackgroundService
//{
//    private readonly TimeSpan _interval;
//    private readonly IUnitOfWork _unitOfWork;
//    private readonly IEmailService _emailService;

//    public OverdueNotificationBackgroundService(IConfiguration configuration, IUnitOfWork unitOfWork, IEmailService emailService)
//    {
//        var checkIntervalMinutes = configuration.GetValue<int>("OverdueNotificationOptions:CheckIntervalMinutes");
//        _interval = TimeSpan.FromMinutes(checkIntervalMinutes);
//        _unitOfWork = unitOfWork;
//        _emailService = emailService;
//    }

//    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//    {
//        while (!stoppingToken.IsCancellationRequested)
//        {
//            var overdueTransactions = (await _unitOfWork.TransactionRepository.GetAllAsync())
//                .Where(t => t.Status == "Overdue" && (t.LastOverdueNotified == null || t.LastOverdueNotified.Value.Date < DateTime.Now.Date))
//                .ToList();

//            foreach (var transaction in overdueTransactions)
//            {
//                if (transaction.User?.Email != null)
//                {
//                    var subject = "Library Book Overdue Notice";
//                    var body = $"Dear {transaction.User.FirstName},\n\nYour borrowed book '{transaction.Book?.Title}' is overdue. Please return it as soon as possible.";

//                    await _emailService.SendEmailAsync(transaction.User.Email, subject, body);
//                    transaction.LastOverdueNotified = DateTime.Now;
//                }
//            }
//            await _unitOfWork.SaveChangesAsync();
//            await Task.Delay(_interval, stoppingToken);
//        }
//    }
//}

