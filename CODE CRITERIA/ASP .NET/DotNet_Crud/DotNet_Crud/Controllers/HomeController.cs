using DotNet_Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DotNet_Crud.Controllers
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

        public IActionResult ShowData()
        {
            var products = _Context.products.ToList();
            return View(products);
        }

        public IActionResult UpdateData(int id)
        {
            var products = _Context.products.Find(id);
            return View(products);
        }

        [HttpPost]
        public IActionResult UpdateData(Product prod)
        {
            _Context.Entry(prod).State = EntityState.Modified;
            _Context.SaveChanges();

            return View(prod);
        }

        public IActionResult DeleteData(int id)
        {
            var products = _Context.products.Find(id);
            _Context.products.Remove(products);
            _Context.SaveChanges();

            return RedirectToAction("ShowData");
        }
    }
}
