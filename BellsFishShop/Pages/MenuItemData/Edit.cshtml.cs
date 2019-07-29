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

namespace BellsFishShop.Pages.MenuItemData
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
        public MenuItem MenuItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MenuItem = await _context.MenuItem
                .Include(m => m.MenuCategory).FirstOrDefaultAsync(m => m.MenuItemID == id);

            if (MenuItem == null)
            {
                return NotFound();
            }
           ViewData["MenuCategoryID"] = new SelectList(_context.MenuCategory, "MenuCategoryID", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MenuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(MenuItem.MenuItemID))
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

        private bool MenuItemExists(int id)
        {
            return _context.MenuItem.Any(e => e.MenuItemID == id);
        }
    }
}
