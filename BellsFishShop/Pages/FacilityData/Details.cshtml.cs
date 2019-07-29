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

namespace BellsFishShop.Pages.FacilityData
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly BellsFishShop.Data.ApplicationDbContext _context;

        public DetailsModel(BellsFishShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
