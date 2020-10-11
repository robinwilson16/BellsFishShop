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

namespace BellsFishShop.Pages.MenuData
{
    public class IndexModel : PageModel
    {
        private readonly BellsFishShop.Data.ApplicationDbContext _context;

        public IndexModel(BellsFishShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Menu> Menu { get;set; }
        public IList<MenuCategory> MenuCategory { get; set; }
        public IList<MenuItem> MenuItem { get; set; }

        public async Task OnGetAsync()
        {
            Menu = await _context.Menu.ToListAsync();
        }

        public async Task<IActionResult> OnGetJsonAsync(string menu)
        {
            //Menu = await _context.Menu
            //    .Include(c => c.MenuCategory)
            //    .ThenInclude(c => c.MenuItem)
            //    .Where(m => m.MenuRef == menu)
            //    .ToListAsync();

            Menu = await _context.Menu
                .Where(m => m.MenuRef == menu)
                .ToListAsync();

            MenuCategory = await _context.MenuCategory
                .OrderBy(c => c.SortOrder)
                .ToListAsync();

            MenuItem = await _context.MenuItem
                .OrderBy(i => i.SortOrder)
                .ToListAsync();

            var MenuData = new
            {
                menuData = Menu
            };

            return new JsonResult(MenuData);
        }
    }
}
