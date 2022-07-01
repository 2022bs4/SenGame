using Microsoft.AspNetCore.Mvc;
using SqlModels.Models;
using Services.Interface;
using System.Collections.Generic;
using System;

namespace SenGame.Controllers
{
    public class CommunityController : Controller
    {
        List<Game> Games = new List<Game>()
        {
            new Game{GameId=1,GameName="Crusader Kings III",GamePrice=898,GameIntroduction="愛戀、爭鬥、計謀並成就偉大。在《Crusader Kings III》這款大型戰略遊戲裡決定您的貴族家族的命運。在這個豐富、宏偉的中世紀模擬遊戲中，引領您的王朝血脈，死亡只是開始。",GameDetailsText="您的地位正等著您。選擇您的貴族家族，在跨越世代的中世紀史詩中率領您的王朝茁壯發展。戰爭只是建立統治的眾多工具之一，因為真正的戰略需要專業的外交技巧、對領土的掌握和真正的狡猾心思。《Crusader Kings III》延續 Paradox Development Studio 所推出的熱門遊戲系列，是一款集結廣受好評沈浸式大型戰略與深度、戲劇性中世紀角色扮演的作品。 仔細研究中世紀，掌握您的家族並擴展您的王朝。始於西元 867 或 1066 年，獲得領土、頭銜與附庸國，鞏固配得上您皇室血脈的王國。無論您的離世是否在計劃之內，都不影響大局，您的血統會由新的可遊玩角色所繼承。探索一個龐大的模擬世界，有著農民和騎士、朝臣、間諜、流氓與小丑，也別忘了還有秘密戀情。可以浪漫化、背叛、處決或巧妙地影響大量的歷史人物。探索一幅廣闊的中世紀地圖，從白雪覆蓋的北歐大陸延伸至非洲之角，從西部的不列顛群島延伸到東部富有異國情調的緬甸。佔領、征服並統治數以千計獨特的郡地、公國、王國和帝國。",TotalBuyCount=0,ReleaseTime=new DateTime(2020, 9, 2, 0, 0, 0),DownTime=null,Developer="Paradox Interactive",Marker="Paradox Development Studio"},

            new Game{GameId=2,GameName="太閤立志傳Ⅴ DX",GamePrice=1190,GameIntroduction="往昔的名作《太閤立志傳Ⅴ》在追加全新要素後，高清重製版終獲蘇生！舞臺為16世紀的日本。扮演以秀吉為首馳騁戰國亂世的史實人物，實現他們各自的夢想吧。既可以侍奉自己中意的大名，也可以自己作為大名統一天下。亦或以日本第一的忍者、水軍、商人為遊戲目標。除此之外，還有醫生、鍛冶匠、茶人等...",GameDetailsText="名作「太閤立志傳Ⅴ　完全攻略集」成為電子書，復刻登場！為可使用智慧型手機或PC方便閱覽的PDF版。※PS2版『太閤立志傳Ⅴ』的攻略本。未記載與「太閤立志傳Ⅴ DX」的追加要素等相關資訊。下載頁面請參照有記載序號的宣傳單。<br>※PDF形式檔案, 閱覽時請使用Adobe Acrobat Reader等，各種支援PDF的閱讀器。※Adobe，Adobe PDF和Adobe Reader是Adobe Systems Inc.在美國和其他國家或地區的商標或註冊商標。",TotalBuyCount=0,ReleaseTime=new DateTime(2022, 5, 19, 0, 0, 0),DownTime=null,Developer="KOEI TECMO GAMES CO., LTD.",Marker="KOEI TECMO GAMES CO., LTD."},

            new Game{GameId=3,GameName="超級機器人大戰30",GamePrice=1690,GameIntroduction="累積30年的歲月——戰鬥吧！為了這顆星球的未來 超級機器人大戰系列，是讓各種動畫作品中登場的機器人， 超越不同作品的藩籬齊聚一堂，迎戰共同敵人的模擬RPG遊戲。",GameDetailsText="玩家可在冒險環節觀看戰鬥前發生的劇情，在進入戰略模擬環節後，個別操作地圖上配置的機器人來破壞敵人。<br>戰鬥分為我方回合和敵方回合來輪流進行。<br>首先會由玩家來移動機器人進行戰鬥，再輪到敵方行動。<br>只要破壞地圖中配置的所有敵人就能通過關卡，來進入戰略環節。<br>在戰略環節可運用戰鬥獲得的資金和點數，來強化機器人與培育駕駛員。<br>而在結束戰略環節後，將會開始下一關的冒險環節。<br>體驗各種動畫原作的跨界融合故事以及機器人的戰鬥動畫影片，<br>並不斷強化培育自己喜歡的機器人和駕駛，就是超級機器人大戰的樂趣。",TotalBuyCount=0,ReleaseTime=new DateTime(2021, 10, 28, 0, 0, 0),DownTime=null,Developer="BANDAI NAMCO Entertainment",Marker="B.B.STUDIO CO.,LTD."},

            new Game{GameId=4,GameName="Total War: THREE KINGDOMS",GamePrice=2297,GameIntroduction="《Total War™: THREE KINGDOMS》是屢獲殊榮的《Total War》系列中第一款經典重現中國古代壯烈戰爭的作品。建設帝國與攻城掠地的回合制戰役，加上驚心動魄的即時戰鬥，《THREE KINGDOMS》以充滿英雄與傳奇的時代為舞台，顛覆了玩家對本系列的想像。",GameDetailsText="《Total War: THREE KINGDOMS》是屢獲殊榮的《Total War》策略遊戲系列中第一款經典重現中國古代壯烈戰爭的作品。建設帝國、治理國家與攻城掠地的回合制戰略遊戲，加上驚心動魄的即時戰鬥，《Total War: THREE KINGDOMS》以充滿英雄與傳奇的時代為舞台，顛覆了玩家對本系列的想像。<br>東漢末年（西元 190 年）歡迎來到這個群雄逐鹿的傳奇時代。<br>這個美麗卻分崩離析的國度呼求著新的皇帝，期望一改前朝，為人民開創嶄新的生活。您必須團結萬民一統中原，打造偉大王朝，並奠立萬古流傳的歷史地位。<br>從 12 位傳奇諸侯中挑選一位，征服天下。募集英雄豪傑輔佐您成就不世霸業，並在軍事、技術、政治和經濟等各領域戰勝敵人。<br>您是否能與締結牢固邦誼、組成緊密聯盟，並贏得多方仇敵的敬重？抑或您寧可背信棄義、狠心變節，願作滿腹政治謀略的一世梟雄？<br>屬於您的傳奇仍待下筆撰寫，然無庸置疑的是：光榮的征戰之路就在眼前。",TotalBuyCount=0,ReleaseTime=new DateTime(2019, 5, 23, 0, 0, 0),DownTime=null,Developer="SEGA, Feral Interactive (Mac), Feral Interactive (Linux)",Marker="CREATIVE ASSEMBLY, Feral Interactive (Mac), Feral Interactive (Linux)"},

            new Game{GameId=5,GameName="臨淵覺醒",GamePrice=310,GameIntroduction="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。 玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。",GameDetailsText="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。<br>在遊戲中，玩家的每次關卡體驗都是隨機的。每一次重新開始遊戲都是新的體驗。你可以使用不同的武器，在不同的關卡中選擇不同的天賦，體驗不同戰鬥節奏。<br>遊戲包含場外養成元素，玩家的每一次遊戲挑戰都可以提升場外天賦，永久加強自己的能力，使下次可以更輕鬆地擊敗深淵敵人。<br>遊戲目前還處於搶先體驗階段，我們會在接下來較長的一段時間裡逐漸完善遊戲修復bug、新增更多的內容和玩法。感謝你們的支持！我們會努力把遊戲做的更好。<br>如果你有任何問題、反饋，可以加入QQ群：1055013710，將問題的描述、截圖、錄屏等提供給我們，我們會盡快查證並進行修復。<br>遊戲特色：<br>· 中世紀+第三人稱+Roguelite+RPG組合玩法，在不斷的死亡輪迴中組建多種Build獲得不同的通關體驗。",TotalBuyCount=0,ReleaseTime=new DateTime(2022, 6, 19, 0, 0, 0),DownTime=null,Developer="TrinityBJ",Marker="TrinityBJ"},
        };

        private readonly IBaseService<Forum> _service;
        public CommunityController(IBaseService<Forum> service)
        {
            //this._service = new GenericService<Forum>(context);
            this._service = service;
        }
        public IActionResult Index()
        {
            TempData["action"] = "forum";

            return View();
        }
        //顯示討論區
        public IActionResult Forum() { 
            
            var data=_service.GetAll();
            return View(data);
        }
        public IActionResult ComomunityDynamicwall()
        {
            return View(); 
        }
    }
}
