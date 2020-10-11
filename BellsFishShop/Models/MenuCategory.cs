using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BellsFishShop.Models
{
    public class MenuCategory
    {
        public int MenuCategoryID { get; set; }

        [JsonIgnore]
        [Display(Name = "Menu To Display On")]
        public int MenuID { get; set; }

        [Display(Name = "Category Title")]
        [StringLength(100)]
        [Required(ErrorMessage = "The menu category title is required (e.g. Starters/Mains)")]
        public string Title { get; set; }

        [Display(Name = "Additional Title Text")]
        [StringLength(100)]
        public string TitleExtra { get; set; }

        public string Description { get; set; }

        [Display(Name = "In kiosk mode, which screen to show this category on")]
        public int ScreenNumber { get; set; }

        [Display(Name = "Image to display on menu category when thumbnail is clicked")]
        [StringLength(500)]
        public string ImageURL { get; set; }

        [Display(Name = "Image Thumbnail to display on menu category")]
        [StringLength(500)]
        public string ThumbnailURL { get; set; }

        public int SortOrder { get; set; }

        [JsonIgnore]
        public Menu Menu { get; set; }

        public ICollection<MenuItem> MenuItem { get; set; }
    }
}
