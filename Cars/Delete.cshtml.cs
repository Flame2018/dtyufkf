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
    public class DeleteModel : PageModel
    {
        private readonly CRUD3._0.Data.ApplicationDbContext _context;

        public DeleteModel(CRUD3._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Automobiles = await _context.Automobiles.FindAsync(id);

            if (Automobiles != null)
            {
                _context.Automobiles.Remove(Automobiles);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
