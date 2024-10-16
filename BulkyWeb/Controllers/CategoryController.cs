using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;
public class CategoryController(ApplicationDbContext db) : Controller
{
    public IActionResult Index()
    {
        var categoryList = db.Category.ToList();

        return View(categoryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (category.Name == $"{category.DisplayOrder}")
            ModelState.AddModelError("name", "Name and Display Order should not be the same.");

        if (category.Name.Equals("test", StringComparison.CurrentCultureIgnoreCase))
            ModelState.AddModelError("", "Test is an invalid value.");

        if (ModelState.IsValid)
        {
            db.Category.Add(category);
            db.SaveChanges();
            TempData["success"] = "Category created successfully";

            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Edit(int? id)
    {
        if (id is null or 0)
            return NotFound(id);

        var fetchedCategory = db.Category.Find(id);
        return fetchedCategory == null ? NotFound(fetchedCategory) : View(fetchedCategory);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (category.Name == $"{category.DisplayOrder}")
            ModelState.AddModelError("name", "Name and Display Order should not be the same.");

        if (category.Name.Equals("test", StringComparison.CurrentCultureIgnoreCase))
            ModelState.AddModelError("", "Test is an invalid value.");

        if (ModelState.IsValid)
        {
            db.Category.Update(category);
            db.SaveChanges();
            TempData["success"] = "Category updated successfully";

            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id is null or 0)
            return NotFound(id);

        var fetchedCategory = db.Category.Find(id);
        return fetchedCategory == null ? NotFound(fetchedCategory) : View(fetchedCategory);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        var categoryToDelete = db.Category.Find(id);
        if (categoryToDelete == null) return NotFound(categoryToDelete);

        db.Category.Remove(categoryToDelete);
        db.SaveChanges();
        TempData["success"] = "Category deleted successfully";

        return RedirectToAction("Index");
    }
}