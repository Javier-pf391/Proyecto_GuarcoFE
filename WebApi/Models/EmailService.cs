using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace WebApi.Models
{
    public class EmailService : Controller
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpSettings = _config.GetSection("SmtpSettings");

            using var message = new MailMessage();
            message.To.Add(new MailAddress(toEmail));
            message.From = new MailAddress(smtpSettings["SenderEmail"], smtpSettings["SenderName"]);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using var client = new SmtpClient(smtpSettings["Server"], int.Parse(smtpSettings["Port"]))
            {
                Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]),
                EnableSsl = bool.Parse(smtpSettings["EnableSsl"])
            };

            await client.SendMailAsync(message);
        }
    }
}
