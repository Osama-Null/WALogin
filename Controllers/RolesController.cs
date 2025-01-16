using Microsoft.AspNetCore.Mvc;
using WALogin.Data;
using WALogin.Models;

namespace WALogin.Controllers
{
    public class RolesController : Controller
    {
        private AppDbContext _db;
        public RolesController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Roles);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            _db.Roles.Add(role);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
