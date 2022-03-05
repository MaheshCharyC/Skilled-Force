using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Skilled_Force.Manager;
using Skilled_Force.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Skilled_Force.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SkilledForceDB skilledForceDB;

        public AccountController(ILogger<AccountController> logger, SkilledForceDB skilledForceDB)
        {
            _logger = logger;
            this.skilledForceDB = skilledForceDB;
        }

        [HttpGet]
        public IActionResult LoginForm()
        {
            return View("LoginForm");
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
            User exisitngUser = getUserIfExists(login.Email, login.Password);
            if (exisitngUser != null)
            {
                TempData["UserId"] = exisitngUser.UserId;
                TempData["Email"] = exisitngUser.Email;
                TempData["FirstName"] = exisitngUser.FirstName;
                TempData["RoleId"] = exisitngUser.RoleId;
                ViewData["success"] = true;
                return RedirectToAction("Index", "Home");
            }
            ViewData["success"] = false;
            return LoginForm();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (TempData.Peek("UserId") != null)
                TempData.Clear();
            return LoginForm();
        }

        [HttpGet]
        public IActionResult Register()
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            foreach (Role role in GetRoles  ())
            {
                roles.Add(new SelectListItem { Value = role.RoleId, Text = role.Name});
            }
            ViewBag.roles = roles;
            ViewBag.Gender = new List<SelectListItem>() {
                new SelectListItem { Value = "", Text = ""},
                new SelectListItem { Value = "Male", Text = "Male"},
                new SelectListItem { Value = "Female", Text = "Female"},
                new SelectListItem { Value = "Other", Text = "Other"},
            };
            return View("RegistrationForm");
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                User exisitngUser = getUserIfExists(user.Email, user.Password);
                if (exisitngUser != null)
                {
                    skilledForceDB.User.Add(user);
                    skilledForceDB.SaveChanges();
                    TempData["SuccessMessage"] = "Saved User Successfully";
                }
                else
                {
                    TempData["Error"] = "User Email exists";
                    return Register();
                }
            }
            else
            {
                return Register();
            }
            return LoginForm();
        }

        private User getUserIfExists(string Email, string Password)
        {
            return skilledForceDB.User.Where(u => u.Email == Email && u.Password == Password).FirstOrDefault();
        }

        public List<Role> GetRoles() => skilledForceDB.Role.ToList();

    }
}
