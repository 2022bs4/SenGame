using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SenGame.Migrations
{
    public partial class no1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleTag",
                columns: table => new
                {
                    ArticleTagID = table.Column<int>(type: "int", nullable: false),
                    TagName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTag", x => x.ArticleTagID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FriendList",
                columns: table => new
                {
                    FriendLIstId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FriendId = table.Column<int>(type: "int", nullable: false),
                    FriendGroupId = table.Column<int>(type: "int", nullable: true),
                    FriendNickName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    IsBlockade = table.Column<bool>(type: "bit", nullable: true, comment: "是否被封鎖")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendList", x => x.FriendLIstId);
                });

            migrationBuilder.CreateTable(
                name: "GameDiscount",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    DiscountTake = table.Column<double>(type: "float", nullable: false),
                    StarTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDiscount", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "MyFavouriteId",
                columns: table => new
                {
                    MyFavouriteId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyFavouriteId", x => x.MyFavouriteId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "訂單時間"),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "訂單更新時間"),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false, comment: "1.購物車 2.待付款  3.付款完成  4.申請退款 5.退款完成"),
                    EcpayId = table.Column<int>(type: "int", nullable: false, comment: "Ecpay訂單編號"),
                    Invoice = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false, comment: "發票編碼"),
                    InvoiceWay = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false, comment: "1.電子發票2.載具3.捐贈")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Typelist",
                columns: table => new
                {
                    TypelistId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typelist", x => x.TypelistId);
                });

            migrationBuilder.CreateTable(
                name: "UserBackground",
                columns: table => new
                {
                    UserBackgroundId = table.Column<int>(type: "int", nullable: false),
                    BackgroundColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBackground", x => x.UserBackgroundId);
                });

            migrationBuilder.CreateTable(
                name: "UserCountry",
                columns: table => new
                {
                    UserCountryId = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCountry", x => x.UserCountryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GamePrice = table.Column<decimal>(type: "money", nullable: false),
                    GameIntroduction = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "遊戲簡介"),
                    GameDetailsText = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "遊戲詳細介紹"),
                    TotalBuyCount = table.Column<int>(type: "int", nullable: true, comment: "此遊戲被購買次數"),
                    ReleaseTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "發布日期"),
                    DownTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "商品下架日期"),
                    Developer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "開發商家"),
                    Marker = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "開發者")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Game_GameDiscount",
                        column: x => x.DiscountId,
                        principalTable: "GameDiscount",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orderdetails",
                columns: table => new
                {
                    OrderdetailId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: true, comment: "訂單當時折購")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderdetails", x => x.OrderdetailId);
                    table.ForeignKey(
                        name: "FK_Orderdetails_Order",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmailConfirm = table.Column<bool>(type: "bit", nullable: false),
                    EmailConfirmDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserPicture = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "使用者大頭照"),
                    UsernickName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "使用者暱稱"),
                    UserCountryId = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "註冊日期"),
                    UserAbout = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "自介"),
                    UserBackgroundId = table.Column<int>(type: "int", nullable: false, comment: "使用者背景顏色"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    PrivacyPersonalFile = table.Column<int>(type: "int", nullable: false, comment: "個人檔案隱私狀態"),
                    PrivacyGameFile = table.Column<int>(type: "int", nullable: false, comment: "遊戲資料隱私狀態"),
                    PrivacyFriendsList = table.Column<int>(type: "int", nullable: false, comment: "好友名單隱私狀態")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Order",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_UserBackground",
                        column: x => x.UserBackgroundId,
                        principalTable: "UserBackground",
                        principalColumn: "UserBackgroundId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_UserCountry",
                        column: x => x.UserCountryId,
                        principalTable: "UserCountry",
                        principalColumn: "UserCountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    ForumID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Banner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.ForumID);
                    table.ForeignKey(
                        name: "FK_Forum_Game",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameMedia",
                columns: table => new
                {
                    GameMediaId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    MediaUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    InstructionType = table.Column<int>(type: "int", nullable: false, comment: "1幻燈片.2.簡介3.內文"),
                    Instruction = table.Column<int>(type: "int", nullable: false, comment: "1.圖片2.影片"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMedia", x => x.GameMediaId);
                    table.ForeignKey(
                        name: "FK_GameMedia_Game",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameType",
                columns: table => new
                {
                    GameTypeId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    TypelistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameType", x => x.GameTypeId);
                    table.ForeignKey(
                        name: "FK_GameType_Game",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameType_Typelist",
                        column: x => x.TypelistId,
                        principalTable: "Typelist",
                        principalColumn: "TypelistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameVideo",
                columns: table => new
                {
                    GameVideoID = table.Column<int>(type: "int", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "影片用途")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameVideo", x => x.GameVideoID);
                    table.ForeignKey(
                        name: "FK_GameVideo_Game",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemSpecification",
                columns: table => new
                {
                    SystemSpecificationId = table.Column<int>(type: "int", nullable: false),
                    SystemType = table.Column<int>(type: "int", nullable: false, comment: "1:windows 2:Mac"),
                    HDDspace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "硬碟使用空間"),
                    System = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "系統類別"),
                    SystemRam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "記憶體"),
                    SystemCpu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "處理器"),
                    SystemGpu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "顯示卡"),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSpecification", x => x.SystemSpecificationId);
                    table.ForeignKey(
                        name: "FK_SystemSpecification_Game",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    ChatID = table.Column<int>(type: "int", nullable: false),
                    ChatContent = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "聊天紀錄"),
                    ChatTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "現在聊天時間"),
                    UserID = table.Column<int>(type: "int", nullable: false, comment: "使用者自身"),
                    PictureFile = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "暫定")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.ChatID);
                    table.ForeignKey(
                        name: "FK_Chat_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendGroup",
                columns: table => new
                {
                    FriendGoupId = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendGroup", x => x.FriendGoupId);
                    table.ForeignKey(
                        name: "FK_FriendGroup_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invite",
                columns: table => new
                {
                    InviteId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "被邀請者"),
                    SenderId = table.Column<int>(type: "int", nullable: false, comment: "邀請者"),
                    Message = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invite", x => x.InviteId);
                    table.ForeignKey(
                        name: "FK_Invite_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invite_User1",
                        column: x => x.SenderId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MyGame",
                columns: table => new
                {
                    MyGameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    MyFavouriteId = table.Column<int>(type: "int", nullable: true, comment: "我的最愛")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyGame", x => x.MyGameId);
                    table.ForeignKey(
                        name: "FK_MyGame_Game",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MyGame_MyFavouriteId",
                        column: x => x.MyFavouriteId,
                        principalTable: "MyFavouriteId",
                        principalColumn: "MyFavouriteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MyGame_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPrivacy",
                columns: table => new
                {
                    UserPrivacyId = table.Column<int>(type: "int", nullable: false),
                    PrivacyState = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "隱私狀況"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrivacy", x => x.UserPrivacyId);
                    table.ForeignKey(
                        name: "FK_UserPrivacy_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wish",
                columns: table => new
                {
                    WishId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    AddTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wish", x => x.WishId);
                    table.ForeignKey(
                        name: "FK_Wish_Game",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wish_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ArticleID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ArticleContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "發文日期"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ForumID = table.Column<int>(type: "int", nullable: false),
                    LastReplyTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "最後回文時間"),
                    ArticleTagID = table.Column<int>(type: "int", nullable: false, comment: "種類:討論、心得")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ArticleID);
                    table.ForeignKey(
                        name: "FK_Article_ArticleTag",
                        column: x => x.ArticleTagID,
                        principalTable: "ArticleTag",
                        principalColumn: "ArticleTagID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Article_Forum",
                        column: x => x.ForumID,
                        principalTable: "Forum",
                        principalColumn: "ForumID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MyForum",
                columns: table => new
                {
                    MyForumID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ForumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyForum", x => x.MyForumID);
                    table.ForeignKey(
                        name: "FK_MyForum_Forum",
                        column: x => x.ForumID,
                        principalTable: "Forum",
                        principalColumn: "ForumID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MyForum_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerService",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    MyGameID = table.Column<int>(type: "int", nullable: false),
                    QuestionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerService", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_CustomerService_MyGame",
                        column: x => x.MyGameID,
                        principalTable: "MyGame",
                        principalColumn: "MyGameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleLike",
                columns: table => new
                {
                    LikeID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ArticleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.LikeID);
                    table.ForeignKey(
                        name: "FK_Like_Article",
                        column: x => x.ArticleID,
                        principalTable: "Article",
                        principalColumn: "ArticleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Like_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    ReplyID = table.Column<int>(type: "int", nullable: false),
                    ArticleID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ReplyTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReplyText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true, comment: "回復文章的回覆的回覆")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.ReplyID);
                    table.ForeignKey(
                        name: "FK_Reply_Article",
                        column: x => x.ArticleID,
                        principalTable: "Article",
                        principalColumn: "ArticleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reply_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceReply",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ReplyContent = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "客服回應")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ServiceReply_CustomerService",
                        column: x => x.ServiceId,
                        principalTable: "CustomerService",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReplyLike",
                columns: table => new
                {
                    ReplyLikeID = table.Column<int>(type: "int", nullable: false),
                    ReplyID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyLike", x => x.ReplyLikeID);
                    table.ForeignKey(
                        name: "FK_ReplyLike_Reply",
                        column: x => x.ReplyID,
                        principalTable: "Reply",
                        principalColumn: "ReplyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReplyLike_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_ArticleTagID",
                table: "Article",
                column: "ArticleTagID");

            migrationBuilder.CreateIndex(
                name: "IX_Article_ForumID",
                table: "Article",
                column: "ForumID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleLike_ArticleID",
                table: "ArticleLike",
                column: "ArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleLike_UserID",
                table: "ArticleLike",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UserID",
                table: "Chat",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerService_MyGameID",
                table: "CustomerService",
                column: "MyGameID");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_GameID",
                table: "Forum",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_FriendGroup_UserId",
                table: "FriendGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_DiscountId",
                table: "Game",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMedia_GameId",
                table: "GameMedia",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameType_GameId",
                table: "GameType",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameType_TypelistId",
                table: "GameType",
                column: "TypelistId");

            migrationBuilder.CreateIndex(
                name: "IX_GameVideo_GameID",
                table: "GameVideo",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_SenderId",
                table: "Invite",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_UserId",
                table: "Invite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MyForum_ForumID",
                table: "MyForum",
                column: "ForumID");

            migrationBuilder.CreateIndex(
                name: "IX_MyForum_UserID",
                table: "MyForum",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MyGame_GameId",
                table: "MyGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_MyGame_MyFavouriteId",
                table: "MyGame",
                column: "MyFavouriteId");

            migrationBuilder.CreateIndex(
                name: "IX_MyGame_UserId",
                table: "MyGame",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderdetails_OrderId",
                table: "Orderdetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_ArticleID",
                table: "Reply",
                column: "ArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_UserID",
                table: "Reply",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyLike_ReplyID",
                table: "ReplyLike",
                column: "ReplyID");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyLike_UserID",
                table: "ReplyLike",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReply_ServiceId",
                table: "ServiceReply",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSpecification_GameId",
                table: "SystemSpecification",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_User_OrderId",
                table: "User",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserBackgroundId",
                table: "User",
                column: "UserBackgroundId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserCountryId",
                table: "User",
                column: "UserCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivacy_UserId",
                table: "UserPrivacy",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wish_GameId",
                table: "Wish",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Wish_UserId",
                table: "Wish",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleLike");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "FriendGroup");

            migrationBuilder.DropTable(
                name: "FriendList");

            migrationBuilder.DropTable(
                name: "GameMedia");

            migrationBuilder.DropTable(
                name: "GameType");

            migrationBuilder.DropTable(
                name: "GameVideo");

            migrationBuilder.DropTable(
                name: "Invite");

            migrationBuilder.DropTable(
                name: "MyForum");

            migrationBuilder.DropTable(
                name: "Orderdetails");

            migrationBuilder.DropTable(
                name: "ReplyLike");

            migrationBuilder.DropTable(
                name: "ServiceReply");

            migrationBuilder.DropTable(
                name: "SystemSpecification");

            migrationBuilder.DropTable(
                name: "UserPrivacy");

            migrationBuilder.DropTable(
                name: "Wish");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Typelist");

            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropTable(
                name: "CustomerService");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "MyGame");

            migrationBuilder.DropTable(
                name: "ArticleTag");

            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropTable(
                name: "MyFavouriteId");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "UserBackground");

            migrationBuilder.DropTable(
                name: "UserCountry");

            migrationBuilder.DropTable(
                name: "GameDiscount");
        }
    }
}
