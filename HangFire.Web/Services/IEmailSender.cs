namespace HangFire.Web.Services
{
    public interface IEmailSender
    {
        void EmailSend(string userId, string message);
        Task SendEmailAsync(string userId, string message);
    }
}
