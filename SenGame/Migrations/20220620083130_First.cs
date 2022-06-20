using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SenGame.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "GameDiscount",
                columns: table => new
                {
                    DiscountID = table.Column<int>(type: "int", nullable: false),
                    DiscountTake = table.Column<int>(type: "int", nullable: true),
                    StarDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDiscount", x => x.DiscountID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseData",
                columns: table => new
                {
                    PurchaseDataID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseData", x => x.PurchaseDataID);
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
                name: "Visa",
                columns: table => new
                {
                    PayID = table.Column<int>(type: "int", nullable: false),
                    VisaCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisaDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VisaSaft = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visa", x => x.PayID);
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
                    PayID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmailConfirm = table.Column<bool>(type: "bit", nullable: false),
                    PassWordTest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserPicture = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserUrl = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    UsernickName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserCountryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_UserCountry",
                        column: x => x.UserCountryID,
                        principalTable: "UserCountry",
                        principalColumn: "UserCountryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Visa",
                        column: x => x.PayID,
                        principalTable: "Visa",
                        principalColumn: "PayID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false),
                    DiscountID = table.Column<int>(type: "int", nullable: false),
                    GameTypleID = table.Column<int>(type: "int", nullable: false),
                    PurchaseDataID = table.Column<int>(type: "int", nullable: true),
                    GamePrice = table.Column<decimal>(type: "money", nullable: true),
                    GamePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameIntroduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameDetailsText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalBuyCount = table.Column<int>(type: "int", nullable: true),
                    SystemOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemUseSize = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SystemGraphCard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SystemMemory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReleadeDate = table.Column<DateTime>(type: "date", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Game_PurchaseData",
                        column: x => x.PurchaseDataID,
                        principalTable: "PurchaseData",
                        principalColumn: "PurchaseDataID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendList",
                columns: table => new
                {
                    FriendListID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BlockadeList = table.Column<bool>(type: "bit", nullable: false),
                    FriendID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendList", x => x.FriendListID);
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
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SendID = table.Column<int>(type: "int", nullable: false),
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
                        column: x => x.SendID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ArticleID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Check = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    LastTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ArticleID);
                    table.ForeignKey(
                        name: "FK_Article_Game",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MyForum",
                columns: table => new
                {
                    MyForumID = table.Column<int>(type: "int", nullable: false),
                    ForumID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyForum", x => x.MyForumID);
                    table.ForeignKey(
                        name: "FK_MyForum_Game",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MyForum_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
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
                name: "Chat",
                columns: table => new
                {
                    Chatid = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    FriendListID = table.Column<int>(type: "int", nullable: true),
                    ChatDate = table.Column<DateTime>(type: "date", nullable: true),
                    ChatContext = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Chatid);
                    table.ForeignKey(
                        name: "FK_Chat_FriendList",
                        column: x => x.FriendListID,
                        principalTable: "FriendList",
                        principalColumn: "FriendListID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chat_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    LikeID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Article = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.LikeID);
                    table.ForeignKey(
                        name: "FK_Like_Article",
                        column: x => x.Article,
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
                    ReplyMain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplyText = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false)
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
                name: "ReplyLike",
                columns: table => new
                {
                    ReplyLikeID = table.Column<int>(type: "int", nullable: false),
                    ReplyID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_Article_GameID",
                table: "Article",
                column: "GameID");

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
                name: "IX_Chat_FriendListID",
                table: "Chat",
                column: "FriendListID");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UserID",
                table: "Chat",
                column: "UserID");

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
                name: "IX_Game_PurchaseDataID",
                table: "Game",
                column: "PurchaseDataID");

            migrationBuilder.CreateIndex(
                name: "IX_GameType_TypelistID",
                table: "GameType",
                column: "TypelistID");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_SendID",
                table: "Invite",
                column: "SendID");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_UserID",
                table: "Invite",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Like_Article",
                table: "Like",
                column: "Article");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserID",
                table: "Like",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MyForum_GameID",
                table: "MyForum",
                column: "GameID");

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
                name: "IX_User_PayID",
                table: "User",
                column: "PayID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserCountryID",
                table: "User",
                column: "UserCountryID");

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
                name: "Invite");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "MyForum");

            migrationBuilder.DropTable(
                name: "MyGame");

            migrationBuilder.DropTable(
                name: "ReplyLike");

            migrationBuilder.DropTable(
                name: "Wish");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FriendList");

            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "UserCountry");

            migrationBuilder.DropTable(
                name: "Visa");

            migrationBuilder.DropTable(
                name: "GameDiscount");

            migrationBuilder.DropTable(
                name: "GameType");

            migrationBuilder.DropTable(
                name: "PurchaseData");

            migrationBuilder.DropTable(
                name: "Typelist");
        }
    }
}
