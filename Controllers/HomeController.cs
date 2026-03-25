using System.Diagnostics;
using CogniStack_Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace CogniStack_Website.Controllers
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
            ViewData["Title"] = "Home - CogniStack";
            return View();
        }

        public IActionResult Services()
        {
            ViewData["Title"] = "Services - CogniStack";
            return View();
        }

        public IActionResult Portfolio()
        {
            ViewData["Title"] = "Portfolio - CogniStack";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About - CogniStack";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact - CogniStack";
            return View();
        }

        public IActionResult Blog()
        {
            ViewData["Title"] = "Insights - CogniStack";
            return View();
        }
    }
}
