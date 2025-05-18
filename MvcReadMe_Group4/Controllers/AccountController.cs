using Microsoft.AspNetCore.Mvc;
using MvcReadMe_Group4.Data;
using MvcReadMe_Group4.Models;
using MvcReadMe_Group4.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MvcReadMe_Group4.Controllers
{
    public class AccountController : Controller
    {
        private readonly MvcReadMe_Group4Context _context;

        public AccountController(MvcReadMe_Group4Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _context.Users
                .FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View(model);
            }

            if (user.Role == "Admin")
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            else if (user.Role == "User")
            {
                return RedirectToAction("Home", "User");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User role not recognized");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Password.Length < 6)
            {
                ModelState.AddModelError(nameof(model.Password), "Password must be at least 6 characters long");
                return View(model);
            }

            if (_context.Users.Any(u => u.UserName == model.UserName))
            {
                ModelState.AddModelError(nameof(model.UserName), "Username is already taken");
                return View(model);
            }

            var newUser = new User
            {
                UserName = model.UserName,
                Password = model.Password,
                Role = "User" // Default role
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
