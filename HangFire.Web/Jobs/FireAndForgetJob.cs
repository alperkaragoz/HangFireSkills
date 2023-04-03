using HangFire.Web.Services;

namespace HangFire.Web.Jobs
{
    public class FireAndForgetJob
    {

        public static void EmailSenderJob(string userId, string message)
        {
            Hangfire.BackgroundJob.Enqueue<IEmailSender>(x => x.EmailSend(userId, message));
        }
    }
}
