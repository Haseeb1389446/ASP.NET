using Microsoft.AspNetCore.Mvc;
using Template_Integration.Models;

namespace Template_Integration.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel model)
        {
            if(ModelState.IsValid)
            {
                return View(model);
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }
    }
}
