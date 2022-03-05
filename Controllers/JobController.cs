using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Skilled_Force.Manager;
using Skilled_Force.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Skilled_Force.Controllers
{
    public class JobController : Controller
    {
        private readonly ILogger<JobController> _logger;
        private readonly SkilledForceDB skilledForceDB;

        public JobController(ILogger<JobController> logger, SkilledForceDB skilledForceDB)
        {
            _logger = logger;
            this.skilledForceDB = skilledForceDB;
        }
        public IActionResult JobPostForm()
        {
            ViewBag.JobType = new List<SelectListItem>()
            {
                new SelectListItem { Value = "", Text = "Select"},
                new SelectListItem { Value = "JavaDeveloper", Text = "Java Developer"},
                new SelectListItem { Value = "WebDeveloper", Text = "Web Developer"},
                new SelectListItem { Value = "FrontEndDeveloper", Text = "FrontEnd Developer"},
                new SelectListItem { Value = "Tester", Text = "Tester"}
            };
            ViewBag.EmploymentType = new List<SelectListItem>()
            {
                new SelectListItem { Value = "", Text = "Select"},
                new SelectListItem { Value = "FullTime", Text = "Full Time"},
                new SelectListItem { Value = "PartTime", Text = "Part Time"}
            };
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult PostJob(Job job)
        {
            if (ModelState.IsValid)
            {
                skilledForceDB.Job.Add(job);
                skilledForceDB.SaveChanges();
            }
            else
            {
                return JobPostForm();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
