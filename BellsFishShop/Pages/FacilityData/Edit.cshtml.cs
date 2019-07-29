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

namespace BellsFishShop.Pages.FacilityData
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
        public Facility Facility { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Facility = await _context.Facility.FirstOrDefaultAsync(m => m.FacilityID == id);

            if (Facility == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Facility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityExists(Facility.FacilityID))
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

        private bool FacilityExists(int id)
        {
            return _context.Facility.Any(e => e.FacilityID == id);
        }
    }
}
