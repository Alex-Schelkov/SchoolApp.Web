using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Web.Models;

namespace SchoolApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var queryTask = db.TaskJornals.Where(x=>x.State.Id!=4);
            return View(queryTask);
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            TaskJornal task = new TaskJornal();
            return View(task);
        }


        [HttpPost]
        public IActionResult CreateTask(TaskJornal task)
        {
            if (ModelState.IsValid)
            {
                db.TaskJornals.Add(task);
            }

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
