using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD3._0.Data;

namespace CRUD3._0.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly CRUD3._0.Data.ApplicationDbContext _context;

        public EditModel(CRUD3._0.Data.ApplicationDbContext context)
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
           ViewData["MID"] = new SelectList(_context.Set<Manufacturers>(), "MID", "MID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Automobiles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutomobilesExists(Automobiles.AID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AutomobilesExists(int id)
        {
            return _context.Automobiles.Any(e => e.AID == id);
        }
    }
}
