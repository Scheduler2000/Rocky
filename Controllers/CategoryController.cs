using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using Rocky.Data;
using Rocky.Models;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _database;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _database = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _database.Category;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
                return NotFound();

            var category = _database.Category.FirstOrDefault(x => x.Id == id);

            return category == null ? NotFound() : View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            _database.Category.Update(category);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            _database.Category.Add(category);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = _database.Category.FirstOrDefault(x => x.Id == id);

            return category == null ? NotFound() : (IActionResult)View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {

            if (category == null)
                return NotFound();

            _database.Category.Remove(category);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
