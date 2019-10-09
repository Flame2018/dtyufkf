using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD3._0.Data;

namespace CRUD3._0.Pages.Manuf
{
    public class DetailsModel : PageModel
    {
        private readonly CRUD3._0.Data.ApplicationDbContext _context;

        public DetailsModel(CRUD3._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Manufacturers Manufacturers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturers = await _context.Manufacturers.FirstOrDefaultAsync(m => m.MID == id);

            if (Manufacturers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
