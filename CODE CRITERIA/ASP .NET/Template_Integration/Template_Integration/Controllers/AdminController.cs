using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Template_Integration.Controllers
{
    [Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        //Category Section

        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        public IActionResult UpdateCategory()
        {
            return View();
        }

        public IActionResult RemoveCategory()
        {
            return View();
        }

        //Category Section End


        //Product Section

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult UpdateProduct()
        {
            return View();
        }

        public IActionResult RemoveProduct()
        {
            return View();
        }

        //Product Section End

    }
}
