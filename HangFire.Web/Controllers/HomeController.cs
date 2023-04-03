using Hangfire;
using HangFire.Web.Jobs;
using HangFire.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HangFire.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignUp()
        {
            // Job'ı oluşturuyoruz.
            FireAndForgetJob.EmailSenderJob("alperid", "TOLGANT");
            return View();
        }

        public IActionResult SavePicture()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SavePicture(IFormFile picture)
        {
            string newFileName = string.Empty;

            if (picture != null && picture.Length > 0)
            {
                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", newFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await picture.CopyToAsync(stream);
            }

            string jobId = Jobs.DelayedJob.AddWatermarkJob(newFileName,"www.alperkaragoz.com");

            return View();
        }
    }
}