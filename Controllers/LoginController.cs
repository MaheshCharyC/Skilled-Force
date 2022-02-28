using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skilled_Force.Manager;
using Skilled_Force.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Skilled_Force.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly SkilledForceDB skilledForceDB;

        public LoginController(ILogger<LoginController> logger, SkilledForceDB skilledForceDB)
        {
            _logger = logger;
            this.skilledForceDB = skilledForceDB;
        }

        [HttpGet]
        public IActionResult LoginForm()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            User exisitngUser = skilledForceDB.User.Where(u => u.UserId == login.username && u.Password == login.password).FirstOrDefault();
            return RedirectToAction("Index", "Home");
        }

    }
}
