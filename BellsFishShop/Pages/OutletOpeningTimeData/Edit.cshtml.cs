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

namespace BellsFishShop.Pages.OutletOpeningTimeData
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
           ViewData["OutletID"] = new SelectList(_context.Outlet, "OutletID", "Address1");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OutletOpeningTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutletOpeningTimeExists(OutletOpeningTime.OutletOpeningTimeID))
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

        private bool OutletOpeningTimeExists(int id)
        {
            return _context.OutletOpeningTime.Any(e => e.OutletOpeningTimeID == id);
        }
    }
}
