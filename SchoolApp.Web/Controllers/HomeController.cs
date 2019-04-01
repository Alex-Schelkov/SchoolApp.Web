using System.Diagnostics;
using SchoolApp.Web.Base;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Web.Models;

namespace SchoolApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private TaskBoardSchool boardSchool;

        public HomeController(ApplicationDbContext context)
        {
          
            boardSchool = new TaskBoardSchool(context);
        }

        public IActionResult Index()
        {
            return View(boardSchool.GetRealTask());
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            return View(new TaskJornal());
        }

        [HttpGet]
        public IActionResult Access(int? id)
        {
           if(id==null)
            {
                return BadRequest();
            }

           var board =  boardSchool.GetTask((int)id);

            if (board==null)
            {
                return NotFound();
            }
           return View(board);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTask(TaskJornal task)
        {

            if (!ModelState.IsValid) return View(task);
            
                boardSchool.AddTask(task);
                return RedirectToAction("Access",new {id= task.Id});
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
