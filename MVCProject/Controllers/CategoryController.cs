using Microsoft.AspNetCore.Mvc;
using MVCProject.Data;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult ListAll()
        {
            var data = _db.Categories;
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
