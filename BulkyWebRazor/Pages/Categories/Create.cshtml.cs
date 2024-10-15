using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories;

[BindProperties]
public class CreateModel(ApplicationDbContext db) : PageModel
{
    public Category Category { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (Category.Name == $"{Category.DisplayOrder}")
            ModelState.AddModelError("name", "Name and Display Order should not be the same.");

        if (Category.Name.Equals("test", StringComparison.CurrentCultureIgnoreCase))
            ModelState.AddModelError("", "Test is an invalid value.");

        if (ModelState.IsValid)
        {
            db.Category.Add(Category);
            db.SaveChanges();
            TempData["success"] = "Category created successfully";

            return RedirectToPage("Index");
        }
        else
        {
            return Page();
        }
    }
}
