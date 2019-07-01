using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BellsFishShop.Models
{
    public class Menu
    {
        public int MenuID { get; set; }

        [StringLength(50)]
        public string MenuRef { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "The menu title is required (e.g. Food/Drinks)")]
        public string Title { get; set; }

        [Display(Name = "Text Above Menu")]
        [StringLength(1000)]
        public string TextTop { get; set; }

        [Display(Name = "Text Below Menu")]
        [StringLength(1000)]
        public string TextBottom { get; set; }

        public ICollection<MenuCategory> MenuCategory { get; set; }
    }
}
