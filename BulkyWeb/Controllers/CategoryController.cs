using BulkyWeb.Data;
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
}
