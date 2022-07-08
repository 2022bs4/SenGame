using SqlModels.Models;
using System;
using System.Collections.Generic;

namespace SqlModels.FakeDate
{
    
    public class Shop
    {
        
        public List<Game> Games = new List<Game>()
        {
            new Game{GameId=1,GameName="Crusader Kings III",GamePrice=898,GameIntroduction="愛戀、爭鬥、計謀並成就偉大。在《Crusader Kings III》這款大型戰略遊戲裡決定您的貴族家族的命運。在這個豐富、宏偉的中世紀模擬遊戲中，引領您的王朝血脈，死亡只是開始。",GameDetailsText="您的地位正等著您。選擇您的貴族家族，在跨越世代的中世紀史詩中率領您的王朝茁壯發展。戰爭只是建立統治的眾多工具之一，因為真正的戰略需要專業的外交技巧、對領土的掌握和真正的狡猾心思。《Crusader Kings III》延續 Paradox Development Studio 所推出的熱門遊戲系列，是一款集結廣受好評沈浸式大型戰略與深度、戲劇性中世紀角色扮演的作品。<br/> 仔細研究中世紀，掌握您的家族並擴展您的王朝。始於西元 867 或 1066 年，獲得領土、頭銜與附庸國，鞏固配得上您皇室血脈的王國。無論您的離世是否在計劃之內，都不影響大局，您的血統會由新的可遊玩角色所繼承。<br>探索一個龐大的模擬世界，有著農民和騎士、朝臣、間諜、流氓與小丑，也別忘了還有秘密戀情。可以浪漫化、背叛、處決或巧妙地影響大量的歷史人物。<br>探索一幅廣闊的中世紀地圖，從白雪覆蓋的北歐大陸延伸至非洲之角，從西部的不列顛群島延伸到東部富有異國情調的緬甸。佔領、征服並統治數以千計獨特的郡地、公國、王國和帝國。",TotalBuyCount=111,ReleaseTime=new DateTime(2020, 9, 2, 0, 0, 0),DownTime=null,Developer="Paradox Interactive",Marker="Paradox Development Studio"},

            new Game{GameId=2,GameName="太閤立志傳Ⅴ DX",GamePrice=1190,GameIntroduction="往昔的名作《太閤立志傳Ⅴ》在追加全新要素後，高清重製版終獲蘇生！舞臺為16世紀的日本。扮演以秀吉為首馳騁戰國亂世的史實人物，實現他們各自的夢想吧。既可以侍奉自己中意的大名，也可以自己作為大名統一天下。亦或以日本第一的忍者、水軍、商人為遊戲目標。除此之外，還有醫生、鍛冶匠、茶人等...",GameDetailsText="名作「太閤立志傳Ⅴ　完全攻略集」成為電子書，復刻登場！為可使用智慧型手機或PC方便閱覽的PDF版。※PS2版『太閤立志傳Ⅴ』的攻略本。未記載與「太閤立志傳Ⅴ DX」的追加要素等相關資訊。下載頁面請參照有記載序號的宣傳單。<br>※PDF形式檔案, 閱覽時請使用Adobe Acrobat Reader等，各種支援PDF的閱讀器。※Adobe，Adobe PDF和Adobe Reader是Adobe Systems Inc.在美國和其他國家或地區的商標或註冊商標。",TotalBuyCount=65,ReleaseTime=new DateTime(2022, 5, 19, 0, 0, 0),DownTime=null,Developer="KOEI TECMO GAMES CO., LTD.",Marker="KOEI TECMO GAMES CO., LTD."},

            new Game{GameId=3,GameName="超級機器人大戰30",GamePrice=1690,GameIntroduction="累積30年的歲月——戰鬥吧！為了這顆星球的未來 超級機器人大戰系列，是讓各種動畫作品中登場的機器人， 超越不同作品的藩籬齊聚一堂，迎戰共同敵人的模擬RPG遊戲。",GameDetailsText="玩家可在冒險環節觀看戰鬥前發生的劇情，在進入戰略模擬環節後，個別操作地圖上配置的機器人來破壞敵人。<br>戰鬥分為我方回合和敵方回合來輪流進行。<br>首先會由玩家來移動機器人進行戰鬥，再輪到敵方行動。<br>只要破壞地圖中配置的所有敵人就能通過關卡，來進入戰略環節。<br>在戰略環節可運用戰鬥獲得的資金和點數，來強化機器人與培育駕駛員。<br>而在結束戰略環節後，將會開始下一關的冒險環節。<br>體驗各種動畫原作的跨界融合故事以及機器人的戰鬥動畫影片，<br>並不斷強化培育自己喜歡的機器人和駕駛，就是超級機器人大戰的樂趣。",TotalBuyCount=48,ReleaseTime=new DateTime(2021, 10, 28, 0, 0, 0),DownTime=null,Developer="BANDAI NAMCO Entertainment",Marker="B.B.STUDIO CO.,LTD."},

            new Game{GameId=4,GameName="Total War: THREE KINGDOMS",GamePrice=2297,GameIntroduction="《Total War™: THREE KINGDOMS》是屢獲殊榮的《Total War》系列中第一款經典重現中國古代壯烈戰爭的作品。建設帝國與攻城掠地的回合制戰役，加上驚心動魄的即時戰鬥，《THREE KINGDOMS》以充滿英雄與傳奇的時代為舞台，顛覆了玩家對本系列的想像。",GameDetailsText="《Total War: THREE KINGDOMS》是屢獲殊榮的《Total War》策略遊戲系列中第一款經典重現中國古代壯烈戰爭的作品。建設帝國、治理國家與攻城掠地的回合制戰略遊戲，加上驚心動魄的即時戰鬥，《Total War: THREE KINGDOMS》以充滿英雄與傳奇的時代為舞台，顛覆了玩家對本系列的想像。<br>東漢末年（西元 190 年）歡迎來到這個群雄逐鹿的傳奇時代。<br>這個美麗卻分崩離析的國度呼求著新的皇帝，期望一改前朝，為人民開創嶄新的生活。您必須團結萬民一統中原，打造偉大王朝，並奠立萬古流傳的歷史地位。<br>從 12 位傳奇諸侯中挑選一位，征服天下。募集英雄豪傑輔佐您成就不世霸業，並在軍事、技術、政治和經濟等各領域戰勝敵人。<br>您是否能與締結牢固邦誼、組成緊密聯盟，並贏得多方仇敵的敬重？抑或您寧可背信棄義、狠心變節，願作滿腹政治謀略的一世梟雄？<br>屬於您的傳奇仍待下筆撰寫，然無庸置疑的是：光榮的征戰之路就在眼前。",TotalBuyCount=40,ReleaseTime=new DateTime(2019, 5, 23, 0, 0, 0),DownTime=null,Developer="SEGA, Feral Interactive (Mac), Feral Interactive (Linux)",Marker="CREATIVE ASSEMBLY, Feral Interactive (Mac), Feral Interactive (Linux)"},

            new Game{GameId=5,GameName="臨淵覺醒1",GamePrice=310,GameIntroduction="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。 玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。",GameDetailsText="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。<br>在遊戲中，玩家的每次關卡體驗都是隨機的。每一次重新開始遊戲都是新的體驗。你可以使用不同的武器，在不同的關卡中選擇不同的天賦，體驗不同戰鬥節奏。<br>遊戲包含場外養成元素，玩家的每一次遊戲挑戰都可以提升場外天賦，永久加強自己的能力，使下次可以更輕鬆地擊敗深淵敵人。<br>遊戲目前還處於搶先體驗階段，我們會在接下來較長的一段時間裡逐漸完善遊戲修復bug、新增更多的內容和玩法。感謝你們的支持！我們會努力把遊戲做的更好。<br>如果你有任何問題、反饋，可以加入QQ群：1055013710，將問題的描述、截圖、錄屏等提供給我們，我們會盡快查證並進行修復。<br>遊戲特色：<br>· 中世紀+第三人稱+Roguelite+RPG組合玩法，在不斷的死亡輪迴中組建多種Build獲得不同的通關體驗。",TotalBuyCount=20,ReleaseTime=new DateTime(2022, 6, 19, 0, 0, 0),DownTime=null,Developer="TrinityBJ",Marker="TrinityBJ"},
            new Game{GameId=6,GameName="臨淵覺醒2",GamePrice=290,GameIntroduction="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。 玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。",GameDetailsText="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。<br>在遊戲中，玩家的每次關卡體驗都是隨機的。每一次重新開始遊戲都是新的體驗。你可以使用不同的武器，在不同的關卡中選擇不同的天賦，體驗不同戰鬥節奏。<br>遊戲包含場外養成元素，玩家的每一次遊戲挑戰都可以提升場外天賦，永久加強自己的能力，使下次可以更輕鬆地擊敗深淵敵人。<br>遊戲目前還處於搶先體驗階段，我們會在接下來較長的一段時間裡逐漸完善遊戲修復bug、新增更多的內容和玩法。感謝你們的支持！我們會努力把遊戲做的更好。<br>如果你有任何問題、反饋，可以加入QQ群：1055013710，將問題的描述、截圖、錄屏等提供給我們，我們會盡快查證並進行修復。<br>遊戲特色：<br>· 中世紀+第三人稱+Roguelite+RPG組合玩法，在不斷的死亡輪迴中組建多種Build獲得不同的通關體驗。",TotalBuyCount=10,ReleaseTime=new DateTime(2022, 6, 19, 0, 0, 0),DownTime=null,Developer="TrinityBJ",Marker="TrinityBJ"},
            new Game{GameId=7,GameName="臨淵覺醒3",GamePrice=280,GameIntroduction="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。 玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。",GameDetailsText="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。<br>在遊戲中，玩家的每次關卡體驗都是隨機的。每一次重新開始遊戲都是新的體驗。你可以使用不同的武器，在不同的關卡中選擇不同的天賦，體驗不同戰鬥節奏。<br>遊戲包含場外養成元素，玩家的每一次遊戲挑戰都可以提升場外天賦，永久加強自己的能力，使下次可以更輕鬆地擊敗深淵敵人。<br>遊戲目前還處於搶先體驗階段，我們會在接下來較長的一段時間裡逐漸完善遊戲修復bug、新增更多的內容和玩法。感謝你們的支持！我們會努力把遊戲做的更好。<br>如果你有任何問題、反饋，可以加入QQ群：1055013710，將問題的描述、截圖、錄屏等提供給我們，我們會盡快查證並進行修復。<br>遊戲特色：<br>· 中世紀+第三人稱+Roguelite+RPG組合玩法，在不斷的死亡輪迴中組建多種Build獲得不同的通關體驗。",TotalBuyCount=45,ReleaseTime=new DateTime(2022, 6, 19, 0, 0, 0),DownTime=null,Developer="TrinityBJ",Marker="TrinityBJ"},
            new Game{GameId=8,GameName="臨淵覺醒4",GamePrice=270,GameIntroduction="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。 玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。",GameDetailsText="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。<br>在遊戲中，玩家的每次關卡體驗都是隨機的。每一次重新開始遊戲都是新的體驗。你可以使用不同的武器，在不同的關卡中選擇不同的天賦，體驗不同戰鬥節奏。<br>遊戲包含場外養成元素，玩家的每一次遊戲挑戰都可以提升場外天賦，永久加強自己的能力，使下次可以更輕鬆地擊敗深淵敵人。<br>遊戲目前還處於搶先體驗階段，我們會在接下來較長的一段時間裡逐漸完善遊戲修復bug、新增更多的內容和玩法。感謝你們的支持！我們會努力把遊戲做的更好。<br>如果你有任何問題、反饋，可以加入QQ群：1055013710，將問題的描述、截圖、錄屏等提供給我們，我們會盡快查證並進行修復。<br>遊戲特色：<br>· 中世紀+第三人稱+Roguelite+RPG組合玩法，在不斷的死亡輪迴中組建多種Build獲得不同的通關體驗。",TotalBuyCount=31,ReleaseTime=new DateTime(2022, 6, 19, 0, 0, 0),DownTime=null,Developer="TrinityBJ",Marker="TrinityBJ"},
            new Game{GameId=9,GameName="臨淵覺醒5",GamePrice=260,GameIntroduction="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。 玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。",GameDetailsText="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。<br>在遊戲中，玩家的每次關卡體驗都是隨機的。每一次重新開始遊戲都是新的體驗。你可以使用不同的武器，在不同的關卡中選擇不同的天賦，體驗不同戰鬥節奏。<br>遊戲包含場外養成元素，玩家的每一次遊戲挑戰都可以提升場外天賦，永久加強自己的能力，使下次可以更輕鬆地擊敗深淵敵人。<br>遊戲目前還處於搶先體驗階段，我們會在接下來較長的一段時間裡逐漸完善遊戲修復bug、新增更多的內容和玩法。感謝你們的支持！我們會努力把遊戲做的更好。<br>如果你有任何問題、反饋，可以加入QQ群：1055013710，將問題的描述、截圖、錄屏等提供給我們，我們會盡快查證並進行修復。<br>遊戲特色：<br>· 中世紀+第三人稱+Roguelite+RPG組合玩法，在不斷的死亡輪迴中組建多種Build獲得不同的通關體驗。",TotalBuyCount=20,ReleaseTime=new DateTime(2022, 6, 19, 0, 0, 0),DownTime=null,Developer="TrinityBJ",Marker="TrinityBJ"},
            new Game{GameId=10,GameName="臨淵覺醒6",GamePrice=260,GameIntroduction="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。 玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。",GameDetailsText="《臨淵覺醒》是一款融合了第三人稱、動作、中世紀、Roguelite隨機元素和RPG策略選擇的冒險闖關遊戲。玩家在遊戲裡可以根據不同武器的特點搭配多種詞條組建各種Build玩法，在關卡中選擇適合當前武器玩法的隨機天賦進行冒險挑戰。可以單人暢玩，也可以最多三人組隊挑戰。<br>在遊戲中，玩家的每次關卡體驗都是隨機的。每一次重新開始遊戲都是新的體驗。你可以使用不同的武器，在不同的關卡中選擇不同的天賦，體驗不同戰鬥節奏。<br>遊戲包含場外養成元素，玩家的每一次遊戲挑戰都可以提升場外天賦，永久加強自己的能力，使下次可以更輕鬆地擊敗深淵敵人。<br>遊戲目前還處於搶先體驗階段，我們會在接下來較長的一段時間裡逐漸完善遊戲修復bug、新增更多的內容和玩法。感謝你們的支持！我們會努力把遊戲做的更好。<br>如果你有任何問題、反饋，可以加入QQ群：1055013710，將問題的描述、截圖、錄屏等提供給我們，我們會盡快查證並進行修復。<br>遊戲特色：<br>· 中世紀+第三人稱+Roguelite+RPG組合玩法，在不斷的死亡輪迴中組建多種Build獲得不同的通關體驗。",TotalBuyCount=20,ReleaseTime=new DateTime(2022, 6, 19, 0, 0, 0),DownTime=null,Developer="TrinityBJ",Marker="TrinityBJ"},

        };

        public List<GameType> GameTypes = new List<GameType>()
        {
            new GameType{GameTypeId=1 , GameId=1, TypelistId=1 },
            new GameType{GameTypeId=2 , GameId=1, TypelistId=2 },
            new GameType{GameTypeId=3,  GameId=2, TypelistId=2 },
            new GameType{GameTypeId=4 , GameId=3, TypelistId=3 },
            new GameType{GameTypeId=5 , GameId=4, TypelistId=4 },
            new GameType{GameTypeId=6 , GameId=5, TypelistId=5 },
            new GameType{GameTypeId=7 , GameId=3, TypelistId=7 },
            new GameType{GameTypeId=8 , GameId=4, TypelistId=7 },
            new GameType{GameTypeId=9 , GameId=1, TypelistId=7 },
            new GameType{GameTypeId=10 , GameId=5, TypelistId=7 },

        };

        public List<Typelist> Typelists = new List<Typelist>()
        {
            new Typelist{TypelistId=1 , Name ="中世紀"},
            new Typelist{TypelistId=2 , Name ="大戰略"},
            new Typelist{TypelistId=3 , Name ="歷史"},
            new Typelist{TypelistId=4 , Name ="角色扮演"},
            new Typelist{TypelistId=5 , Name ="回合制策略遊戲"},
            new Typelist{TypelistId=6 , Name ="角色扮演"},
            new Typelist{TypelistId=7 , Name ="VR"},

        };

        public List<GameDiscount> gameDiscounts = new List<GameDiscount>()
        {
            new GameDiscount{DiscountId= 1, DiscountTake= 0.4,   StarTime=null , EndTime=null,GameId=1 },
            new GameDiscount{DiscountId= 2, DiscountTake= 0.8, StarTime=null , EndTime=null,GameId=2},
            new GameDiscount{DiscountId= 3, DiscountTake= 0.5, StarTime=null , EndTime=null,GameId=3},
            new GameDiscount{DiscountId= 4, DiscountTake= 0.7, StarTime=null , EndTime=null,GameId=4},
            new GameDiscount{DiscountId= 5, DiscountTake= 0.6, StarTime=null , EndTime=null,GameId=5},
            new GameDiscount{DiscountId= 6, DiscountTake= 0.3, StarTime=null , EndTime=null,GameId=6},
            new GameDiscount{DiscountId= 7, DiscountTake= 0.5, StarTime=null , EndTime=null,GameId=7},
            new GameDiscount{DiscountId= 8, DiscountTake= 0.8, StarTime=null , EndTime=null,GameId=8},
            new GameDiscount{DiscountId= 9, DiscountTake= 0.75, StarTime=null , EndTime=null,GameId=9},



        };

        public List<SystemSpecification> systemSpecifications = new List<SystemSpecification>()
        {
            new SystemSpecification{GameId= 1,SystemSpecificationId=1,SystemType=1,SystemCpu="Intel® Core™ i3-2120 / AMD® FX 6350",SystemGpu=" Nvidia® GeForce™ GTX 660 (2GB) / AMD® Radeon™ HD 7870 (2GB) / Intel® Iris Pro™ 580 / Intel® Iris® Plus G7 / AMD® Radeon™ Vega 11", Hddspace="8 GB 可用空間" ,System=" Windows® 8.1 64 bit / Windows® 10",SystemRam=" 6 GB 記憶體" },
            new SystemSpecification{GameId= 1,SystemSpecificationId=2,SystemType=2,SystemCpu="Intel® Core™ i7-7820HQ",SystemGpu=" AMD® Radeon™ PRO 560 (4 GB)", Hddspace=" 8 GB 可用空間" ,System="Mojave (MAC OS X 10.14)",SystemRam=" 12 GB 記憶體" },
            new SystemSpecification{GameId= 2,SystemSpecificationId=3,SystemType=1,SystemCpu="Intel Core i3-4170 or over",SystemGpu="NVIDIA GeForce GT430(1GB) or over, AMD Radeon HD6450(1GB) or over, Intel HD Graphics 4400 or over", Hddspace=" 8 GB 可用空間" ,System=" Windows® 8.1/10/11 64bit",SystemRam=" 4 GB 記憶體" },
            new SystemSpecification{GameId= 3,SystemSpecificationId=4,SystemType=1,SystemCpu="Intel Core 2 Duo E6750 | AMD Athlon 64 X2 6400+",SystemGpu=" Nvidia GeForce GT 320, 1 GB | AMD Radeon HD 6670, 1 GB", Hddspace="15 GB 可用空間" ,System="Windows 10",SystemRam="4 GB 記憶體" },
            new SystemSpecification{GameId= 4,SystemSpecificationId=5,SystemType=1,SystemCpu="Intel Core 2 Duo 3.00Ghz",SystemGpu="GTX 650 Ti 1GB|HD 7850 1GB|Intel UHD Graphics 620", Hddspace=" 60 GB 可用空間" ,System=" Windows 7 64 Bit",SystemRam="4 GB 記憶體" },
            new SystemSpecification{GameId= 4,SystemSpecificationId=6,SystemType=2,SystemCpu="2GHz Intel Core i5",SystemGpu="2GB Nvidia 680MX, 2GB AMD R9 M290, 1.5GB Intel Iris Graphics 540 or better (see notes for more details)", Hddspace=" 52 GB 可用空間" ,System="macOS 10.14.4",SystemRam=" 8 GB 記憶體" },
            new SystemSpecification{GameId= 5,SystemSpecificationId=7,SystemType=1,SystemCpu=" Intel i5-4460 or AMD Ryzen 3 1200",SystemGpu=" NVidia GTX 970 OR AMD RX 470", Hddspace="17 GB 可用空間" ,System="Windows 10 64 bit",SystemRam=" 8 GB 記憶體" },

        };
        public List<GameMedium> gameMedia = new List<GameMedium>()
        {
            new GameMedium{GameId = 1, GameMediaId = 1, InstructionType= 1, Instruction = 1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1158310/ss_413b6da4260c65d3ee297bfcde96983bc215e778.1920x1080.jpg?t=1655466184"  },
            new GameMedium{GameId = 1, GameMediaId = 2, InstructionType= 1, Instruction = 1, Sort= 3, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1158310/ss_8b53c852845e15a7967579b614bc2cf78f6e03df.1920x1080.jpg?t=1655466184"  },
            new GameMedium{GameId = 1, GameMediaId = 3, InstructionType= 1, Instruction = 1, Sort= 4, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1158310/ss_bca1003e5a291385c92bfda31f936d80e216678b.1920x1080.jpg?t=1655466184"  },
            new GameMedium{GameId = 1, GameMediaId = 4, InstructionType= 1, Instruction = 1, Sort= 5, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1158310/ss_b156a63607d6fda250b94b727e60230e1764f105.600x338.jpg?t=1655466184"   },
            new GameMedium{GameId = 1, GameMediaId = 5, InstructionType= 1, Instruction = 1, Sort= 6, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1158310/ss_d9f8b8f8c9f833dd83c869863d89c5e55d8668cb.1920x1080.jpg?t=1655466184"  },
            new GameMedium{GameId = 1, GameMediaId = 6, InstructionType= 1, Instruction = 2, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/256799392/movie480_vp9.webm?t=1598976952"  },
            new GameMedium{GameId = 1, GameMediaId = 7, InstructionType= 2, Instruction = 1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1158310/header.jpg?t=1655466184"  },
            new GameMedium{GameId = 1, GameMediaId = 8, InstructionType= 3, Instruction = 1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1158310/extras/2s.gif?t=1655466184"  },
            new GameMedium{GameId = 1, GameMediaId = 9, InstructionType= 3, Instruction = 1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1158310/extras/4s.gif?t=1655466184"  },

            new GameMedium{GameId =2, GameMediaId = 10, InstructionType=1 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1842810/ss_e64ad5972454c41ba023799d6961dd30f318ad52.600x338.jpg?t=1655427723"  },
            new GameMedium{GameId =2, GameMediaId = 11, InstructionType=1 , Instruction =1, Sort= 3, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1842810/ss_c4b657f4435ee60130701aed410183bf1af1637f.600x338.jpg?t=1655427723"  },
            new GameMedium{GameId =2, GameMediaId = 12, InstructionType=1 , Instruction =1, Sort= 4, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1842810/ss_23333a27da555ae639a85de2874103a358df4ff1.600x338.jpg?t=1655427723"  },
            new GameMedium{GameId =2, GameMediaId = 13, InstructionType=1 , Instruction =1, Sort= 5, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1842810/ss_7356adfaaf9fbe719d4a5cae8edec31d554fc61f.600x338.jpg?t=1655427723"  },
            new GameMedium{GameId =2, GameMediaId = 14, InstructionType=1 , Instruction =1, Sort= 6, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1842810/ss_c2c6d44036886f2318f58a34db6f914908cd1792.600x338.jpg?t=1655427723"  },
            new GameMedium{GameId =2, GameMediaId = 15, InstructionType=1 , Instruction =2, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/256881129/movie480_vp9.webm?t=1649311326"  },
            new GameMedium{GameId =2, GameMediaId = 16, InstructionType=2 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1842810/header_tchinese.jpg?t=1655427723"  },
            new GameMedium{GameId =2, GameMediaId = 17, InstructionType=3 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1842810/ss_dbb4c9eb47d17dc41d70a8bd23c33fddcf22c572.600x338.jpg?t=1655427723"  },
            new GameMedium{GameId =2, GameMediaId = 18, InstructionType=3 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1842810/ss_d5dc8b1cae76fbe2fcad0640b3db4f42b7a802e8.600x338.jpg?t=1655427723"  },

            new GameMedium{GameId =3, GameMediaId = 19, InstructionType=1 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/898750/ss_fd44fd33888da53e613e798510108f73635edb40.600x338.jpg?t=1649915668"  },
            new GameMedium{GameId =3, GameMediaId = 20, InstructionType=1 , Instruction =1, Sort= 3, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/898750/ss_36824390cdd6a1a97a4d013f8b4567888bebae48.600x338.jpg?t=1649915668"  },
            new GameMedium{GameId =3, GameMediaId = 21, InstructionType=1 , Instruction =1, Sort= 4, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/898750/ss_5ece46ca87010b448c8f41747d528fd2c7eafb53.600x338.jpg?t=1649915668"  },
            new GameMedium{GameId =3, GameMediaId = 22, InstructionType=1 , Instruction =1, Sort= 5, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/898750/ss_8437c46c90841b85995da77afd89eaf261b697ba.600x338.jpg?t=1649915668"  },
            new GameMedium{GameId =3, GameMediaId = 23, InstructionType=1 , Instruction =1, Sort= 6, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/898750/ss_fd44fd33888da53e613e798510108f73635edb40.600x338.jpg?t=1649915668"  },
            new GameMedium{GameId =3, GameMediaId = 24, InstructionType=1 , Instruction =2, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/256842880/movie480_vp9.webm?t=1626260266"  },
            new GameMedium{GameId =3, GameMediaId = 25, InstructionType=2 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/898750/header_tchinese.jpg?t=1649915668"  },
            new GameMedium{GameId =3, GameMediaId = 26, InstructionType=3 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/898750/extras/SRW01.gif?t=1649915668"  },
            new GameMedium{GameId =3, GameMediaId = 27, InstructionType=3 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/898750/extras/SRW02.gif?t=1649915668"  },

            new GameMedium{GameId =4, GameMediaId = 28, InstructionType=1 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/779340/ss_b367c99f566ecfc3def17673e9015c80e7e3a8d3.600x338.jpg?t=1653315123"  },
            new GameMedium{GameId =4, GameMediaId = 29, InstructionType=1 , Instruction =1, Sort= 3, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/779340/ss_fe3108d8affd7a9f7e72959602e49cb5fa105910.600x338.jpg?t=1653315123"  },
            new GameMedium{GameId =4, GameMediaId = 30, InstructionType=1 , Instruction =1, Sort= 4, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/779340/ss_16346541350f29271399420bffda0da34c8d5ea1.600x338.jpg?t=1653315123"  },
            new GameMedium{GameId =4, GameMediaId = 31, InstructionType=1 , Instruction =1, Sort= 5, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/779340/ss_82b431d0e99eff54583fb4abe17bf805d1fa1a03.600x338.jpg?t=1653315123"  },
            new GameMedium{GameId =4, GameMediaId = 32, InstructionType=1 , Instruction =1, Sort= 6, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/779340/ss_ced0e321ac9262d29dc0a4e4fe4b91d3144ed2e6.600x338.jpg?t=1653315123"  },
            new GameMedium{GameId =4, GameMediaId = 33, InstructionType=1 , Instruction =2, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/256751447/movie480.webm?t=1558620943"  },
            new GameMedium{GameId =4, GameMediaId = 34, InstructionType=2 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/779340/header.jpg?t=1653315123"  },
            new GameMedium{GameId =4, GameMediaId = 35, InstructionType=3 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/779340/extras/01.jpg?t=1653315123"  },
            new GameMedium{GameId =4, GameMediaId = 36, InstructionType=3 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/779340/extras/01.jpg?t=1653315123"  },

            new GameMedium{GameId =5, GameMediaId = 37, InstructionType=1 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_550c7caf0e3f37e2341a7085b68e8b563a4d6a01.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =5, GameMediaId = 38, InstructionType=1 , Instruction =1, Sort= 3, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_6f465e54228063c6163339dfa1f08d2ccdd159b7.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =5, GameMediaId = 39, InstructionType=1 , Instruction =1, Sort= 4, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_9cb2195d65bf0b5ed1a4c957d7d1ac3d383bcc52.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =5, GameMediaId = 40, InstructionType=1 , Instruction =1, Sort= 5, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_bf86dec5d1b03514f1dcb17b5860849b9784f5bd.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =5, GameMediaId = 41, InstructionType=1 , Instruction =1, Sort= 6, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_c9403d0b710dc7d93e200037709483121e88ca0b.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =5, GameMediaId = 42, InstructionType=1 , Instruction =2, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/256869414/movie480_vp9.webm?t=1642338226"  },
            new GameMedium{GameId =5, GameMediaId = 43, InstructionType=2 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/header_tchinese.jpg?t=1655638795"  },
            new GameMedium{GameId =5, GameMediaId = 44, InstructionType=3 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/extras/fighting.gif?t=1655638795"  },
            new GameMedium{GameId =5, GameMediaId = 45, InstructionType=3 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/extras/level.gif?t=1655638795"  },

            new GameMedium{GameId =6, GameMediaId = 46, InstructionType=1 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_550c7caf0e3f37e2341a7085b68e8b563a4d6a01.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =6, GameMediaId = 47, InstructionType=1 , Instruction =1, Sort= 3, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_6f465e54228063c6163339dfa1f08d2ccdd159b7.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =6, GameMediaId = 48, InstructionType=1 , Instruction =1, Sort= 4, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_9cb2195d65bf0b5ed1a4c957d7d1ac3d383bcc52.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =6, GameMediaId = 49, InstructionType=1 , Instruction =1, Sort= 5, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_bf86dec5d1b03514f1dcb17b5860849b9784f5bd.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =6, GameMediaId = 50, InstructionType=1 , Instruction =1, Sort= 6, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_c9403d0b710dc7d93e200037709483121e88ca0b.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =6, GameMediaId = 51, InstructionType=1 , Instruction =2, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/256869414/movie480_vp9.webm?t=1642338226"  },
            new GameMedium{GameId =6, GameMediaId = 52, InstructionType=2 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/header_tchinese.jpg?t=1655638795"  },
            new GameMedium{GameId =6, GameMediaId = 53, InstructionType=3 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/extras/fighting.gif?t=1655638795"  },
            new GameMedium{GameId =6, GameMediaId = 54, InstructionType=3 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/extras/level.gif?t=1655638795"  },

            new GameMedium{GameId =7, GameMediaId = 55, InstructionType=1 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_550c7caf0e3f37e2341a7085b68e8b563a4d6a01.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =7, GameMediaId = 56, InstructionType=1 , Instruction =1, Sort= 3, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_6f465e54228063c6163339dfa1f08d2ccdd159b7.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =7, GameMediaId = 57, InstructionType=1 , Instruction =1, Sort= 4, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_9cb2195d65bf0b5ed1a4c957d7d1ac3d383bcc52.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =7, GameMediaId = 58, InstructionType=1 , Instruction =1, Sort= 5, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_bf86dec5d1b03514f1dcb17b5860849b9784f5bd.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =7, GameMediaId = 59, InstructionType=1 , Instruction =1, Sort= 6, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_c9403d0b710dc7d93e200037709483121e88ca0b.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =7, GameMediaId = 60, InstructionType=1 , Instruction =2, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/256869414/movie480_vp9.webm?t=1642338226"  },
            new GameMedium{GameId =7, GameMediaId = 61, InstructionType=2 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/header_tchinese.jpg?t=1655638795"  },
            new GameMedium{GameId =7, GameMediaId = 62, InstructionType=3 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/extras/fighting.gif?t=1655638795"  },
            new GameMedium{GameId =7, GameMediaId = 63, InstructionType=3 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/extras/level.gif?t=1655638795"  },

            new GameMedium{GameId =8, GameMediaId = 64, InstructionType=1 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_550c7caf0e3f37e2341a7085b68e8b563a4d6a01.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =8, GameMediaId = 65, InstructionType=1 , Instruction =1, Sort= 3, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_6f465e54228063c6163339dfa1f08d2ccdd159b7.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =8, GameMediaId = 66, InstructionType=1 , Instruction =1, Sort= 4, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_9cb2195d65bf0b5ed1a4c957d7d1ac3d383bcc52.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =8, GameMediaId = 67, InstructionType=1 , Instruction =1, Sort= 5, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_bf86dec5d1b03514f1dcb17b5860849b9784f5bd.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =8, GameMediaId = 68, InstructionType=1 , Instruction =1, Sort= 6, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_c9403d0b710dc7d93e200037709483121e88ca0b.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =8, GameMediaId = 69, InstructionType=1 , Instruction =2, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/256869414/movie480_vp9.webm?t=1642338226"  },
            new GameMedium{GameId =8, GameMediaId = 70, InstructionType=2 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/header_tchinese.jpg?t=1655638795"  },
            new GameMedium{GameId =8, GameMediaId = 71, InstructionType=3 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/extras/fighting.gif?t=1655638795"  },
            new GameMedium{GameId =8, GameMediaId = 72, InstructionType=3 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/extras/level.gif?t=1655638795"  },

            new GameMedium{GameId =9, GameMediaId = 73, InstructionType=1 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_550c7caf0e3f37e2341a7085b68e8b563a4d6a01.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =9, GameMediaId = 74, InstructionType=1 , Instruction =1, Sort= 3, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_6f465e54228063c6163339dfa1f08d2ccdd159b7.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =9, GameMediaId = 75, InstructionType=1 , Instruction =1, Sort= 4, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_9cb2195d65bf0b5ed1a4c957d7d1ac3d383bcc52.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =9, GameMediaId = 76, InstructionType=1 , Instruction =1, Sort= 5, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_bf86dec5d1b03514f1dcb17b5860849b9784f5bd.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =9, GameMediaId = 77, InstructionType=1 , Instruction =1, Sort= 6, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_c9403d0b710dc7d93e200037709483121e88ca0b.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =9, GameMediaId = 78, InstructionType=1 , Instruction =2, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/256869414/movie480_vp9.webm?t=1642338226"  },
            new GameMedium{GameId =9, GameMediaId = 79, InstructionType=2 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/header_tchinese.jpg?t=1655638795"  },
            new GameMedium{GameId =9, GameMediaId = 80, InstructionType=3 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/extras/fighting.gif?t=1655638795"  },
            new GameMedium{GameId =9, GameMediaId = 81, InstructionType=3 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/extras/level.gif?t=1655638795"  },

            new GameMedium{GameId =10, GameMediaId = 82, InstructionType=1 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_550c7caf0e3f37e2341a7085b68e8b563a4d6a01.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =10, GameMediaId = 83, InstructionType=1 , Instruction =1, Sort= 3, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_6f465e54228063c6163339dfa1f08d2ccdd159b7.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =10, GameMediaId = 84, InstructionType=1 , Instruction =1, Sort= 4, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_9cb2195d65bf0b5ed1a4c957d7d1ac3d383bcc52.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =10, GameMediaId = 85, InstructionType=1 , Instruction =1, Sort= 5, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_bf86dec5d1b03514f1dcb17b5860849b9784f5bd.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =10, GameMediaId = 86, InstructionType=1 , Instruction =1, Sort= 6, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/ss_c9403d0b710dc7d93e200037709483121e88ca0b.600x338.jpg?t=1655638795"  },
            new GameMedium{GameId =10, GameMediaId = 87, InstructionType=1 , Instruction =2, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/256869414/movie480_vp9.webm?t=1642338226"  },
            new GameMedium{GameId =10, GameMediaId = 88, InstructionType=2 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/header_tchinese.jpg?t=1655638795"  },
            new GameMedium{GameId =10, GameMediaId = 89, InstructionType=3 , Instruction =1, Sort= 1, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/extras/fighting.gif?t=1655638795"  },
            new GameMedium{GameId =10, GameMediaId = 90, InstructionType=3 , Instruction =1, Sort= 2, MediaUrl="https://cdn.akamai.steamstatic.com/steam/apps/1641670/extras/level.gif?t=1655638795"  },
        };

        //void X()
        //{
        //    this.gameDiscounts
        //}
    }
}
    