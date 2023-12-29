using Abyweb.Data;
using Abyweb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abyweb.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
                
        public Category mycategory { get; set; }
        public EditModel(ApplicationDbContext db)
        { 
            _db = db;
        }
        public void OnGet(int Id )
        {

            mycategory = _db.Category_Db.Find(Id);
            //mycategory = _db.Category_Db.FirstOrDefault( u => u.Id == Id);
            //mycategory = _db.Category_Db.SingleOrDefault(u => u.Id == Id); 
            //mycategory = _db.Category_Db.Where(u => u.Id == Id).FirstOrDefault();

            //display data

        }
         
        public async Task<IActionResult> OnPost()        
        {

            if (mycategory.Name == mycategory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("mycategory.Name", "The Display Order cannot br same as the Name");

            }


            if (ModelState.IsValid) {
                 _db.Category_Db.Update(mycategory);
                await _db.SaveChangesAsync();

                TempData["success"] = "Category Updated successfully";

                return RedirectToPage("Index");
            }
            return Page();
            
        }

    }
}
