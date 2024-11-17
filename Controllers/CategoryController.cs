using BulkyWeb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        BulkyDbContext _db;
        public CategoryController(BulkyDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.Distinct().ToList();
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            int id = category.CategoryId;
            if (category.CategoryName == Convert.ToString(category.DisplayOrder))
            {
                ModelState.AddModelError("Category Name", "Display Order can not be same as Category Name");
            }
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _db.Add(category);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View("Create", category);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                _db.Categories.Remove(category);
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            int id = category.CategoryId;
            if (ModelState.IsValid)
            {
                var tuple = _db.Categories.Find(id);
                if (tuple == null)
                {
                    return NotFound();
                }
                else
                {
                    tuple.CategoryName = category.CategoryName;
                    tuple.DisplayOrder = category.DisplayOrder;
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
