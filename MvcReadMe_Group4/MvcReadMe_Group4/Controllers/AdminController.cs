using Microsoft.AspNetCore.Mvc;

namespace YourProjectNamespace.Controllers
{
    public class AdminController : Controller
    {
        // GET: /Admin/Dashboard
        public IActionResult Dashboard()
        {
            ViewData["Title"] = "Dashboard";
            return View();
        }

        // GET: /Admin/Developers
        public IActionResult Developers()
        {
            ViewData["Title"] = "Developers";
            return View();
        }

        // GET: /Admin/About
        public IActionResult About()
        {
            ViewData["Title"] = "About";
            return View();
        }
    }
}
