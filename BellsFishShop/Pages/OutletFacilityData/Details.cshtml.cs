using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BellsFishShop.Data;
using BellsFishShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace BellsFishShop.Pages.OutletFacilityData
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly BellsFishShop.Data.ApplicationDbContext _context;

        public DetailsModel(BellsFishShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public OutletFacility OutletFacility { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OutletFacility = await _context.OutletFacility
                .Include(o => o.Facility)
                .Include(o => o.Outlet).FirstOrDefaultAsync(m => m.OutletFacilityID == id);

            if (OutletFacility == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
