using Microsoft.AspNetCore.Mvc;
using Sending_Data_With_dataObject.Models;
using System.Diagnostics;

namespace Sending_Data_With_dataObject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SubmitData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitData(string userName, string userAge, string userEmail)
        {
            ViewData["userName"] = userName;
            ViewData["userAge"] = userAge;
            ViewData["userEmail"] = userEmail;

            return View();
        }
    }
}
