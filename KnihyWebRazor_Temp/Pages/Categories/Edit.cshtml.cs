using KnihyWebRazor_Temp.Data;
using KnihyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KnihyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category? Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet(int? id)
        {
            if(id!=null && id!=0)
            {
                Category = _db.Categories.FirstOrDefault(c => c.Id == id);
            }
        }
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category edited succesfully";
                return RedirectToPage("/Categories/Index");
            }
            else return Page();

        }
    }
}
