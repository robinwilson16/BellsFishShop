using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellsFishShop.Models
{
    public class OpeningDay
    {
        public int OpeningDayID { get; set; }
        public string DayName { get; set; }

        public OutletOpeningTime OutletOpeningTime { get; set; }
    }
}
