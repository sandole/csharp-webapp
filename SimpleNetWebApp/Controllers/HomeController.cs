using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleNetWebApp.Models;
using SimpleNetWebBusinessLayer;
using SimpleNetWebBusinessLayer.Models;
using System.Diagnostics;
using System.Text.Json;

namespace SimpleNetWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BusinessLogic _businessLogic;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _businessLogic = new BusinessLogic();
        }

        public IActionResult Index()
        {
            var author = JsonSerializer.Deserialize<Author>(_businessLogic.GetBooksByAuthor("tolkein"));
            return View(author);
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
    }
}
