using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SqlModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static SqlModels.Models.LineLogin;

namespace SenGame.Controllers
{
 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult CustomerService()
        {
            return View();
        }
        public IActionResult LineLoginDirect()
        {
            string response_type = "code";
            string client_id = "1657255042";
            string redirect_uri = HttpUtility.UrlEncode("https://localhost:44316/Home/Callback");
            string state = "aaa";
            string LineLoginUrl = string.Format("https://access.line.me/oauth2/v2.1/authorize?response_type={0}&client_id={1}&redirect_uri={2}&state={3}&scope=openid%20profile&nonce=09876xyz",
                response_type,
                client_id,
                redirect_uri,
                state
                );
            return Redirect(LineLoginUrl);
        }   
        public IActionResult Callback(string code, string state)
        {
            if (state == "aaa")
            {
                #region Api變數宣告
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                string result = string.Empty;
                NameValueCollection nvc = new NameValueCollection();
                #endregion
                try
                {
                    //取回Token
                    string ApiUrl_Token = "https://access.line.me/oauth2/v2.1/authorize";
                    nvc.Add("grant_type", "authorization_code");
                    nvc.Add("code", code);
                    nvc.Add("redirect_uri", "https://localhost:44316/Home/Index");
                    nvc.Add("client_id", "1657255042");
                    nvc.Add("client_secret", "65e11e6752e012793b85c7a7da8122da");
                    string JsonStr = Encoding.UTF8.GetString(wc.UploadValues(ApiUrl_Token, "POST", nvc));
                    LineLoginToken ToKenObj = JsonConvert.DeserializeObject<LineLoginToken>(JsonStr);
                    wc.Headers.Clear();

                    //取回User Profile
                    string ApiUrl_Profile = "https://api.line.me/v2/profile";
                    wc.Headers.Add("Authorization", "Bearer " + ToKenObj.access_token);
                    string UserProfile = wc.DownloadString(ApiUrl_Profile);
                    LineProfile ProfileObj = JsonConvert.DeserializeObject<LineProfile>(UserProfile);

                    return RedirectToAction("UserProfile", "Home", new { displayName = ProfileObj.displayName, pictureUrl = ProfileObj.pictureUrl });
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            return View();
        }

    }
}
