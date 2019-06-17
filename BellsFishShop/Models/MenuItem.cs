using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BellsFishShop.Models
{
    public class MenuItem
    {
        public int MenuItemID { get; set; }

        public int MenuCategoryID { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "The menu item title is required (e.g. Cod/Salmon)")]
        public string Title { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public MenuCategory MenuCategory { get; set; }
    }
}
