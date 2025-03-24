using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Template_Integration.Models;

namespace Template_Integration.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!(await _roleManager.RoleExistsAsync("User"))) {
                    IdentityRole role = new()
                    {
                        Name = "User"
                    };

                    await _roleManager.CreateAsync(role);
                }

                if (!(await _roleManager.RoleExistsAsync("Admin")))
                {
                    IdentityRole role = new()
                    {
                        Name = "Admin"
                    };

                    await _roleManager.CreateAsync(role);
                }

                IdentityUser user = new()
                {
                    UserName = model.UserName,
                    Email = model.UserEmail,
                };

                await _userManager.CreateAsync(user,model.UserPassword);

                if (model.UserEmail == "admin@gmail.com") {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }

                return Redirect("login");
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var authenticated = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                if (authenticated.Succeeded)
                {
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                return View();
            }

            return View();
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }
    }
}
