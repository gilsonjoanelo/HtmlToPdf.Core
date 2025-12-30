using System.Diagnostics;
using System.Runtime.InteropServices;

using HtmlToPdf.Core;
using HtmlToPdf.Core.Enums;
using HtmlToPdf.MVC.Models;

using Microsoft.AspNetCore.Mvc;

namespace HtmlToPdf.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PageToPdf()
        {
            var separator = System.IO.Path.DirectorySeparatorChar;
            var platform = GetPlatform();
            var customPath = "";
#if DEBUG
            customPath = $"debug{separator}net9.0{separator}";
#endif
            var path = $"{_webHostEnvironment.ContentRootPath}{separator}bin{separator}{customPath}" +
                $"runtimes{separator}{platform}{separator}native{separator}wkhtmltopdf.exe";
            var outputPath = $"{_webHostEnvironment.ContentRootPath}{separator}wwwroot{separator}files{separator}page.pdf";
            var outputPathDir = System.IO.Path.GetDirectoryName(outputPath)!;
            if (!System.IO.Directory.Exists(outputPathDir))
            {
                System.IO.Directory.CreateDirectory(outputPathDir);
            }

            using var pdf = new HtmlToPdfParser(path);
            pdf.Convert("https://www.google.com.br", outputPath, new ConvertOptions
            {
                PageSize = PageSize.A4,
                Orientation = PageOrientation.Portrait,
                Margins = new PageMargins()
            });
            return Redirect("/wwwroot/files/page.pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetPlatform()
        {
            var architecture = RuntimeInformation.OSArchitecture.ToString().ToLower();
            var osName = "win";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                osName = "linux";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                osName = "osx";
            }
            return $"{osName}-{architecture}";
        }
    }
}
