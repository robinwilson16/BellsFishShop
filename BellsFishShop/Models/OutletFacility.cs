using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellsFishShop.Models
{
    public class OutletFacility
    {
        public int OutletFacilityID { get; set; }
        public int OutletID { get; set; }
        public int FacilityID { get; set; }
        public Outlet Outlet { get; set; }

        public Facility Facility { get; set; }
    }
}
