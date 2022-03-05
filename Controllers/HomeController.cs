using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skilled_Force.Manager;
using Skilled_Force.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Skilled_Force.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SkilledForceDB skilledForceDB;

        public HomeController(ILogger<HomeController> logger, SkilledForceDB skilledForceDB)
        {
            _logger = logger;
            this.skilledForceDB = skilledForceDB;
        }

        public IActionResult Index()
        {
            if (TempData.Peek("UserId") != null)
            {
                ViewBag.jobs = GetList();
                return View();
            }                  
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
        public List<Job> GetList()
        {   
            if (TempData.Peek("RoleId").Equals("2"))
            {
                return skilledForceDB.Job.Where(j => j.CreatedBy == TempData.Peek("UserId").ToString()).OrderByDescending(j => j.UpdatedAt).ToList();
            }
            else
            {
                return skilledForceDB.Job.ToList();
            }
        }
    }
}
