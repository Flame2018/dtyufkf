using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD3._0.Data;

namespace CRUD3._0.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly CRUD3._0.Data.ApplicationDbContext _context;

        public DetailsModel(CRUD3._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Automobiles Automobiles { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Automobiles = await _context.Automobiles
                .Include(a => a.ManID).FirstOrDefaultAsync(m => m.AID == id);

            if (Automobiles == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
