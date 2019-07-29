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

namespace BellsFishShop.Pages.MenuItemData
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly BellsFishShop.Data.ApplicationDbContext _context;

        public DetailsModel(BellsFishShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
