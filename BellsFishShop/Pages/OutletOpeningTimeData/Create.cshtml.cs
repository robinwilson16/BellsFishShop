using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BellsFishShop.Data;
using BellsFishShop.Models;

namespace BellsFishShop.Pages.OutletOpeningTimeData
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
        ViewData["OutletID"] = new SelectList(_context.Outlet, "OutletID", "Address1");
            return Page();
        }

        [BindProperty]
        public OutletOpeningTime OutletOpeningTime { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OutletOpeningTime.Add(OutletOpeningTime);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}