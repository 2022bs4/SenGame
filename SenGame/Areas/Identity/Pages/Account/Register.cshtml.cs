using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using SqlModels.Models;
using SenGame.Service;
using Services;
using System.Net.Mail;
using System.Net;

namespace SenGame.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {

        private readonly SignInManager<UserModel> _signInManager;
        private readonly UserManager<UserModel> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<UserModel> userManager,
            SignInManager<UserModel> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            public string Account { get; set; }
            //[Required(ErrorMessage = "請輸入電子郵件信箱")]
            //[RegularExpression(@"/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z]+$/", ErrorMessage = "電子郵件格式不正確")]
            [EmailAddress]
            public string Email { get; set; }

            [Required(ErrorMessage = "請輸入密碼")]
            [StringLength(12, MinimumLength = 6, ErrorMessage = "最少輸入6個字元")]
            [DataType(DataType.Password)]
            [Display(Name = "密碼")]
            public string Password { get; set; }

            [Required(ErrorMessage = "請輸入密碼")]
            [StringLength(12, MinimumLength = 6, ErrorMessage = "最少輸入6個字元")]
            [DataType(DataType.Password)]
            [Display(Name = "核對密碼")]
            [Compare("Password", ErrorMessage = "兩次輸入的密碼不一致")]
            public string ConfirmPassword { get; set; }
            [Required]
            public string Address { get; set; }
            [Required(ErrorMessage ="請同意協定")]
            public string IsCheck { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            //判斷必填欄位是否都有填
            if (ModelState.IsValid)
            {
                var user = new UserModel 
                { 
                    Address = Input.Address,
                    Account = Input.Account,
                    UserName = Input.Account, 
                    Email = Input.Email,
                    CreateTime = DateTime.Now
                };
                //CreateAsync(user, password) //要建立的使用者，要雜湊和儲存的使用者密碼。
                var result = await _userManager.CreateAsync(user, Input.Password);
                
                if (result.Succeeded)
                {
                    _logger.LogInformation("創建一組新的帳密.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code, returnUrl = returnUrl },
                        protocol: Request.Scheme);


                    //寄出Email認證
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("SenGame@gmail.com", "SenGame");
                    msg.To.Add(Input.Email);
                    msg.Subject = "SenGame會員驗證";
                    msg.Body = $" <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>點擊驗證您的帳戶</a>";
                    msg.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25))
                    {

                        smtp.Credentials = new NetworkCredential("bboyskyovtc@gmail.com", "ohhngaacfvndkxhj");
                        smtp.EnableSsl = true;
                        smtp.Send(msg);
                    }


                    //Options:表示您可以用來設定身分識別系統的所有選項。
                    //SignIn:Options內的屬性，取得或設定身分 SignInOptions 識別系統的。
                    //RequireConfirmedAccount:SignIn裡面的屬性，如果使用者必須有已確認的帳戶才能登入，則為 True，否則為 false。
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        //跳轉頁面(Action)
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
