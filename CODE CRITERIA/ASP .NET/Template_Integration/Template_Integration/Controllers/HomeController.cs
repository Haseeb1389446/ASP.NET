using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Template_Integration.Models;

namespace Template_Integration.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Shop()
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

		public IActionResult Blog()
		{
			return View();
		}

		public IActionResult Contact()
		{
			return View();
		}
	}
}
