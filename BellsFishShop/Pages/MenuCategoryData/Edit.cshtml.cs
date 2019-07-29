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

namespace BellsFishShop.Pages.MenuCategoryData
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
        public MenuCategory MenuCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MenuCategory = await _context.MenuCategory
                .Include(m => m.Menu).FirstOrDefaultAsync(m => m.MenuCategoryID == id);

            if (MenuCategory == null)
            {
                return NotFound();
            }
           ViewData["MenuID"] = new SelectList(_context.Menu, "MenuID", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MenuCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuCategoryExists(MenuCategory.MenuCategoryID))
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

        private bool MenuCategoryExists(int id)
        {
            return _context.MenuCategory.Any(e => e.MenuCategoryID == id);
        }
    }
}
