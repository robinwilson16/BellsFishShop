using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BellsFishShop.Data;
using BellsFishShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace BellsFishShop.Pages.OutletFacilityData
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly BellsFishShop.Data.ApplicationDbContext _context;

        public EditModel(BellsFishShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["FacilityID"] = new SelectList(_context.Facility, "FacilityID", "FacilityID");
           ViewData["OutletID"] = new SelectList(_context.Outlet, "OutletID", "Address1");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OutletFacility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutletFacilityExists(OutletFacility.OutletFacilityID))
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

        private bool OutletFacilityExists(int id)
        {
            return _context.OutletFacility.Any(e => e.OutletFacilityID == id);
        }
    }
}
