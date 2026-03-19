using LMS.Application.Managers.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace LMS.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _fromEmail;
        private readonly string _fromName;
        private readonly string _appPassword; // App password, NOT your real password

        public EmailService(IConfiguration configuration)
        {
            _fromEmail = configuration.GetValue<string>("EmailOptions:FromEmail")!;
            _fromName = configuration.GetValue<string>("EmailOptions:FromName")!;
            _appPassword = configuration.GetValue<string>("EmailOptions:AppPassword")!;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_fromName, _fromEmail));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = subject;

            message.Body = new TextPart("html") { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_fromEmail, _appPassword);
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }
    }
}