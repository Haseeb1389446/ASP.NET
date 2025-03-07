using Microsoft.AspNetCore.Mvc;
using Sending_Data_in_Database.Models;
using System.Diagnostics;

namespace Sending_Data_in_Database.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _Context;

        public HomeController(ApplicationDbContext context)
        {
            _Context = context;
        }

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
        public IActionResult SubmitData(Product product)
        {
            _Context.products.Add(product);
            _Context.SaveChanges();

            return View();
        }
    }
}
