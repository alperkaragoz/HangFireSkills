using System.Diagnostics;

namespace HangFire.Web.Jobs
{
    public class ContinuationsJob
    {
        public static void WriteWatermarkStatusJob(string jobId,string fileName)
        {
            Hangfire.BackgroundJob.ContinueJobWith(jobId,()=> Debug.WriteLine($"Added watermark to {fileName}"));
        }
    }
}
