using System.Drawing;

namespace HangFire.Web.Jobs
{
    public class DelayedJob
    {

        public static string AddWatermarkJob(string fileName, string watermarkText)
        {
            DateTimeOffset offset = DateTimeOffset.Now.AddSeconds(15);

            return Hangfire.BackgroundJob.Schedule(() => ApplyWatermark(fileName, watermarkText), offset);
        }
        public static void ApplyWatermark(string fileName, string watermarkText)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", fileName);

            // Width ve Height oluşturmak amacıyla
            using (var bitmap = Bitmap.FromFile(path))
            {
                // Width ve Height'ı olan imaj oluşturuyoruz.
                using (Bitmap tempBitmap = new Bitmap(bitmap.Width, bitmap.Height))
                {
                    // İçerisine yazı yazabilmek amacıyla
                    using (Graphics grp = Graphics.FromImage(tempBitmap))
                    {
                        grp.DrawImage(bitmap, 0, 0);

                        var font = new Font(FontFamily.GenericSerif, 25, FontStyle.Bold);
                        var color = Color.FromArgb(255, 0, 0);
                        var brush = new SolidBrush(color);
                        var point = new Point(20, bitmap.Height - 50);
                        grp.DrawString(watermarkText, font, brush, point);

                        tempBitmap.Save(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures/watermarks", fileName));
                    }
                }
            }
        }
    }
}
