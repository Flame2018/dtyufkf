using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUD3._0.Data;

namespace CRUD3._0.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly CRUD3._0.Data.ApplicationDbContext _context;

        public CreateModel(CRUD3._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MID"] = new SelectList(_context.Set<Manufacturers>(), "MID", "MID");
            return Page();
        }

        [BindProperty]
        public Automobiles Automobiles { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Automobiles.Add(Automobiles);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}