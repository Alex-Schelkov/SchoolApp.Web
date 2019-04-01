using SchoolApp.Web.Base;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace SchoolApp.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private TaskBoardSchool boardSchool;

        public AdminController(ApplicationDbContext context)
        {
            boardSchool = new TaskBoardSchool(context);

        }

        public IActionResult Index()
        {
            return View(boardSchool.GetRealTask());
        }

        [HttpGet]
        public IActionResult Execution(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var board = boardSchool.GetTask((int)id);

            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ready(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            boardSchool.InProcess((int)id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Comply(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            boardSchool.Сompleted((int)id);
            return RedirectToAction("Index");
        }
    }
}