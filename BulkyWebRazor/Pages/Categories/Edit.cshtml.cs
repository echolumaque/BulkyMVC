using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories;

[BindProperties]
public class EditModel(ApplicationDbContext db) : PageModel
{
    public required Category Category { get; set; }

    public void OnGet(int? id)
    {
        if (id is null or 0) { return; }
        var fethedCategory = db.Category.Find(id);
        if (fethedCategory == null) { return; }

        Category = fethedCategory;
    }

    public IActionResult OnPost()
    {
        if (Category.Name == $"{Category.DisplayOrder}")
            ModelState.AddModelError("name", "Name and Display Order should not be the same.");

        if (Category.Name.Equals("test", StringComparison.CurrentCultureIgnoreCase))
            ModelState.AddModelError("", "Test is an invalid value.");

        if (ModelState.IsValid)
        {
            db.Category.Update(Category);
            db.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToPage("Index");
        }

        return Page();
    }
}
