using Microsoft.AspNetCore.Mvc;
using SqlModels.FakeDate;
using SqlModels.Models;
using SqlModels.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SenGame.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Game()
        {
            var fakeDB = new Shop();

            List<GameViewModel> vm = fakeDB.Games
                .Select(g => 
                new GameViewModel
                {
                    //精選與推薦
                    Name=g.GameName,
                    OriginalPrice=g.GamePrice,

                    Types= fakeDB.GameTypes
                        .Where(gt=>gt.GameId== g.GameId)
                        .Select(gt=> fakeDB.Typelists.First(t=>t.TypelistId== gt.TypelistId).Name )
                        .ToList(),
                    ImgUrlList=fakeDB.gameMedia
                        .Where(gm=>gm.GameId== g.GameId && gm.InstructionType == 1&& gm.Instruction == 1)
                        .Select(gm=>gm.MediaUrl).Take(4).ToList(),
                    MainImgUrl = fakeDB.gameMedia
                        .Where(gm => gm.GameId == g.GameId&&gm.InstructionType==2)                        
                        .Select(gm => gm.MediaUrl).ToList(),
                    Discount =fakeDB.gameDiscounts
                        .Where(gd=>g.GameId==gd.GameId)
                        .Select(d=>d.DiscountTake).FirstOrDefault(),
                    ReleaseTime=g.ReleaseTime
                    //IsOn=
                    //if( g.ReleaseTime>/*現在的時間*/)
                    //    {
                    //        //顯示即將推出
                    //    }
                    //            else
                    //    {
                    //        現已推出
                    //    }

                    //特別優惠

                    //fakeDB.gameDiscounts
                    //.Where(gd=>gd.GameId==g.GameId)
                    //.Select(d=>d.DiscountTake)
                }).ToList();

            TempData["actiontype"] = "home";

            return View(vm);
        }

        public IActionResult Game_Category()
        {
            return View();
        }
    }
}
