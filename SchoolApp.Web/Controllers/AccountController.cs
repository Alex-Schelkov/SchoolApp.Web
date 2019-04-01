using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SchoolApp.Web.Base;
using SchoolApp.Web.Models;

namespace SchoolApp.Web.Controllers
{
    public class AccountController : Controller
    {
        loginMiddleware login;

        public AccountController(IConfiguration configuration)
        {
           login = new loginMiddleware(configuration["Password"]);
        }


        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Index","Admin");
        }

        [HttpGet]
        public IActionResult Login()
        {
            Password psw = new Password();
            return View(psw);
        }

        [HttpPost]
        public IActionResult Login(Password psw)
        {
           

            if (ModelState.IsValid && login.Login(psw.Value, HttpContext))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                
                ModelState.AddModelError("", "Неудачная попытка входа!");
                return View(psw);
            }
        }
    }
}