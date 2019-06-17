using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellsFishShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BellsFishShop.Pages
{
    public class OutletModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public Contact Contact { get; set; }


    }
}