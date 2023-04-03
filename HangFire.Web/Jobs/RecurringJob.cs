using Hangfire;
using System.Diagnostics;

namespace HangFire.Web.Jobs
{
    public class RecurringJob
    {

        public static void ReportingJob()
        {
            // cron -> örn linux işletim sistemlerinde istenilen görevleri arka planda belirli zaman aralığında gerçekleştirmek için kullanılan tool.
            // en.wikipedia.org/wiki/Cron
            // cronmaker.com sitesinden özelleştirilmiş cronlar oluşturulabilir.
            Hangfire.RecurringJob.AddOrUpdate("reportJobOne", () => EmailReport(),Cron.Minutely);
        }

        // Aylık olarak mail raporlaması yapan metot
        public static void EmailReport()
        {
            Debug.WriteLine("Report", "Sent mail");
        }
    }
}
