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
    public class IndexModel : PageModel
    {
        private readonly CRUD3._0.Data.ApplicationDbContext _context;

        public IndexModel(CRUD3._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Automobiles> Automobiles { get;set; }

        public async Task OnGetAsync()
        {
            Automobiles = await _context.Automobiles
                .Include(a => a.ManID).ToListAsync();
        }
    }
}
