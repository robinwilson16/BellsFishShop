using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellsFishShop.Data;
using BellsFishShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BellsFishShop.Pages
{
    public class OutletModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public OutletModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Outlet Outlet { get; set; }

        public Contact Contact { get; set; }

        public IList<OpeningDay> OpeningDay { get; set; }
        public IList<OutletOpeningTime> OutletOpeningTime { get; set; }
        public int CurrentDayNumber { get; set; }

        public async Task<IActionResult> OnGetAsync(string outlet)
        {
            if (outlet == null)
            {
                return NotFound();
            }

            int[] daysOfWeek = Enumerable.Range(0, 7).ToArray();

            DateTime currentDate = DateTime.Now;
            CurrentDayNumber = (int)currentDate.DayOfWeek;

            OpeningDay = new List<OpeningDay>();
            foreach (var day in daysOfWeek)
            {
                OpeningDay.Add(new OpeningDay
                {
                    OpeningDayID = day,
                    DayName = Enum.GetName(typeof(DayOfWeek), day)
                });
            }

            //Fix ordering of days of week
            OpeningDay = OpeningDay.OrderBy(d =>
                d.OpeningDayID > 0 ? 1 :
                d.OpeningDayID == 0 ? 2 :
                3
            )
                .ThenBy(d =>
                    d.OpeningDayID
                )
                .ToList();

            Outlet = await _context.Outlet
                .Include(o => o.OutletOpeningTime)
                .Include(o => o.OutletFacility)
                .ThenInclude(o => o.Facility)
                .SingleOrDefaultAsync(m => m.OutletRef == outlet);

            if (Outlet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}