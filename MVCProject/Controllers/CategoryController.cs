using ClientNotifications;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Data;
using MVCProject.Models;
using static ClientNotifications.Helpers.NotificationHelper;

namespace MVCProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        //private IClientNotification _clientNotification;

        //public CategoryController(IClientNotification clientNotification)
        //{
        //    _clientNotification = clientNotification;
        //}
        public IActionResult ListAll()
        {
            var data = _db.Categories;
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
           if(id == 0)
            {
                return NotFound();
            }
            var data = _db.Categories.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);

        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var data = _db.Categories.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);

            //_clientNotification.AddToastNotification("From Index of home",
            //                               NotificationType.success,
            //                               null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            if (model.Name == model.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and DisplayOrder Cannot be Same."); //Here error will be displayed below name property because we have used name as the key i.e  ModelState.AddModelError("Key", "Value"). Also esma name vaneko model ko name ho esma random name halna mildaina.
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(model);
                _db.SaveChanges();
                TempData["success"] = "Data Successfully Added";
                return RedirectToAction("ListAll");
            }
            return View(model);
        }
        //public IActionResult Delete(int id)
        //{
        //    return ();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category model)
        {
            if (model.Name == model.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and DisplayOrder Cannot be Same."); //Here error will be displayed below name property because we have used name as the key i.e  ModelState.AddModelError("Key", "Value")
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(model);
                _db.SaveChanges();
                TempData["success"] = "Data Successfully Edited";
                return RedirectToAction("ListAll");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category model)
        {
            if (model.Name == model.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and DisplayOrder Cannot be Same."); //Here error will be displayed below name property because we have used name as the key i.e  ModelState.AddModelError("Key", "Value")
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(model);
                _db.SaveChanges();
                TempData["error"] = "Data Successfully Deleted";
                return RedirectToAction("ListAll");
            }
            return View(model);
        }

    }
}
