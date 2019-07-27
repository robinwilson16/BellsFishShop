using Newtonsoft.Json;
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

        [JsonIgnore]
        public int MenuID { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "The menu category title is required (e.g. Starters/Mains)")]
        public string Title { get; set; }

        [Display(Name = "Additional Title Text")]
        [StringLength(100)]
        public string TitleExtra { get; set; }

        public string Description { get; set; }

        [Display(Name = "In kiosk mode, which screen to show this category on")]
        public int ScreenNumber { get; set; }


        [JsonIgnore]
        public Menu Menu { get; set; }

        public ICollection<MenuItem> MenuItem { get; set; }
    }
}
