using Abyweb.Data;
using Abyweb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abyweb.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
                
        public Category mycategory { get; set; }
        public CreateModel(ApplicationDbContext db)
        { 
            _db = db;
        }
        public void OnGet()
        {
        }
         
        public async Task<IActionResult> OnPost()        
        {

            if (mycategory.Name == mycategory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("mycategory.Name", "The Display Order cannot br same as the Name");

            }


            if (ModelState.IsValid) {
                await _db.Category_Db.AddAsync(mycategory);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category Created successfully";
                return RedirectToPage("Index");
            }
            return Page();
            
        }

    }
}
