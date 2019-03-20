using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Application.IO.Site.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "[Assel] Confirmação de E-mail", $"Por favor confirme seu e-mail <a href='{ HtmlEncoder.Default.Encode(link) }'>clicando aqui</a>.");
        }
    }
}
