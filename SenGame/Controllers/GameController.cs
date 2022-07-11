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

            GameViewModel vm = new GameViewModel();
            
            //精選與推薦
            vm.RecommendVM = fakeDB.Games
                .OrderByDescending(g => g.TotalBuyCount)
                .Select(g =>
                    new RecommendViewModel
                    {                        
                        Name = g.GameName,
                        OriginalPrice = g.GamePrice,
                        Types = fakeDB.GameTypes
                            .Where(gt => gt.GameId == g.GameId)
                            .Select(gt => fakeDB.Typelists.First(t => t.TypelistId == gt.TypelistId).Name)
                            .ToList(),
                        ImgUrlList = fakeDB.gameMedia
                            .Where(gm => gm.GameId == g.GameId && gm.InstructionType == 1 && gm.Instruction == 1)
                            .Select(gm => gm.MediaUrl).Take(4).ToList(),
                        MainImgUrl = fakeDB.gameMedia
                            .FirstOrDefault(gm => gm.GameId == g.GameId && gm.InstructionType == 2)
                            ?.MediaUrl,
                        Discount = fakeDB.gameDiscounts
                            .Where(gd => g.GameId == gd.GameId)
                            .Select(d => d.DiscountTake).FirstOrDefault(),

                        DiscountPrice=g.GamePrice* (decimal)fakeDB.gameDiscounts
                            .Where(gd => g.GameId == gd.GameId)
                            .Select(d => d.DiscountTake).FirstOrDefault(),


                        ReleaseTime = g.ReleaseTime
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
                    })
                .ToList();

            //特別優惠
            vm.SpecialDiscountVM = fakeDB.Games
                .Where(g => fakeDB.gameDiscounts
                .Any(gd => gd.GameId == g.GameId && gd.DiscountTake != 1))
                .OrderByDescending(g => g.TotalBuyCount).Take(4)
                .Select(g =>
                new SpecialDiscountViewModel
                {
                    Name = g.GameName,

                    MainImgUrl = fakeDB.gameMedia
                        .FirstOrDefault(gm => gm.GameId == g.GameId && gm.InstructionType == 2)
                        ?.MediaUrl,
                    Discount = fakeDB.gameDiscounts
                        .Where(gd => g.GameId == gd.GameId)
                        .Select(d => d.DiscountTake).FirstOrDefault(),
                    DiscountPrice = g.GamePrice * (decimal)fakeDB.gameDiscounts
                            .Where(gd => g.GameId == gd.GameId)
                            .Select(d => d.DiscountTake).FirstOrDefault(),


                }).ToList();
            //熱門VR遊戲
            vm.PopVRVM = fakeDB.Games
                .Where(g => fakeDB.GameTypes.Any(gt => gt.GameId == g.GameId && gt.TypelistId == 7))
                .OrderByDescending(g => g.TotalBuyCount).Take(4)
                .Select(g =>
                    new PopVRViewModel
                    {
                        MainImgUrl = fakeDB.gameMedia
                            .FirstOrDefault(gm => gm.GameId == g.GameId && gm.InstructionType == 2)
                            ?.MediaUrl,
                        Discount = fakeDB.gameDiscounts
                            .Where(gd => g.GameId == gd.GameId)
                            .Select(d => d.DiscountTake).FirstOrDefault(),
                        OriginalPrice = g.GamePrice,
                        DiscountPrice = g.GamePrice * (decimal)fakeDB.gameDiscounts
                            .Where(gd => g.GameId == gd.GameId)
                            .Select(d => d.DiscountTake).FirstOrDefault(),
                    })
                .ToList();
            //低於300
            vm.LossThenPriceVM = fakeDB.Games
                .Where(g => g.GamePrice<300)
                .OrderByDescending(g => g.TotalBuyCount).Take(4)
                .Select(g =>
                    new LossThenPriceViewModel
                    {
                        MainImgUrl = fakeDB.gameMedia
                            .FirstOrDefault(gm => gm.GameId == g.GameId && gm.InstructionType == 2)
                            ?.MediaUrl,
                        Discount = fakeDB.gameDiscounts
                            .Where(gd => g.GameId == gd.GameId)
                            .Select(d => d.DiscountTake).FirstOrDefault(),
                        OriginalPrice = g.GamePrice,
                        DiscountPrice = g.GamePrice * (decimal)fakeDB.gameDiscounts
                            .Where(gd => g.GameId == gd.GameId)
                            .Select(d => d.DiscountTake).FirstOrDefault(),
                    })
                .ToList();
            //更新與優惠
            vm.UpdateDiscountVM = fakeDB.Games
                .Where(g => fakeDB.gameDiscounts.Any(gd=>gd.GameId== g.GameId)/*&&更新日期-當前日期<1個月*/)
                .OrderByDescending(g => g.TotalBuyCount).Take(4)
                .Select(g =>
                    new UpdateDiscountViewModel
                    {
                        MainImgUrl = fakeDB.gameMedia
                            .FirstOrDefault(gm => gm.GameId == g.GameId && gm.InstructionType == 2)
                            ?.MediaUrl,
                        Discount = fakeDB.gameDiscounts
                            .Where(gd => g.GameId == gd.GameId)
                            .Select(d => d.DiscountTake)
                            .FirstOrDefault(),
                        OriginalPrice = g.GamePrice,
                        DiscountPrice = g.GamePrice * (decimal)fakeDB.gameDiscounts
                            .Where(gd => g.GameId == gd.GameId)
                            .Select(d => d.DiscountTake).FirstOrDefault(),
                    })
                .ToList();

            vm.TabNewVM = fakeDB.Games
                //.Where(g=>g.ReleaseTime-當前時間<一個月)
                .OrderByDescending(g => g.TotalBuyCount)
                .Select(g =>
                    new TabViewModel
                    {
                        Name = g.GameName,
                        OriginalPrice = g.GamePrice,
                        Types = fakeDB.GameTypes
                            .Where(gt => gt.GameId == g.GameId)
                            .Select(gt => fakeDB.Typelists.First(t => t.TypelistId == gt.TypelistId).Name)
                            .ToList(),
                        ImgUrlList = fakeDB.gameMedia
                            .Where(gm => gm.GameId == g.GameId && gm.InstructionType == 1 && gm.Instruction == 1)
                            .Select(gm => gm.MediaUrl).Take(4).ToList(),
                        MainImgUrl = fakeDB.gameMedia
                            .FirstOrDefault(gm => gm.GameId == g.GameId && gm.InstructionType == 2)
                            ?.MediaUrl,
                        Discount = fakeDB.gameDiscounts
                            .Where(gd => g.GameId == gd.GameId)
                            .Select(d => d.DiscountTake).FirstOrDefault(),

                        DiscountPrice = g.GamePrice * (decimal)fakeDB.gameDiscounts
                            .Where(gd => g.GameId == gd.GameId)
                            .Select(d => d.DiscountTake).FirstOrDefault(),


                        ReleaseTime = g.ReleaseTime
                        
                    })
                .ToList();
            vm.TabHotVM = fakeDB.Games
                //.Where(g=>g.ReleaseTime-當前時間<一個月)
                .OrderByDescending(g => g.TotalBuyCount)
                .Select(g =>
                    new TabViewModel
                    {
                        Name = g.GameName,
                        OriginalPrice = g.GamePrice,
                        Types = fakeDB.GameTypes
                            .Where(gt => gt.GameId == g.GameId)
                            .Select(gt => fakeDB.Typelists.First(t => t.TypelistId == gt.TypelistId).Name)
                            .ToList(),
                        ImgUrlList = fakeDB.gameMedia
                            .Where(gm => gm.GameId == g.GameId && gm.InstructionType == 1 && gm.Instruction == 1)
                            .Select(gm => gm.MediaUrl).Take(4).ToList(),
                        MainImgUrl = fakeDB.gameMedia
                            .FirstOrDefault(gm => gm.GameId == g.GameId && gm.InstructionType == 2)
                            ?.MediaUrl,
                        Discount = fakeDB.gameDiscounts
                            .Where(gd => g.GameId == gd.GameId)
                            .Select(d => d.DiscountTake).FirstOrDefault(),

                        DiscountPrice = g.GamePrice * (decimal)fakeDB.gameDiscounts
                            .Where(gd => g.GameId == gd.GameId)
                            .Select(d => d.DiscountTake).FirstOrDefault(),


                        ReleaseTime = g.ReleaseTime

                    })
                .ToList();



            TempData["actiontype"] = "home";

            return View(vm);
        }

        public IActionResult Game_Category()
        {
            return View();
        }
    }
}
