using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Abyweb.Data;
using Abyweb.Model;

namespace Abyweb.Pages.ScafoldingCategories
{
    public class DetailsModel : PageModel
    {
        private readonly Abyweb.Data.ApplicationDbContext _context;

        public DetailsModel(Abyweb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Category Category { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Category_Db == null)
            {
                return NotFound();
            }

            var category = await _context.Category_Db.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }
    }
}
