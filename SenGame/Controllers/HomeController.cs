using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SqlModels.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
        /// <summary>
        /// 驗證 Google 登入授權
        /// </summary>
        /// <returns></returns>
        //public IActionResult ValidGoogleLogin()
        //{
        //    string? formCredential = Request.Form["credential"]; //回傳憑證
        //    string? formToken = Request.Form["g_csrf_token"]; //回傳令牌
        //    string? cookiesToken = Request.Cookies["g_csrf_token"]; //Cookie 令牌

        //    // 驗證 Google Token
        //    GoogleJsonWebSignature.Payload? payload = VerifyGoogleToken(formCredential, formToken, cookiesToken).Result;
        //    if (payload == null)
        //    {
        //        // 驗證失敗
        //        TempData["Msg"] = "驗證 Google 授權失敗";
        //    }
        //    else
        //    {
        //        //驗證成功，取使用者資訊內容
        //        var email =  payload.Email;
        //        var name =  payload.Name;
        //        var pic =  payload.Picture;
        //        HttpContext.Response.Cookies.Append("Email", email);
        //        HttpContext.Response.Cookies.Append("Name", name);
        //        HttpContext.Response.Cookies.Append("Picture", pic);


        //    }
 
        //    return View("Index");
        //}

        /// <summary>
        /// 驗證 Google Token
        /// </summary>
        /// <param name="formCredential"></param>
        /// <param name="formToken"></param>
        /// <param name="cookiesToken"></param>
        /// <returns></returns>
        //public async Task<GoogleJsonWebSignature.Payload?> VerifyGoogleToken(string? formCredential, string? formToken, string? cookiesToken)
        //{
        //    // 檢查空值
        //    if (formCredential == null || formToken == null && cookiesToken == null)
        //    {
        //        return null;
        //    }

        //    GoogleJsonWebSignature.Payload? payload;
        //    try
        //    {
        //        // 驗證 token
        //        if (formToken != cookiesToken)
        //        {
        //            return null;
        //        }

        //        // 驗證憑證
        //        IConfiguration Config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
        //        string GoogleApiClientId = Config.GetSection("GoogleApiClientId").Value;
        //        var settings = new GoogleJsonWebSignature.ValidationSettings()
        //        {
        //            Audience = new List<string>() { GoogleApiClientId }
        //        };
        //        payload = await GoogleJsonWebSignature.ValidateAsync(formCredential, settings);
        //        if (!payload.Issuer.Equals("accounts.google.com") && !payload.Issuer.Equals("https://accounts.google.com"))
        //        {
        //            return null;
        //        }
        //        if (payload.ExpirationTimeSeconds == null)
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            DateTime now = DateTime.Now.ToUniversalTime();
        //            DateTime expiration = DateTimeOffset.FromUnixTimeSeconds((long)payload.ExpirationTimeSeconds).DateTime;
        //            if (now > expiration)
        //            {
        //                return null;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    return payload;
        //}
    }
}
