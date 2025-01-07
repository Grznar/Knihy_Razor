using KnihyWebRazor_Temp.Data;
using KnihyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KnihyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public Category? Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Category created succesfully";
            return RedirectToPage("Index");
        }
    }
}
