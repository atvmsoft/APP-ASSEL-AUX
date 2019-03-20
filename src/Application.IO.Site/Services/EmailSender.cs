using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Application.IO.Site.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            SmtpClient smtpC = new SmtpClient("mail.cuptech.com.br", 587)
            {
                Credentials = new NetworkCredential("noreply@cuptech.com.br", "Maxp@@2332"),
                EnableSsl = true
            };

            MailMessage mMessage = new MailMessage()
            {
                From = new MailAddress("noreply@cuptech.com.br", "Cuptech - Assel System | Big Data"),
                IsBodyHtml = true
            };

            mMessage.Body = message;
            mMessage.Subject = subject;
            mMessage.To.Add(email);
            smtpC.Send(mMessage);

            return Task.CompletedTask;
        }
    }
}
