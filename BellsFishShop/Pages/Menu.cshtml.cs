using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BellsFishShop.Pages
{
    public class MenuModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public MenuModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string MenuRef { get; set; }
        public bool? VegetarianOnly { get; set; }
        public bool? GlutenFreeOnly { get; set; }

        public void OnGet(string menu, bool? vegetarian, bool? glutenFree, bool? kiosk, int screen)
        {
            if (kiosk == true)
            {
                ViewData["KioskMode"] = true;
                ViewData["Screen"] = screen;
            }

            string defaultMenu = _configuration.GetSection("Menu")["DefaultMenu"];
            if (menu != null)
            {
                MenuRef = menu;
            }
            else
            {
                MenuRef = defaultMenu;
            }

            if (vegetarian != null)
            {
                VegetarianOnly = vegetarian;
            }

            if (glutenFree != null)
            {
                GlutenFreeOnly = glutenFree;
            }
        }
    }
}