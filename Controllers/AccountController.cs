using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WALogin.Data;
using WALogin.Models;
using WALogin.Models.ViewModels;

namespace WALogin.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext _db;
        public AccountController(AppDbContext db)
        {
            _db = db;
        }
        //=======================================================
        public IActionResult Index()
        {
            return View(_db.Users);
        }
        //=======================================================
        public IActionResult Register()
        {
            ViewBag.Roles = new SelectList(_db.Roles, "RoleId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = new SelectList(_db.Roles, "RoleId", "Name");
                return View(model);
            }

            User user = new User() // Mapping to cook the models in right shape to pass it to employee
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                RoleId = model.RoleId,
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        //=======================================================
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {

            if (!ModelState.IsValid || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("", "Email and Password are required.");
                return View(model);
            }

            User user = new User() // Mapping to cook the models in right shape to pass it to employee
            {
                Email = model.Email,
                Password = model.Password
            };

            var dbUser = _db.Users.SingleOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (dbUser == null || dbUser.Password != model.Password)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }
            TempData["Message"] = "Login successful!";
            return RedirectToAction("Dashboard", new { userId = dbUser.Id });
        }
        //=======================================================
        public IActionResult Dashboard(int userId)
        {
            var user = _db.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return RedirectToAction("Login");
            }
            var model = new DashboardViewModel()
            {
                User = user,
                Role = user.Role
            };
            return View(model);
        }
    }
}
