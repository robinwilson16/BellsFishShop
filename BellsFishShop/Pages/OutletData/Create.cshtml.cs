using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BellsFishShop.Data;
using BellsFishShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace BellsFishShop.Pages.OutletData
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly BellsFishShop.Data.ApplicationDbContext _context;

        public CreateModel(BellsFishShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Outlet Outlet { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Outlet.Add(Outlet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}