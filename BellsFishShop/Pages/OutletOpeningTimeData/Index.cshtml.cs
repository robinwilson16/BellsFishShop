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

namespace BellsFishShop.Pages.OutletOpeningTimeData
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly BellsFishShop.Data.ApplicationDbContext _context;

        public IndexModel(BellsFishShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<OutletOpeningTime> OutletOpeningTime { get;set; }

        public async Task OnGetAsync()
        {
            OutletOpeningTime = await _context.OutletOpeningTime
                .Include(o => o.Outlet).ToListAsync();
        }
    }
}
