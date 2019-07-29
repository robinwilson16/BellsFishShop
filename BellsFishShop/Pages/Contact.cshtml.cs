﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellsFishShop.Data;
using BellsFishShop.Models;
using BellsFishShop.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BellsFishShop.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ContactModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            FormSubmitted = false;
            EmailSent = false;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public Outlet Outlet { get; set; }

        public bool FormSubmitted { get; set; }
        public bool EmailSent { get; set; }

        public string OutletName { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Contact == null)
            {
                return NotFound();
            }

            FormSubmitted = true;

            if (ModelState.IsValid)
            {
                Outlet = await _context.Outlet
                .SingleOrDefaultAsync(m => m.OutletID == Contact.OutletID);

                if(Outlet != null)
                {
                    OutletName = Outlet.Title;
                }
                else {
                    OutletName = "Bells Fish Shop Contact Form";
                }

                string EmailSubject;
                string EmailBody;

                EmailSubject = "Bells Fish Shop Form";

                EmailBody =
                    @"
                    <!DOCTYPE html>
                    <html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"" xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background: #f1f1f1;margin: 0 auto !important;padding: 0 !important;height: 100% !important;width: 100% !important;"">
                    <head style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                        <meta charset=""utf-8"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;""> <!-- utf-8 works for most cases -->
                        <meta name=""viewport"" content=""width=device-width"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;""> <!-- Forcing initial-scale shouldn't be necessary -->
                        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;""> <!-- Use the latest (edge) version of IE rendering engine -->
                        <meta name=""x-apple-disable-message-reformatting"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">  <!-- Disable auto-scale in iOS 10 Mail entirely -->
                        <title style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;""></title> <!-- The title tag shows in email notifications, like Android 4.4. -->


                        <link href=""https://fonts.googleapis.com/css?family=Playfair+Display:400,400i,700,700i"" rel=""stylesheet"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">

                        <!-- CSS Reset : BEGIN -->
                    <style style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                    html,
                    body {
                        margin: 0 auto !important;
                        padding: 0 !important;
                        height: 100% !important;
                        width: 100% !important;
                        background: #f1f1f1;
                    }
                    /* What it does: Stops email clients resizing small text. */
                    * {
                        -ms-text-size-adjust: 100%;
                        -webkit-text-size-adjust: 100%;
                    }
                    /* What it does: Centers email on Android 4.4 */
                    div[style*=""margin: 16px 0""] {
                        margin: 0 !important;
                    }
                    /* What it does: Stops Outlook from adding extra spacing to tables. */
                    table,
                    td {
                        mso-table-lspace: 0pt !important;
                        mso-table-rspace: 0pt !important;
                    }
                    /* What it does: Fixes webkit padding issue. */
                    table {
                        border-spacing: 0 !important;
                        border-collapse: collapse !important;
                        table-layout: fixed !important;
                        margin: 0 auto !important;
                    }
                    /* What it does: Uses a better rendering method when resizing images in IE. */
                    img {
                        -ms-interpolation-mode:bicubic;
                    }
                    /* What it does: Prevents Windows 10 Mail from underlining links despite inline CSS. Styles for underlined links should be inline. */
                    a {
                        text-decoration: none;
                    }
                    /* What it does: A work-around for email clients meddling in triggered links. */
                    *[x-apple-data-detectors],  /* iOS */
                    .unstyle-auto-detected-links *,
                    .aBn {
                        border-bottom: 0 !important;
                        cursor: default !important;
                        color: inherit !important;
                        text-decoration: none !important;
                        font-size: inherit !important;
                        font-family: inherit !important;
                        font-weight: inherit !important;
                        line-height: inherit !important;
                    }
                    /* What it does: Prevents Gmail from displaying a download button on large, non-linked images. */
                    .a6S {
                        display: none !important;
                        opacity: 0.01 !important;
                    }
                    /* What it does: Prevents Gmail from changing the text color in conversation threads. */
                    .im {
                        color: inherit !important;
                    }
                    /* If the above doesn't work, add a .g-img class to any image in question. */
                    img.g-img + div {
                        display: none !important;
                    }
                    /* What it does: Removes right gutter in Gmail iOS app: https://github.com/TedGoas/Cerberus/issues/89  */
                    /* Create one of these media queries for each additional viewport size you'd like to fix */
                    /* iPhone 4, 4S, 5, 5S, 5C, and 5SE */
                    @media only screen and (min-device-width: 320px) and (max-device-width: 374px) {
                        u ~ div .email-container {
                            min-width: 320px !important;
                        }
                    }
                    /* iPhone 6, 6S, 7, 8, and X */
                    @media only screen and (min-device-width: 375px) and (max-device-width: 413px) {
                        u ~ div .email-container {
                            min-width: 375px !important;
                        }
                    }
                    /* iPhone 6+, 7+, and 8+ */
                    @media only screen and (min-device-width: 414px) {
                        u ~ div .email-container {
                            min-width: 414px !important;
                        }
                    }
                    </style>

                        <!-- CSS Reset : END -->

                        <!-- Progressive Enhancements : BEGIN -->
                    <style style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                    .primary{
	                    background: #f3a333;
                    }
                    .bg_white{
	                    background: #ffffff;
                    }
                    .bg_light{
	                    background: #fafafa;
                    }
                    .bg_black{
	                    background: #000000;
                    }
                    .bg_dark{
	                    background: rgba(0,0,0,.8);
                    }
                    .email-section{
	                    padding:2.5em;
                    }
                    /*BUTTON*/
                    .btn{
	                    padding: 10px 15px;
                    }
                    .btn.btn-primary{
	                    border-radius: 30px;
	                    background: #f3a333;
	                    color: #ffffff;
                    }
                    h1,h2,h3,h4,h5,h6{
	                    font-family: 'Playfair Display', serif;
	                    color: #000000;
	                    margin-top: 0;
                    }
                    body{
	                    font-family: 'Montserrat', sans-serif;
	                    font-weight: 400;
	                    font-size: 15px;
	                    line-height: 1.8;
	                    color: rgba(0,0,0,.4);
                    }
                    a{
	                    color: #f3a333;
                    }
                    table{
                    }
                    /*LOGO*/
                    .logo h1{
	                    margin: 0;
                    }
                    .logo h1 a{
	                    color: #000;
	                    font-size: 20px;
	                    font-weight: 700;
	                    text-transform: uppercase;
	                    font-family: 'Montserrat', sans-serif;
                    }
                    /*HERO*/
                    .hero{
	                    position: relative;
                    }
                    .hero img{
                    }
                    .hero .text{
	                    color: rgba(255,255,255,.8);
                    }
                    .hero .text h2{
	                    color: #ffffff;
	                    font-size: 30px;
	                    margin-bottom: 0;
                    }
                    /*HEADING SECTION*/
                    .heading-section{
                    }
                    .heading-section h2{
	                    color: #000000;
	                    font-size: 28px;
	                    margin-top: 0;
	                    line-height: 1.4;
                    }
                    .heading-section .subheading{
	                    margin-bottom: 20px !important;
	                    display: inline-block;
	                    font-size: 13px;
	                    text-transform: uppercase;
	                    letter-spacing: 2px;
	                    color: rgba(0,0,0,.4);
	                    position: relative;
                    }
                    .heading-section .subheading::after{
	                    position: absolute;
	                    left: 0;
	                    right: 0;
	                    bottom: -10px;
	                    content: '';
	                    width: 100%;
	                    height: 2px;
	                    background: #f3a333;
	                    margin: 0 auto;
                    }
                    .heading-section-white{
	                    color: rgba(255,255,255,.8);
                    }
                    .heading-section-white h2{
	                    font-size: 28px;
	                    font-family: 
	                    line-height: 1;
	                    padding-bottom: 0;
                    }
                    .heading-section-white h2{
	                    color: #ffffff;
                    }
                    .heading-section-white .subheading{
	                    margin-bottom: 0;
	                    display: inline-block;
	                    font-size: 13px;
	                    text-transform: uppercase;
	                    letter-spacing: 2px;
	                    color: rgba(255,255,255,.4);
                    }
                    .icon{
	                    text-align: center;
                    }
                    .icon img{
                    }
                    /*SERVICES*/
                    .text-services{
	                    padding: 10px 10px 0; 
	                    text-align: center;
                    }
                    .text-services h3{
	                    font-size: 20px;
                    }
                    /*BLOG*/
                    .text-services .meta{
	                    text-transform: uppercase;
	                    font-size: 14px;
                    }
                    /*TESTIMONY*/
                    .text-testimony .name{
	                    margin: 0;
                    }
                    .text-testimony .position{
	                    color: rgba(0,0,0,.3);
                    }
                    /*VIDEO*/
                    .img{
	                    width: 100%;
	                    height: auto;
	                    position: relative;
                    }
                    .img .icon{
	                    position: absolute;
	                    top: 50%;
	                    left: 0;
	                    right: 0;
	                    bottom: 0;
	                    margin-top: -25px;
                    }
                    .img .icon a{
	                    display: block;
	                    width: 60px;
	                    position: absolute;
	                    top: 0;
	                    left: 50%;
	                    margin-left: -25px;
                    }
                    /*COUNTER*/
                    .counter-text{
	                    text-align: center;
                    }
                    .counter-text .num{
	                    display: block;
	                    color: #ffffff;
	                    font-size: 34px;
	                    font-weight: 700;
                    }
                    .counter-text .name{
	                    display: block;
	                    color: rgba(255,255,255,.9);
	                    font-size: 13px;
                    }
                    /*FOOTER*/
                    .footer{
	                    color: rgba(255,255,255,.5);
                    }
                    .footer .heading{
	                    color: #ffffff;
	                    font-size: 20px;
                    }
                    .footer ul{
	                    margin: 0;
	                    padding: 0;
                    }
                    .footer ul li{
	                    list-style: none;
	                    margin-bottom: 10px;
                    }
                    .footer ul li a{
	                    color: rgba(255,255,255,1);
                    }
                    @media screen and (max-width: 500px) {
	                    .icon{
		                    text-align: left;
	                    }
	                    .text-services{
		                    padding-left: 0;
		                    padding-right: 20px;
		                    text-align: left;
	                    }
                    }
                    </style>


                    </head>

                    <body width=""100%"" style=""margin: 0 auto !important;padding: 0 !important;mso-line-height-rule: exactly;background-color: #222222;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background: #f1f1f1;font-family: 'Montserrat', sans-serif;font-weight: 400;font-size: 15px;line-height: 1.8;color: rgba(0,0,0,.4);height: 100% !important;width: 100% !important;"">
	                    <center style=""width: 100%;background-color: #f1f1f1;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                        <div style=""display: none;font-size: 1px;max-height: 0px;max-width: 0px;opacity: 0;overflow: hidden;mso-hide: all;font-family: sans-serif;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                          &zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;
                        </div>
                        <div style=""max-width: 600px;margin: 0 auto;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"" class=""email-container"">
    	                    <!-- BEGIN BODY -->
                          <table align=""center"" role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""margin: auto;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;border-spacing: 0 !important;border-collapse: collapse !important;table-layout: fixed !important;"">
      	                    <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                              <td class=""bg_white logo"" style=""padding: 1em 2.5em;text-align: center;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background: #ffffff;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
                                <img border=""0"" src=""http://dev.bellsfishshop.co.uk/images/BellsLogoBlack.png"" alt=""Bells Fish Shop"" />
                              </td>
	                          </tr><!-- end tr -->
				                    <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                              <td valign=""middle"" class=""hero"" style=""background-image: url(http://dev.bellsfishshop.co.uk/images/emails/FramwellgateHeader.jpg);background-size: cover;height: 400px;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;position: relative;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
                                <table style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;border-spacing: 0 !important;border-collapse: collapse !important;table-layout: fixed !important;margin: 0 auto !important;"">
            	                    <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
            		                    <td style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
            			                    <div class=""text"" style=""padding: 0 3em;text-align: center;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;color: rgba(255,255,255,.8);"">
            				                    <h2 style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;font-family: Arial, serif;color: #ffffff;margin-top: 0;font-size: 30px;margin-bottom: 0;"">Enquiry From " + Contact.Name + @"</h2>
            				                    <p style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;""><a href=""http://dev.bellsfishshop.co.uk"" class=""btn btn-primary"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;text-decoration: none;color: #ffffff;padding: 10px 15px;border-radius: 30px;background: #f3a333;margin-top: 50px;"">Go to Website</a></p>
            			                    </div>
            		                    </td>
            	                    </tr>
                                </table>
                              </td>
	                          </tr><!-- end tr -->
	                          <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
		                          <td class=""bg_white"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background: #ffffff;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
		                            <table role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;border-spacing: 0 !important;border-collapse: collapse !important;table-layout: fixed !important;margin: 0 auto !important;"">
		                              <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
		                                <td class=""bg_dark email-section"" style=""text-align: center;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background: rgba(0,0,0,.8);padding: 2.5em;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
		            	                    <div class=""heading-section heading-section-white"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;color: rgba(255,255,255,.8);"">
		              	                    <h2 style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;line-height: 1;color: #ffffff;margin-top: 0;font-size: 28px;line-height: 1.4;padding-bottom: 0;"">Enquiry from " + OutletName + @"</h2>
		            	                    </div>
		                                </td>
		                              </tr><!-- end: tr -->
		                              <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
		                                <td class=""bg_white email-section"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background: #ffffff;padding: 2.5em;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
		            	                    <div class=""heading-section"" style=""text-align: center;padding: 0 30px;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
		              	                    <h2 style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;font-family: 'Playfair Display', serif;color: #000000;margin-top: 0;font-size: 28px;line-height: 1.4;"">Enquiry Details</h2>
		            	                    </div>
		            	                    <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;border-spacing: 0 !important;border-collapse: collapse !important;table-layout: fixed !important;margin: 0 auto !important;"">
		            		                    <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                          <td valign=""top"" width=""50%"" style=""padding-top: 20px;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
                                            <table role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;border-spacing: 0 !important;border-collapse: collapse !important;table-layout: fixed !important;margin: 0 auto !important;"">
                                              <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                                <td class=""icon"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;text-align: center;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
                                                  <img src=""http://dev.bellsfishshop.co.uk/images/emails/User.png"" alt="""" style=""width: 60px;max-width: 600px;height: auto;margin: auto;display: block;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;-ms-interpolation-mode: bicubic;"">
                                                </td>
                                              </tr>
                                              <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                                <td class=""text-services"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;padding: 10px 10px 0;text-align: center;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
                            	                    <h3 style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;font-family: Arial, serif;color: #000000;margin-top: 0;font-size: 20px;"">" + Contact.Name + @"</h3>
                             	                    <p style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;""><a href=""tel:" + Contact.Telephone + @""">" + Contact.Telephone + @"</a></p>
                                                    <p style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;""><a href=""mailto:" + Contact.Email + @"?subject=Website Enquiry"">" + Contact.Email + @"</a></p>
                                                </td>
                                              </tr>
                                            </table>
                                          </td>
                                          <td valign=""top"" width=""50%"" style=""padding-top: 20px;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
                                            <table role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;border-spacing: 0 !important;border-collapse: collapse !important;table-layout: fixed !important;margin: 0 auto !important;"">
                                              <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                                <td class=""icon"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;text-align: center;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
                                                  <img src=""http://dev.bellsfishshop.co.uk/images/emails/Comments.png"" alt="""" style=""width: 60px;max-width: 600px;height: auto;margin: auto;display: block;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;-ms-interpolation-mode: bicubic;"">
                                                </td>
                                              </tr>
                                              <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                                <td class=""text-services"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;padding: 10px 10px 0;text-align: center;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
                            	                    <h3 style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;font-family: Arial, serif;color: #000000;margin-top: 0;font-size: 20px;"">Comments</h3>
                                                  <p style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%; white-space: pre-line;"">" + Contact.Enquiry + @"</p>
                                                </td>
                                              </tr>
                                            </table>
                                          </td>
                                        </tr>
		            	                    </table>
		                                </td>
		                              </tr><!-- end: tr -->
		                            </table>

		                          </td>
		                        </tr><!-- end:tr -->
                          <!-- 1 Column Text + Button : END -->
                          </table>
                          <table align=""center"" role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""margin: auto;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;border-spacing: 0 !important;border-collapse: collapse !important;table-layout: fixed !important;"">
                            <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
        	                    <td valign=""middle"" class=""bg_black footer email-section"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background: #000000;padding: 2.5em;color: rgba(255,255,255,.5);mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
        		                    <table style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;border-spacing: 0 !important;border-collapse: collapse !important;table-layout: fixed !important;margin: 0 auto !important;"">
            	                    <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                    <td valign=""top"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
                                      <table role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;border-spacing: 0 !important;border-collapse: collapse !important;table-layout: fixed !important;margin: 0 auto !important;"">
                                        <tr style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                          <td style=""text-align: left;padding-right: 10px;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;mso-table-lspace: 0pt !important;mso-table-rspace: 0pt !important;"">
                      	                    <p style=""-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">&copy; 2019 Bells Fish Shop</p>
                                          </td>
                                        </tr>
                                      </table>
                                    </td>
                                  </tr>
                                </table>
        	                    </td>
                            </tr>
                          </table>

                        </div>
                      </center>
                    </body>
                    </html>";

                string EmailFrom = "robin.wilson@rwsservices.net";
                string EmailTo = "robin.wilson@rwsservices.net";

                EmailSent = Mailer.SendMail(EmailFrom, EmailTo, null, null, EmailSubject, EmailBody);

            }

            if (Contact == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
