using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BellsFishShop.Models
{
    public class Outlet
    {
        public int OutletID { get; set; }

        public string Title { get; set; }

        [Display(Name = "Main Details About This Outlet")]
        public string Details { get; set; }

        [Display(Name = "Photo of the Venue")]
        [Required]
        public string Photo { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Display(Name = "Address 3")]
        public string Address3 { get; set; }

        [Display(Name = "Address 4")]
        public string Address4 { get; set; }

        [Display(Name = "Post Code")]
        [Required]
        public string PostcodeOut { get; set; }

        [Display(Name = "Post Code")]
        [Required]
        public string PostcodeIn { get; set; }

        [Display(Name = "Telephone Number")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }

        [Display(Name = "Email")]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string GoogleMapLink { get; set; }
    }
}
