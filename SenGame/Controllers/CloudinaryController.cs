using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

using System.IO;
using System;
using Newtonsoft.Json;

namespace SenGame.Controllers
{
    public class CloudinaryController : Controller
    {
        private readonly IConfiguration _config;
        private readonly Cloudinary _cloudinary;
        public CloudinaryController(IConfiguration config)
        {
            _config = config;
            //組態檔
            string cloudname = _config["Cloudinary:cloudname"];
            string apikey = _config["Cloudinary:apikey"];
            string apisecret = _config["Cloudinary:apisecret"];

            Account account = new Account(cloudname, apikey, apisecret);

            _cloudinary = new Cloudinary(account);
            _cloudinary.Api.Secure = true;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //File Upload單檔上傳
        public IActionResult CloudinaryUploadFile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CloudinaryUploadFile(IFormFile file)
        {
            //Get到檔按上傳後Post出上傳樣式 單檔上傳Post設定
            //非同步(async)方式，將回傳結果包裝成 Task<IActionResult>
            //IFormFile 初始化 FormFile 的新執行個體D
            //防呆
            if (file == null || file.Length == 0)
            {
                //控制器指定檢視的方式 生命週期為一個頁面
                ViewData["UploadMessage"] = "上傳檔案長度為0,失敗!";
                //要傳回的明確檢視："UploadResult"
                return View("UploadResult");
            }

            //取得作業系統的完整檔案路徑
            string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploadfiles", "ViewModel.jpg");

            //1.寫入MVC專案的wwwroot/UploadFiles資料夾
            try
            {

                //using 陳述式
                using (var stream = new FileStream(pathFile, FileMode.Create))
                {
                    //以非同步方式將上傳檔案內容Copy複製寫入FileStream檔案資料流
                    await file.CopyToAsync(stream);
                }

                //相對路徑
                string virtualPath = Url.Content("UploadFiles/" + file.FileName);

                //完整URL路徑
                string url = $"{Request.Scheme}://{Request.Host.Value}/{virtualPath}";

                ViewData["UploadMessage"] = $"上傳成功,檔案路徑為: {url}";

                //寫入Cloudinary雲端
                try
                {
                    //Notion有寫OOOOOOOOOOOOOOOOOOOOOOOOOO反正就是Cloudinary的咚咚
                    //反序列化
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(pathFile),
                        //要創建的檔名(會自動創建一個資料夾叫做Lemonnnn, 然後在Lemonnnn裡面再創一個叫img)
                        Folder = "Lemonnnn/img",
                        //要在網址後加的id編號
                        PublicId = file.FileName,  //(上傳自己叫就叫什麼)
                        //PublicId = "1_id"

                        /*重複的 PublicId 名會被蓋掉
                        討論 由後台掌控的圖片就取自己的 跟別人聊天的圖名子怎麼取?
                        http://res.cloudinary.com/chuschool/image/upload/v1656706038/Lemonnnn/img/1_id.png
                        https://res.cloudinary.com/chuschool/image/upload/v1656705702/Lemonnnn/img/01.png.png
                        https://res.cloudinary.com/chuschool/image/upload/v1656702555/01.png.png
                        */
                    };
                    //取得回傳結果物件
                    var uploadResult = _cloudinary.Upload(uploadParams);

                    //取得上傳圖片的url
                    ViewData["UploadUrl"] = $"上傳成功,檔案路徑為: {uploadResult.Url}";
                    ViewData["UploadPublicId"] = $"檔案FileName檔名為: {uploadResult.PublicId}";

                    ViewData["UploadFormat"] = $"檔案Format為: {uploadResult.Format}";
                    ViewData["UploadByte"] = $"檔案的大小為: {uploadResult.Bytes}";

                    //將ViewData的object型別 轉為 Json格式 (JSON Patch)
                    //SerializeObject 使用 方法來序列化 JsonPatchDocument
                    ViewData["FullInfo"] = JsonConvert.SerializeObject(uploadResult.JsonObj);

                }
                //呼叫 web 服務時 Http 有 Get到，但無法Post時，需要用到 Exception 來幫忙協助
                //無法Post時 (此時呼叫Server.Transfer，Server.Execute 以內部方式呼叫方法來傳輸控制項，並呼叫 Response.End 方法來結束處理目前的頁面。)
                //會收到網頁錯誤訊息(Response.End 結束頁面執行並呼叫 Thread.Abort 方法。 Thread.Abort方法會 ThreadAbortException 顯示錯誤訊息。)
                ////為了修正錯誤所以需要Exception
                catch (Exception ex)
                {
                    ViewData["UploadMessage"] = "上傳失敗:" + ex.ToString();
                }
            }
            catch (Exception ex)
            {
                ViewData["UploadMessage"] = "上傳失敗:" + ex.ToString();
            }
            //Cloudinary檔案上傳結果(這串只要有ViewData都會在這個頁面顯示，呼叫時才會出現)
            return View("CloudinaryUploadResult");
        }
    }
}
