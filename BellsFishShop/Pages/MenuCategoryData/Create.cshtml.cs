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

namespace BellsFishShop.Pages.MenuCategoryData
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
        ViewData["MenuID"] = new SelectList(_context.Menu, "MenuID", "Title");
            return Page();
        }

        [BindProperty]
        public MenuCategory MenuCategory { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MenuCategory.Add(MenuCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}