using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SqlModels.Models
{
    public partial class SenGameContext : DbContext
    {
        public SenGameContext()
        {
        }

        public SenGameContext(DbContextOptions<SenGameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleLike> ArticleLikes { get; set; }
        public virtual DbSet<ArticleTag> ArticleTags { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<CustomerService> CustomerServices { get; set; }
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<FriendGroup> FriendGroups { get; set; }
        public virtual DbSet<FriendList> FriendLists { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameDiscount> GameDiscounts { get; set; }
        public virtual DbSet<GameMedium> GameMedia { get; set; }
        public virtual DbSet<GameType> GameTypes { get; set; }
        public virtual DbSet<Invite> Invites { get; set; }
        public virtual DbSet<MyFavouriteId> MyFavouriteIds { get; set; }
        public virtual DbSet<MyForum> MyForums { get; set; }
        public virtual DbSet<MyGame> MyGames { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<ReplyLike> ReplyLikes { get; set; }
        public virtual DbSet<ServiceReply> ServiceReplies { get; set; }
        public virtual DbSet<SystemSpecification> SystemSpecifications { get; set; }
        public virtual DbSet<Typelist> Typelists { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserBackground> UserBackgrounds { get; set; }
        public virtual DbSet<UserCountry> UserCountries { get; set; }
        public virtual DbSet<UserPrivacy> UserPrivacies { get; set; }
        public virtual DbSet<Wish> Wishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=SenGame;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.Property(e => e.ArticleId)
                    .ValueGeneratedNever()
                    .HasColumnName("ArticleID");

                entity.Property(e => e.ArticleContent).IsRequired();

                entity.Property(e => e.ArticleTagId)
                    .HasColumnName("ArticleTagID")
                    .HasComment("種類:討論、心得");

                entity.Property(e => e.ForumId).HasColumnName("ForumID");

                entity.Property(e => e.LastReplyTime)
                    .HasColumnType("datetime")
                    .HasComment("最後回文時間");

                entity.Property(e => e.PostDate)
                    .HasColumnType("datetime")
                    .HasComment("發文日期");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<ArticleLike>(entity =>
            {
                entity.HasKey(e => e.LikeId)
                    .HasName("PK_Like");

                entity.ToTable("ArticleLike");

                entity.Property(e => e.LikeId)
                    .ValueGeneratedNever()
                    .HasColumnName("LikeID");

                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<ArticleTag>(entity =>
            {
                entity.ToTable("ArticleTag");

                entity.Property(e => e.ArticleTagId)
                    .ValueGeneratedNever()
                    .HasColumnName("ArticleTagID");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("Chat");

                entity.Property(e => e.ChatId)
                    .ValueGeneratedNever()
                    .HasColumnName("ChatID");

                entity.Property(e => e.ChatContent).HasComment("聊天紀錄");

                entity.Property(e => e.ChatTime)
                    .HasColumnType("datetime")
                    .HasComment("現在聊天時間");

                entity.Property(e => e.PictureFile).HasComment("暫定");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasComment("使用者自身");
            });

            modelBuilder.Entity<CustomerService>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.ToTable("CustomerService");

                entity.Property(e => e.ServiceId)
                    .ValueGeneratedNever()
                    .HasColumnName("ServiceID");

                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.MyGameId).HasColumnName("MyGameID");

                entity.Property(e => e.QuestionContent).IsRequired();
            });

            modelBuilder.Entity<Forum>(entity =>
            {
                entity.ToTable("Forum");

                entity.Property(e => e.ForumId)
                    .ValueGeneratedNever()
                    .HasColumnName("ForumID");

                entity.Property(e => e.Banner)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FriendGroup>(entity =>
            {
                entity.HasKey(e => e.FriendGoupId);

                entity.ToTable("FriendGroup");

                entity.Property(e => e.FriendGoupId).ValueGeneratedNever();

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<FriendList>(entity =>
            {
                entity.ToTable("FriendList");

                entity.Property(e => e.FriendListId)
                    .ValueGeneratedNever()
                    .HasColumnName("FriendLIstId");

                entity.Property(e => e.FriendNickName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.IsBlockade).HasComment("是否被封鎖");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.GameId).ValueGeneratedNever();

                entity.Property(e => e.Developer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("開發商家");

                entity.Property(e => e.DownTime)
                    .HasColumnType("datetime")
                    .HasComment("商品下架日期");

                entity.Property(e => e.GameDetailsText)
                    .IsRequired()
                    .HasComment("遊戲詳細介紹");

                entity.Property(e => e.GameIntroduction)
                    .IsRequired()
                    .HasComment("遊戲簡介");

                entity.Property(e => e.GameName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GamePrice).HasColumnType("money");

                entity.Property(e => e.Marker)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("開發者");

                entity.Property(e => e.ReleaseTime)
                    .HasColumnType("datetime")
                    .HasComment("發布日期");

                entity.Property(e => e.TotalBuyCount).HasComment("此遊戲被購買次數");
            });

            modelBuilder.Entity<GameDiscount>(entity =>
            {
                entity.HasKey(e => e.DiscountId);

                entity.ToTable("GameDiscount");

                entity.Property(e => e.DiscountId).ValueGeneratedNever();

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StarTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<GameMedium>(entity =>
            {
                entity.HasKey(e => e.GameMediaId);

                entity.Property(e => e.GameMediaId).ValueGeneratedNever();

                entity.Property(e => e.Instruction).HasComment("1.圖片2.影片");

                entity.Property(e => e.InstructionType).HasComment("1幻燈片.2.簡介3.內文");

                entity.Property(e => e.MediaUrl)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Sort).HasComment("排序");
            });

            modelBuilder.Entity<GameType>(entity =>
            {
                entity.ToTable("GameType");

                entity.Property(e => e.GameTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Invite>(entity =>
            {
                entity.ToTable("Invite");

                entity.Property(e => e.InviteId).ValueGeneratedNever();

                entity.Property(e => e.Message)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.SenderId).HasComment("邀請者");

                entity.Property(e => e.UserId).HasComment("被邀請者");
            });

            modelBuilder.Entity<MyFavouriteId>(entity =>
            {
                entity.HasKey(e => e.MyFavouriteId1);

                entity.ToTable("MyFavouriteId");

                entity.Property(e => e.MyFavouriteId1)
                    .ValueGeneratedNever()
                    .HasColumnName("MyFavouriteId");
            });

            modelBuilder.Entity<MyForum>(entity =>
            {
                entity.ToTable("MyForum");

                entity.Property(e => e.MyForumId)
                    .ValueGeneratedNever()
                    .HasColumnName("MyForumID");

                entity.Property(e => e.ForumId).HasColumnName("ForumID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<MyGame>(entity =>
            {
                entity.ToTable("MyGame");

                entity.Property(e => e.MyGameId).ValueGeneratedNever();

                entity.Property(e => e.MyFavouriteId).HasComment("我的最愛");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("訂單時間");

                entity.Property(e => e.EcpayId).HasComment("Ecpay訂單編號");

                entity.Property(e => e.Invoice)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true)
                    .HasComment("發票編碼");

                entity.Property(e => e.InvoiceWay)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true)
                    .HasComment("1.電子發票2.載具3.捐贈");

                entity.Property(e => e.OrderStatus).HasComment("1.購物車 2.待付款  3.付款完成  4.申請退款 5.退款完成");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("訂單更新時間");
            });

            modelBuilder.Entity<Orderdetail>(entity =>
            {
                entity.Property(e => e.OrderdetailId).ValueGeneratedNever();

                entity.Property(e => e.Discount).HasComment("訂單當時折購");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("Reply");

                entity.Property(e => e.ReplyId)
                    .ValueGeneratedNever()
                    .HasColumnName("ReplyID");

                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasComment("回復文章的回覆的回覆");

                entity.Property(e => e.ReplyText).IsRequired();

                entity.Property(e => e.ReplyTitle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<ReplyLike>(entity =>
            {
                entity.ToTable("ReplyLike");

                entity.Property(e => e.ReplyLikeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ReplyLikeID");

                entity.Property(e => e.ReplyId).HasColumnName("ReplyID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<ServiceReply>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ServiceReply");

                entity.Property(e => e.ReplyContent)
                    .IsRequired()
                    .HasComment("客服回應");
            });

            modelBuilder.Entity<SystemSpecification>(entity =>
            {
                entity.ToTable("SystemSpecification");

                entity.Property(e => e.SystemSpecificationId).ValueGeneratedNever();

                entity.Property(e => e.Hddspace)
                    .HasMaxLength(50)
                    .HasColumnName("HDDspace")
                    .HasComment("硬碟使用空間");

                entity.Property(e => e.System)
                    .HasMaxLength(50)
                    .HasComment("系統類別");

                entity.Property(e => e.SystemCpu)
                    .HasMaxLength(50)
                    .HasComment("處理器");

                entity.Property(e => e.SystemGpu)
                    .HasMaxLength(50)
                    .HasComment("顯示卡");

                entity.Property(e => e.SystemRam)
                    .HasMaxLength(50)
                    .HasComment("記憶體");

                entity.Property(e => e.SystemType).HasComment("1:windows 2:Mac");
            });

            modelBuilder.Entity<Typelist>(entity =>
            {
                entity.ToTable("Typelist");

                entity.Property(e => e.TypelistId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("註冊日期");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.EmailConfirmDate).HasColumnType("datetime");

                entity.Property(e => e.PassWord).IsRequired();

                entity.Property(e => e.PrivacyFriendsList).HasComment("好友名單隱私狀態");

                entity.Property(e => e.PrivacyGameFile).HasComment("遊戲資料隱私狀態");

                entity.Property(e => e.PrivacyPersonalFile).HasComment("個人檔案隱私狀態");

                entity.Property(e => e.UserAbout).HasComment("自介");

                entity.Property(e => e.UserBackgroundId).HasComment("使用者背景顏色");

                entity.Property(e => e.UserPicture)
                    .HasMaxLength(256)
                    .HasComment("使用者大頭照");

                entity.Property(e => e.UsernickName)
                    .HasMaxLength(256)
                    .HasComment("使用者暱稱");
            });

            modelBuilder.Entity<UserBackground>(entity =>
            {
                entity.ToTable("UserBackground");

                entity.Property(e => e.UserBackgroundId).ValueGeneratedNever();

                entity.Property(e => e.BackgroundColor)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserCountry>(entity =>
            {
                entity.ToTable("UserCountry");

                entity.Property(e => e.UserCountryId).ValueGeneratedNever();

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<UserPrivacy>(entity =>
            {
                entity.ToTable("UserPrivacy");

                entity.Property(e => e.UserPrivacyId).ValueGeneratedNever();

                entity.Property(e => e.PrivacyState)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("隱私狀況");
            });

            modelBuilder.Entity<Wish>(entity =>
            {
                entity.ToTable("Wish");

                entity.Property(e => e.WishId).ValueGeneratedNever();

                entity.Property(e => e.AddTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
