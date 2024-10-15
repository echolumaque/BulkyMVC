using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories;

public class IndexModel(ApplicationDbContext db) : PageModel
{
    public required List<Category> Categories { get; set; }

    public void OnGet()
    {
        Categories = db.Category.ToList();
    }
}
