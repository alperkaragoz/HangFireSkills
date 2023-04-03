using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace HangFire.Web.Services
{
    public class SendEmail : IEmailSender
    {

        private readonly IConfiguration _configuration;

        public SendEmail(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //https://mailtrap.io/inboxes/2164827/messages içindeki örnek kod metodu.
        public void EmailSend(string userId, string message)
        {

            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("b75f4bc142cddd", _configuration.GetSection("APIs")["EmailPassword"]),
                EnableSsl = true
            };
            client.Send("alperkaragoz@outlook.com", "alperkar23@hotmail.com", "Hello world", message);

        }

        public Task SendEmailAsync(string userId, string message)
        {
            throw new NotImplementedException();
        }
    }
}
