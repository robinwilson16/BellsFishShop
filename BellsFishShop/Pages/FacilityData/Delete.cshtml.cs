using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BellsFishShop.Data;
using BellsFishShop.Models;

namespace BellsFishShop.Pages.FacilityData
{
    public class DeleteModel : PageModel
    {
        private readonly BellsFishShop.Data.ApplicationDbContext _context;

        public DeleteModel(BellsFishShop.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Facility = await _context.Facility.FindAsync(id);

            if (Facility != null)
            {
                _context.Facility.Remove(Facility);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
