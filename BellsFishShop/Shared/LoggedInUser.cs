using BellsFishShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BellsFishShop.Shared
{
    public class LoggedInUser
    {
        public static string GetUserName(ClaimsPrincipal user)
        {
            string userName = "";
            
            if(user.Identity.Name != null)
            {
                userName = user.Identity.Name.ToString();
            }
                
            return userName;
        }

        public static bool IsAdmin(ClaimsPrincipal user)
        {
            bool isAdmin = false;

            if(user.IsInRole("Admin"))
            {
                isAdmin = true;
            }
            
            return isAdmin;
        }
    }
}
