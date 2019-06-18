using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellsFishShop.Data;
using BellsFishShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BellsFishShop.Pages
{
    public class OutletModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public OutletModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Outlet Outlet { get; set; }

        public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(string outlet)
        {
            if (outlet == null)
            {
                return NotFound();
            }

            Outlet = await _context.Outlet.SingleOrDefaultAsync(m => m.OutletRef == outlet);

            if (Outlet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}