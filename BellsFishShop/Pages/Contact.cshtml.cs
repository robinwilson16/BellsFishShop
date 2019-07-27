using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellsFishShop.Models;
using BellsFishShop.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BellsFishShop.Pages
{
    public class ContactModel : PageModel
    {
        public void OnGet()
        {
            FormSubmitted = false;
            EmailSent = false;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public bool FormSubmitted { get; set; }
        public bool EmailSent { get; set; }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                string EmailSubject;
                string EmailBody;

                EmailSubject = "Bells Fish Shop Form";

                EmailBody =
                    @"
                    <html>
                    <head>
                    <title>" + EmailSubject + @"</title>
                    </head>
                    <body>
                    <table border=""0"" cellspacing=""0"" cellpadding=""6"">
                    <tr>
                    <td colspan=""4"">
                    <img border=""0"" src=""http://dev.bellsfishshop.co.uk/images/BellsLogoBlack.png"" alt=""Bells Fish Shop"" />
                    </td>
                    </tr>

                    <tr>
                    <td colspan=""4"">
                    <h2 style=""color: #00aeff;"">Personal Details</h2>
                    <hr stle=""border: 2px dashed #000080;"" />
                    </td>
                    </tr>

                    <tr>
                    <td>
                    Name
                    </td>
                    <td>
                    " + Contact.Name + @"
                    </td>
                    <td>
                    Telephone
                    </td>
                    <td>
                    <a href=""tel:" + Contact.Telephone + @""">" + Contact.Telephone + @"</a>
                    </td>
                    </tr>

                    <tr>
                    <td>
                    Email
                    </td>
                    <td colspan=""3"">
                    <a href=""mailto:" + Contact.Email + @"?subject=Website Enquiry"">" + Contact.Email + @"</a>
                    </td>
                    </tr>

                    <tr>
                    <td colspan=""4"">
                    <h2 style=""color: #00aeff;"">Your Enquiry</h2>
                    <hr stle=""border: 2px dashed #000080;"" />
                    </td>
                    </tr>

                    <tr>
                    <td colspan=""4"">
                    " + Contact.Enquiry + @"
                    </td>
                    </tr>
                
                    <tr>
                    <td colspan=""4"">
                    <hr stle=""border: 2px dashed #000080;"" />
                    <h3 style=""color: #1a9ead;"">Thanks for contacting Bells Fish Shop</h3>
                    <hr stle=""border: 2px dashed #000080;"" />
                    </td>
                    </tr>

                    </table>
                    </body>
                    </html>";

                string EmailFrom = "robin.wilson@rwsservices.net";
                string EmailTo = "robin.wilson@rwsservices.net";

                FormSubmitted = true;
                EmailSent = Mailer.SendMail(EmailFrom, EmailTo, null, null, EmailSubject, EmailBody);
            }
        }
    }
}
