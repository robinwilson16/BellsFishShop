using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BellsFishShop.Models
{
    public class OutletOpeningTime
    {
        public int OutletOpeningTimeID { get; set; }

        public int OutletID { get; set; }

        public int DayID { get; set; }

        [DataType(DataType.Time)]
        public DateTime? OpeningTime1 { get; set; }

        [DataType(DataType.Time)]
        public DateTime? ClosingTime1 { get; set; }

        [DataType(DataType.Time)]
        public DateTime? OpeningTime2 { get; set; }

        [DataType(DataType.Time)]
        public DateTime? ClosingTime2 { get; set; }

        public Outlet Outlet { get; set; }
    }
}
