using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewBag_ViewData_TempData.Models;

namespace ViewBag_ViewData_TempData.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserName = "Haseeb";
            return View();
        }
        public IActionResult About()
        {
            ViewData["UserEmail"] = "haseeb@gmail.com";
            return View();
        }
        public IActionResult Services()
        {
            TempData["UserPass"] = "123569";
            return View();
        }
    }
}
