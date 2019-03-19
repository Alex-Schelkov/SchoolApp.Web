using SchoolApp.Web.Base;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Web.Attribute;
using SchoolApp.Web.Models;

namespace SchoolApp.Web.Controllers
{
    public class AdminController : Controller
    {

        private TaskBoardSchool boardSchool;

        public AdminController(ApplicationDbContext context)
        {
            boardSchool = new TaskBoardSchool(context);
        }

        [CustomAuthorize]
        public IActionResult Index()
        {
            return View(boardSchool.GetRealTask());
        }

        [HttpGet]
        public IActionResult Execution(int id)
        {
            return View(boardSchool.GetTask(id));
        }


        [HttpPost]
        public IActionResult Ready(int? id)
        {
            if (id!=null)
                boardSchool.InProcess((int)id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Comply(int? id)
        {
            if (id != null)
                boardSchool.Сompleted((int)id);
            return RedirectToAction("Index");
        }
    }
}