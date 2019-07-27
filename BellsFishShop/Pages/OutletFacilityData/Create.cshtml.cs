using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BellsFishShop.Data;
using BellsFishShop.Models;

namespace BellsFishShop.Pages.OutletFacilityData
{
    public class CreateModel : PageModel
    {
        private readonly BellsFishShop.Data.ApplicationDbContext _context;

        public CreateModel(BellsFishShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FacilityID"] = new SelectList(_context.Facility, "FacilityID", "FacilityID");
        ViewData["OutletID"] = new SelectList(_context.Outlet, "OutletID", "Address1");
            return Page();
        }

        [BindProperty]
        public OutletFacility OutletFacility { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OutletFacility.Add(OutletFacility);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}