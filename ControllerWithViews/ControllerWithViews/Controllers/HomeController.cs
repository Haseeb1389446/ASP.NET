using ControllerWithViews.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControllerWithViews.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
