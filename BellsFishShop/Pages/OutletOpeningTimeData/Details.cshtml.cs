using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BellsFishShop.Data;
using BellsFishShop.Models;

namespace BellsFishShop.Pages.OutletOpeningTimeData
{
    public class DetailsModel : PageModel
    {
        private readonly BellsFishShop.Data.ApplicationDbContext _context;

        public DetailsModel(BellsFishShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public OutletOpeningTime OutletOpeningTime { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OutletOpeningTime = await _context.OutletOpeningTime
                .Include(o => o.Outlet).FirstOrDefaultAsync(m => m.OutletOpeningTimeID == id);

            if (OutletOpeningTime == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
