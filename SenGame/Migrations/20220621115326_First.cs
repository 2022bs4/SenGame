using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SenGame.Migrations
{
    public partial class First : Migration
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
                name: "FriendGroup",
                columns: table => new
                {
                    FriendGoupID = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendGroup", x => x.FriendGoupID);
                });

            migrationBuilder.CreateTable(
                name: "GameDiscount",
                columns: table => new
                {
                    DiscountID = table.Column<int>(type: "int", nullable: false),
                    DiscountTake = table.Column<double>(type: "float", nullable: false),
                    StarDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDiscount", x => x.DiscountID);
                });

            migrationBuilder.CreateTable(
                name: "GamePicture",
                columns: table => new
                {
                    GamePictureID = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameID = table.Column<int>(type: "int", nullable: false, comment: "是甚麼影片"),
                    Instructions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "用途")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePicture", x => x.GamePictureID);
                });

            migrationBuilder.CreateTable(
                name: "GameVideo",
                columns: table => new
                {
                    GameVideoID = table.Column<int>(type: "int", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameVideo", x => x.GameVideoID);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    OrderStatusID = table.Column<int>(type: "int", nullable: false),
                    StatusName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, comment: "狀態")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.OrderStatusID);
                });

            migrationBuilder.CreateTable(
                name: "SystemType",
                columns: table => new
                {
                    SystmTypeID = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemType", x => x.SystmTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Typelist",
                columns: table => new
                {
                    TypelistID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typelist", x => x.TypelistID);
                });

            migrationBuilder.CreateTable(
                name: "UserBackground",
                columns: table => new
                {
                    UserBackgroundID = table.Column<int>(type: "int", nullable: false),
                    BackgroundColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBackground", x => x.UserBackgroundID);
                });

            migrationBuilder.CreateTable(
                name: "UserCountry",
                columns: table => new
                {
                    UserCountryID = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCountry", x => x.UserCountryID);
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
                name: "GameType",
                columns: table => new
                {
                    GameTypeID = table.Column<int>(type: "int", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    TypelistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameType", x => x.GameTypeID);
                    table.ForeignKey(
                        name: "FK_GameType_Typelist",
                        column: x => x.TypelistID,
                        principalTable: "Typelist",
                        principalColumn: "TypelistID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmailConfirm = table.Column<bool>(type: "bit", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserPicture = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UsernickName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserCountryID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UserAbout = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "自介"),
                    UserBackgroundID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_UserBackground",
                        column: x => x.UserBackgroundID,
                        principalTable: "UserBackground",
                        principalColumn: "UserBackgroundID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_UserCountry",
                        column: x => x.UserCountryID,
                        principalTable: "UserCountry",
                        principalColumn: "UserCountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false),
                    DiscountID = table.Column<int>(type: "int", nullable: false),
                    GameTypleID = table.Column<int>(type: "int", nullable: false),
                    GamePrice = table.Column<decimal>(type: "money", nullable: true),
                    GameIntroduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameDetailsText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalBuyCount = table.Column<int>(type: "int", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false, comment: "發布日期")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Game_GameDiscount",
                        column: x => x.DiscountID,
                        principalTable: "GameDiscount",
                        principalColumn: "DiscountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_GameType",
                        column: x => x.GameTypleID,
                        principalTable: "GameType",
                        principalColumn: "GameTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Blockade",
                columns: table => new
                {
                    BlockadeID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    BlockadeUserID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, comment: "被封鎖人之ID")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blockade", x => x.BlockadeID);
                    table.ForeignKey(
                        name: "FK_Blockade_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    ChatID = table.Column<int>(type: "int", nullable: false),
                    FriendID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    ChatContent = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "聊天紀錄"),
                    LastChatDate = table.Column<DateTime>(type: "date", nullable: false, comment: "最後聊天時間"),
                    ChatTime = table.Column<DateTime>(type: "date", nullable: false, comment: "現在聊天時間"),
                    UserID = table.Column<int>(type: "int", nullable: false, comment: "使用者自身")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.ChatID);
                    table.ForeignKey(
                        name: "FK_Chat_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendList",
                columns: table => new
                {
                    FriendLIstID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FriendID = table.Column<int>(type: "int", nullable: false),
                    FriendGroupID = table.Column<int>(type: "int", nullable: true),
                    FriendNickName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    IsBlockade = table.Column<bool>(type: "bit", nullable: true, comment: "是否被封鎖")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendList", x => x.FriendLIstID);
                    table.ForeignKey(
                        name: "FK_FriendList_FriendGroup",
                        column: x => x.FriendLIstID,
                        principalTable: "FriendGroup",
                        principalColumn: "FriendGoupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendList_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendList_User1",
                        column: x => x.FriendID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invite",
                columns: table => new
                {
                    InviteID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false, comment: "被邀請者"),
                    SenderID = table.Column<int>(type: "int", nullable: false, comment: "邀請者"),
                    Message = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invite", x => x.InviteID);
                    table.ForeignKey(
                        name: "FK_Invite_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invite_User1",
                        column: x => x.SenderID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false, comment: "訂單時間"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    OrderStatusID = table.Column<int>(type: "int", nullable: false, comment: "訂單單狀態"),
                    EcpayID = table.Column<int>(type: "int", nullable: false, comment: "Ecpay訂單編號"),
                    invoice = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, comment: "發票票")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus",
                        column: x => x.OrderStatusID,
                        principalTable: "OrderStatus",
                        principalColumn: "OrderStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserEdit",
                columns: table => new
                {
                    UserEditID = table.Column<int>(type: "int", nullable: false, comment: ""),
                    PersonalFile = table.Column<int>(type: "int", nullable: false, comment: "個人檔案"),
                    GameFile = table.Column<int>(type: "int", nullable: true, comment: "遊戲資料"),
                    FriendsList = table.Column<int>(type: "int", nullable: false, comment: "好友名單"),
                    ReplyName = table.Column<int>(type: "int", nullable: false, comment: "是否能回復於個人主頁"),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEdit", x => x.UserEditID);
                    table.ForeignKey(
                        name: "FK_UserEdit_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
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
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MyGame",
                columns: table => new
                {
                    MyGameID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyGame", x => x.MyGameID);
                    table.ForeignKey(
                        name: "FK_MyGame_Game",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MyGame_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemSpecification",
                columns: table => new
                {
                    SystemID = table.Column<int>(type: "int", nullable: false),
                    SystemTypeID = table.Column<int>(type: "int", nullable: false),
                    HDDspace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "硬碟使用空間"),
                    System = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "系統類別"),
                    SystemRam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "記憶體"),
                    GameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSpecification", x => x.SystemID);
                    table.ForeignKey(
                        name: "FK_SystemSpecification_Game",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemSpecification_SystemType",
                        column: x => x.SystemTypeID,
                        principalTable: "SystemType",
                        principalColumn: "SystmTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wish",
                columns: table => new
                {
                    WishID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    AddDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wish", x => x.WishID);
                    table.ForeignKey(
                        name: "FK_Wish_Game",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wish_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemderReply",
                columns: table => new
                {
                    MemderReplyID = table.Column<int>(type: "int", nullable: false),
                    ReplyContent = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "date", nullable: true, comment: "留言當下時間"),
                    FriendID = table.Column<int>(type: "int", nullable: false, comment: "好友才能去主頁留言"),
                    ParentID = table.Column<int>(type: "int", nullable: true, comment: "判斷回復的回覆")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemderReply", x => x.MemderReplyID);
                    table.ForeignKey(
                        name: "FK_MemderReply_FriendList",
                        column: x => x.FriendID,
                        principalTable: "FriendList",
                        principalColumn: "FriendLIstID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemderReply_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orderdetails",
                columns: table => new
                {
                    OrderdetailID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderdetails", x => x.OrderdetailID);
                    table.ForeignKey(
                        name: "FK_Orderdetails_Order",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPrivacy",
                columns: table => new
                {
                    UserPrivacyID = table.Column<int>(type: "int", nullable: false),
                    UserEditID = table.Column<int>(type: "int", nullable: false),
                    PrivacyState = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "隱私狀況")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrivacy", x => x.UserPrivacyID);
                    table.ForeignKey(
                        name: "FK_UserPrivacy_UserEdit",
                        column: x => x.UserEditID,
                        principalTable: "UserEdit",
                        principalColumn: "UserEditID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ArticleID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ArticleContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostDate = table.Column<DateTime>(type: "date", nullable: false, comment: "發文日期"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ForumID = table.Column<int>(type: "int", nullable: false),
                    LastReplyTime = table.Column<DateTime>(type: "date", nullable: false, comment: "最後回文時間"),
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
                        principalColumn: "UserID",
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
                        principalColumn: "MyGameID",
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
                        principalColumn: "UserID",
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
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceReply",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    ReplyContent = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "客服回應")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ServiceReply_CustomerService",
                        column: x => x.ServiceID,
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
                        principalColumn: "UserID",
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
                name: "IX_Blockade_UserID",
                table: "Blockade",
                column: "UserID");

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
                name: "IX_FriendList_FriendID",
                table: "FriendList",
                column: "FriendID");

            migrationBuilder.CreateIndex(
                name: "IX_FriendList_UserID",
                table: "FriendList",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Game_DiscountID",
                table: "Game",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameTypleID",
                table: "Game",
                column: "GameTypleID");

            migrationBuilder.CreateIndex(
                name: "IX_GameType_TypelistID",
                table: "GameType",
                column: "TypelistID");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_SenderID",
                table: "Invite",
                column: "SenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_UserID",
                table: "Invite",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MemderReply_FriendID",
                table: "MemderReply",
                column: "FriendID");

            migrationBuilder.CreateIndex(
                name: "IX_MemderReply_UserID",
                table: "MemderReply",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MyForum_ForumID",
                table: "MyForum",
                column: "ForumID");

            migrationBuilder.CreateIndex(
                name: "IX_MyForum_UserID",
                table: "MyForum",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MyGame_GameID",
                table: "MyGame",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_MyGame_UserID",
                table: "MyGame",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusID",
                table: "Order",
                column: "OrderStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserID",
                table: "Order",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Orderdetails_OrderID",
                table: "Orderdetails",
                column: "OrderID");

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
                name: "IX_ServiceReply_ServiceID",
                table: "ServiceReply",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSpecification_GameID",
                table: "SystemSpecification",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSpecification_SystemTypeID",
                table: "SystemSpecification",
                column: "SystemTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserBackgroundID",
                table: "User",
                column: "UserBackgroundID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserCountryID",
                table: "User",
                column: "UserCountryID");

            migrationBuilder.CreateIndex(
                name: "IX_UserEdit_UserID",
                table: "UserEdit",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivacy_UserEditID",
                table: "UserPrivacy",
                column: "UserEditID");

            migrationBuilder.CreateIndex(
                name: "IX_Wish_GameID",
                table: "Wish",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Wish_UserID",
                table: "Wish",
                column: "UserID");
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
                name: "Blockade");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "GamePicture");

            migrationBuilder.DropTable(
                name: "GameVideo");

            migrationBuilder.DropTable(
                name: "Invite");

            migrationBuilder.DropTable(
                name: "MemderReply");

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
                name: "FriendList");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropTable(
                name: "CustomerService");

            migrationBuilder.DropTable(
                name: "SystemType");

            migrationBuilder.DropTable(
                name: "UserEdit");

            migrationBuilder.DropTable(
                name: "FriendGroup");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "MyGame");

            migrationBuilder.DropTable(
                name: "ArticleTag");

            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "UserBackground");

            migrationBuilder.DropTable(
                name: "UserCountry");

            migrationBuilder.DropTable(
                name: "GameDiscount");

            migrationBuilder.DropTable(
                name: "GameType");

            migrationBuilder.DropTable(
                name: "Typelist");
        }
    }
}
