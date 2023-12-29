using Abyweb.Data;
using Abyweb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abyweb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        public IEnumerable<Category> Categories { get; set; }   


        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Category_Db;


        }
    }
}
