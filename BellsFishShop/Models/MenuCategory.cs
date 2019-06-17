using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BellsFishShop.Models
{
    public class MenuCategory
    {
        public int MenuCategoryID { get; set; }

        public int MenuID { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "The menu category title is required (e.g. Starters/Mains)")]
        public string Title { get; set; }

        public string Description { get; set; }

        public Menu Menu { get; set; }

        public ICollection<MenuItem> MenuItem { get; set; }
    }
}
