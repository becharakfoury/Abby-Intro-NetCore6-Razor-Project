using Abyweb.Data;
using Abyweb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abyweb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category mycategory { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int Id)
        {
            //display data - All below methods work
            mycategory = _db.Category_Db.Find(Id);
            //mycategory = _db.Category_Db.FirstOrDefault( u => u.Id == Id);
            //mycategory = _db.Category_Db.SingleOrDefault(u => u.Id == Id); 
            //mycategory = _db.Category_Db.Where(u => u.Id == Id).FirstOrDefault();

            

        }

        public async Task<IActionResult> OnPost()
        {

            var categoryfromdb = _db.Category_Db.Find(mycategory.Id);
            if(categoryfromdb != null)
            {
                _db.Category_Db.Remove(categoryfromdb);
                await _db.SaveChangesAsync();

                TempData["success"] = "Category deleted successfully";

                return RedirectToPage("Index");
            }
            
            return Page();
        }

    }
}
