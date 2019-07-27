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
    public class IndexModel : PageModel
    {
        private readonly BellsFishShop.Data.ApplicationDbContext _context;

        public IndexModel(BellsFishShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Facility> Facility { get;set; }

        public async Task OnGetAsync()
        {
            Facility = await _context.Facility.ToListAsync();
        }
    }
}
