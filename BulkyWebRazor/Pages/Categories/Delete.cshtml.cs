using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories;

[BindProperties]
public class DeleteModel(ApplicationDbContext db) : PageModel
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
        var categoryToDelete = db.Category.Find(Category.Id);
        if (categoryToDelete == null) return NotFound(categoryToDelete);

        db.Category.Remove(categoryToDelete);
        db.SaveChanges();
        TempData["success"] = "Category deleted successfully";

        return RedirectToPage("Index");
    }
}
