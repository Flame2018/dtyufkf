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
    public class IndexModel : PageModel
    {
        private readonly CRUD3._0.Data.ApplicationDbContext _context;

        public IndexModel(CRUD3._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Manufacturers> Manufacturers { get;set; }

        public async Task OnGetAsync()
        {
            Manufacturers = await _context.Manufacturers.ToListAsync();
        }
    }
}
