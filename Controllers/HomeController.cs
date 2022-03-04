using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skilled_Force.Models;
using System.Diagnostics;

namespace Skilled_Force.Controllers
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
            if (TempData.Peek("UserId") != null)
                return View();             
            else
                return RedirectToAction("LoginForm", "Account");
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

        [HttpGet]
        public IActionResult GetList()
        {
            if (TempData.Peek("role").Equals("Seeker"))
            {
                
            } else if (TempData.Peek("role").Equals("Employer"))
            {

            }
            else if (TempData.Peek("role").Equals("Admin"))
            {

            }
            return View();
        }
    }
}
