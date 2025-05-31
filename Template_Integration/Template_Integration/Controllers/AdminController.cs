using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mono.TextTemplating;
using Template_Integration.Models;

namespace Template_Integration.Controllers
{
    [Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
        private readonly ApplicationDbContext _Context;
        private readonly IWebHostEnvironment _root;

        public AdminController(ApplicationDbContext context, IWebHostEnvironment root)
        {
            _Context = context;
            _root = root;
        }

        public IActionResult Index()
		{
			return View();
		}

        //Category Section

        public async Task<IActionResult> Categories()
        {
            var categories = await _Context.Categories.ToListAsync();
            return View(categories);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> AddCategory(Categories cat)
		{
			await _Context.Categories.AddAsync(cat);
            await _Context.SaveChangesAsync();
			return RedirectToAction("Categories");
		}

		public async Task<IActionResult> UpdateCategory(int id)
        {
            var Categories = await _Context.Categories.FindAsync(id);
            return View(Categories);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Categories cat)
        {
            _Context.Entry(cat).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return RedirectToAction("Categories");
        }

        public async Task<IActionResult> RemoveCategory(int id)
        {
            var categories = await _Context.Categories.FindAsync(id);
            _Context.Categories.Remove(categories!);
            _Context.SaveChanges();

            return RedirectToAction("Categories");
        }

        //Category Section End


        //Product Section

        public IActionResult Products(Product pro)
        {
            var product = _Context.products.Include(res=>res.Category).ToList();
            return View(product);
        }

        public IActionResult AddProduct()
        {
            TempData["categories"] = _Context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product pro,IFormFile proimage)
        {
            TempData["categories"] = _Context.Categories.ToList();

            if (proimage != null)
            {
                var rootPath = _root.WebRootPath;
                var location = Path.Combine(rootPath, "Uploads", "Products");

                if (!Directory.Exists(location))
                {
                    Directory.CreateDirectory(location);
                }

                var fileLocation = Path.Combine(location, proimage.FileName);

                using (var stream = new FileStream(fileLocation, FileMode.Create))
                {
                    await proimage.CopyToAsync(stream);
                }
            }

            pro.ProductImage = proimage!.FileName;
            await _Context.products.AddAsync(pro);
            await _Context.SaveChangesAsync();

            return View();
        }

        public IActionResult UpdateProduct(int id)
        {
            TempData["categories"] = _Context.Categories.ToList();

            var product = _Context.products.Find(id);
            HttpContext.Session.SetString("priviousImage", product!.ProductImage);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product pro, IFormFile proimage)
        {
            TempData["categories"] = _Context.Categories.ToList();

            if (proimage != null)
            {
                var rootPath = _root.WebRootPath;
                var location = Path.Combine(rootPath, "Uploads", "Products");

                if (!Directory.Exists(location))
                {
                    Directory.CreateDirectory(location);
                }

                var priviousImage = HttpContext.Session.GetString("priviousImage");

                var oldFileLocation = Path.Combine(location, priviousImage!);

                if (System.IO.File.Exists(oldFileLocation))
                {
                    System.IO.File.Delete(oldFileLocation);
                }

                var newFileLocation = Path.Combine(location, proimage.FileName);

                using (var stream = new FileStream(newFileLocation, FileMode.Create))
                {
                    await proimage.CopyToAsync(stream);
                }

                pro.ProductImage = proimage.FileName;

                _Context.Entry(pro).State = EntityState.Modified;
                _Context.SaveChanges();
                return RedirectToAction("UpdateProduct", new { id = pro.ProductId });
            }
            else
            {
                var priviouseImage = HttpContext.Session.GetString("priviousImage");
                pro.ProductImage = priviouseImage!;

                _Context.Entry(pro).State = EntityState.Modified;
                _Context.SaveChanges();
                return RedirectToAction("UpdateProduct");
            }
        }

        public IActionResult RemoveProduct(int id)
        {
            var product = _Context.products.Find(id);
            var location = Path.Combine(_root.WebRootPath, "Uploads", "Products");
            var fileLocation = Path.Combine(location, product!.ProductImage);

            if (System.IO.File.Exists(fileLocation))
            {
                System.IO.File.Delete(fileLocation);
            }

            _Context.products.Remove(product);
            _Context.SaveChanges();

            return RedirectToAction("Products");
        }

        //Product Section End

    }
}
