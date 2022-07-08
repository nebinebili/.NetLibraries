using HangFire.Web.BackgroundJobs;
using HangFire.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            // Istifadeci uzv olma metodu burd islenir.

            // Yeni uzv olan istifadecinin user Id al ver asagda gonder
            FireAndForgetJobs.EmailSendToUserJob("1234", "Welcome to our site.");
            return View();
        }

        public IActionResult PictureSave()
        {
            BackgroundJobs.RecurringJobs.ReportingJob();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PictureSave(IFormFile picture)
        {

            string newFileName = String.Empty;

            if(picture!=null && picture.Length > 0)
            {
                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", newFileName);

                using (var stream=new FileStream(path, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }

                string jobID = BackgroundJobs.DelayedJobs.AddWaterMarkJob(newFileName, "www.mysite.com");

                BackgroundJobs.ContinuationJobs.WriteWatermarkStatusJob(jobID,newFileName);
            }
            return View();
        }
    }
}
