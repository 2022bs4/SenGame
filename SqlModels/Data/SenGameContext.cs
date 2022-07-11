using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SqlModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlModels.Data
{
    public class SenGameContext : IdentityDbContext<UserModel>
    {
        public SenGameContext(DbContextOptions<SenGameContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleLike> ArticleLikes { get; set; }
        public virtual DbSet<ArticleTag> ArticleTags { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<CustomerService> CustomerServices { get; set; }
        public virtual DbSet<Ecpay> Ecpays { get; set; }
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
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<SystemSpecification> SystemSpecifications { get; set; }
        public virtual DbSet<Typelist> Typelists { get; set; }
        public virtual DbSet<UserBackground> UserBackgrounds { get; set; }
        public virtual DbSet<UserCountry> UserCountries { get; set; }
        public virtual DbSet<UserPrivacy> UserPrivacies { get; set; }
        public virtual DbSet<Usergroup> Usergroups { get; set; }
        public virtual DbSet<Wish> Wishes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.HasKey(e => e.ArticleId);

                entity.HasIndex(e => e.ArticleTagId, "IX_Article_ArticleTagId");

                entity.HasIndex(e => e.ForumId, "IX_Article_ForumId");

                entity.HasIndex(e => e.UserId, "IX_Article_UserId");

                entity.Property(e => e.ArticleId).ValueGeneratedNever();

                entity.Property(e => e.ArticleTagId).HasComment("種類:討論、心得");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.LastReplyTime)
                    .HasColumnType("datetime")
                    .HasComment("最後回文時間");

                entity.Property(e => e.PostTime)
                    .HasColumnType("datetime")
                    .HasComment("發文日期");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ArticleTag)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.ArticleTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Article_ArticleTag");

                entity.HasOne(d => d.Forum)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.ForumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Article_Forum");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Article_AspNetUsers");
            });

            modelBuilder.Entity<ArticleLike>(entity =>
            {
                entity.HasKey(e => e.LikeId)
                    .HasName("PK_Like");

                entity.ToTable("ArticleLike");

                entity.HasIndex(e => e.ArticleId, "IX_ArticleLike_ArticleId");

                entity.HasIndex(e => e.UserId, "IX_ArticleLike_UserId");

                entity.Property(e => e.LikeId).ValueGeneratedNever();

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleLikes)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleLike_Article");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ArticleLikes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleLike_AspNetUsers1");
            });

            modelBuilder.Entity<ArticleTag>(entity =>
            {
                entity.ToTable("ArticleTag");

                entity.Property(e => e.ArticleTagId).ValueGeneratedNever();

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

           

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("Chat");

                entity.HasIndex(e => e.UserId, "IX_Chat_UserId");

                entity.Property(e => e.ChatId).ValueGeneratedNever();

                entity.Property(e => e.ChatContent).HasComment("聊天紀錄");

                entity.Property(e => e.ChatTime)
                    .HasColumnType("datetime")
                    .HasComment("現在聊天時間");

                entity.Property(e => e.PictureFile).HasComment("暫定");

                entity.Property(e => e.UserId).HasComment("使用者自身");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_AspNetUsers1");
            });

            modelBuilder.Entity<CustomerService>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.ToTable("CustomerService");

                entity.HasIndex(e => e.GameId, "IX_CustomerService_GameId");

                entity.Property(e => e.ServiceId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.QuestionContent).IsRequired();

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.CustomerServices)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerService_Game");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CustomerServices)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerService_AspNetUsers");
            });

            modelBuilder.Entity<Ecpay>(entity =>
            {
                entity.HasKey(e => e.MerchantId);

                entity.ToTable("Ecpay");

                entity.Property(e => e.MerchantId)
                    .HasMaxLength(50)
                    .HasColumnName("MerchantID")
                    .HasComment("特店編號,Ecpa提供");

                entity.Property(e => e.ChoosePayment).HasComment("1.Criedit 2. ATM");

                entity.Property(e => e.ClientBackUrl)
                    .HasMaxLength(255)
                    .HasColumnName("ClientBackURL")
                    .HasComment("返回指定網頁");

                entity.Property(e => e.ExpireDate).HasComment("允許繳費有效天數");

                entity.Property(e => e.HashIv)
                    .HasMaxLength(255)
                    .HasColumnName("HashIV")
                    .IsFixedLength(true);

                entity.Property(e => e.HashKey)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.ReturnUrl)
                    .HasMaxLength(255)
                    .HasColumnName("ReturnURL")
                    .HasComment("付款完成\r\n通知回傳\r\n網址");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("更新資訊時間");
            });

            modelBuilder.Entity<Forum>(entity =>
            {
                entity.ToTable("Forum");

                entity.HasIndex(e => e.GameId, "IX_Forum_GameId");

                entity.Property(e => e.ForumId).ValueGeneratedNever();

                entity.Property(e => e.Banner)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Forums)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_Forum_Game");
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

                entity.HasIndex(e => e.UserId, "IX_FriendList_UserId");

                entity.Property(e => e.FriendListId)
                    .ValueGeneratedNever()
                    .HasColumnName("FriendLIstId");

                entity.Property(e => e.IsBlockade).HasComment("是否被封鎖");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FriendLists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendList_AspNetUsers1");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.GameId).ValueGeneratedNever();

                entity.Property(e => e.Developer)
                    .IsRequired()
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
                    .HasMaxLength(255);

                entity.Property(e => e.GamePrice).HasColumnType("money");

                entity.Property(e => e.Marker)
                    .IsRequired()
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

                entity.HasIndex(e => e.GameId, "IX_GameDiscount_GameId");

                entity.Property(e => e.DiscountId).ValueGeneratedNever();

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StarTime).HasColumnType("datetime");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameDiscounts)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_GameDiscount_Game");
            });

            modelBuilder.Entity<GameMedium>(entity =>
            {
                entity.HasKey(e => e.GameMediaId);

                entity.HasIndex(e => e.GameId, "IX_GameMedia_GameId");

                entity.Property(e => e.GameMediaId).ValueGeneratedNever();

                entity.Property(e => e.Instruction).HasComment("1.圖片2.影片");

                entity.Property(e => e.InstructionType).HasComment("1幻燈片.2.簡介3.內文");

                entity.Property(e => e.MediaUrl).IsRequired();

                entity.Property(e => e.Sort).HasComment("排序");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameMedia)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameMedia_Game");
            });

            modelBuilder.Entity<GameType>(entity =>
            {
                entity.ToTable("GameType");

                entity.HasIndex(e => e.GameId, "IX_GameType_GameId");

                entity.HasIndex(e => e.TypelistId, "IX_GameType_TypelistId");

                entity.Property(e => e.GameTypeId).ValueGeneratedNever();

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameTypes)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameType_Game");

                entity.HasOne(d => d.Typelist)
                    .WithMany(p => p.GameTypes)
                    .HasForeignKey(d => d.TypelistId)
                    .HasConstraintName("FK_GameType_Typelist");
            });

            modelBuilder.Entity<Invite>(entity =>
            {
                entity.ToTable("Invite");

                entity.HasIndex(e => e.UserId, "IX_Invite_UserId");

                entity.Property(e => e.InviteId).ValueGeneratedNever();

                entity.Property(e => e.Message)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.SenderId).HasComment("邀請者");

                entity.Property(e => e.UserId).HasComment("被邀請者");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Invites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invite_AspNetUsers1");
            });

            modelBuilder.Entity<MyFavouriteId>(entity =>
            {
                entity.HasKey(e => e.MyFavouriteId1);

                entity.ToTable("MyFavouriteId");

                entity.Property(e => e.MyFavouriteId1)
                    .ValueGeneratedNever()
                    .HasColumnName("MyFavouriteId");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.MyFavouriteIds)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyFavouriteId_Game");
            });

            modelBuilder.Entity<MyForum>(entity =>
            {
                entity.ToTable("MyForum");

                entity.HasIndex(e => e.ForumId, "IX_MyForum_ForumId");

                entity.HasIndex(e => e.UserId, "IX_MyForum_UserId");

                entity.Property(e => e.MyForumId).ValueGeneratedNever();

                entity.Property(e => e.Sort).HasComment("看板排序");

                entity.HasOne(d => d.Forum)
                    .WithMany(p => p.MyForums)
                    .HasForeignKey(d => d.ForumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyForum_Forum");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MyForums)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyForum_AspNetUsers1");
            });

            modelBuilder.Entity<MyGame>(entity =>
            {
                entity.ToTable("MyGame");

                entity.HasIndex(e => e.GameId, "IX_MyGame_GameId");

                entity.HasIndex(e => e.Id, "IX_MyGame_UserId");

                entity.Property(e => e.MyGameId).ValueGeneratedNever();

                entity.Property(e => e.MyFavourite).HasComment("判別是否是我的最愛");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.MyGames)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyGame_Game");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MyGames)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyGame_AspNetUsers1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.CancelTime)
                    .HasColumnType("datetime")
                    .HasComment("訂單取消時間");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("訂單時間");

                entity.Property(e => e.EcpayId)
                    .IsRequired()
                    .HasComment("Ecpay訂單編號");

                entity.Property(e => e.Invoice)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsFixedLength(true)
                    .HasComment("發票編碼");

                entity.Property(e => e.InvoiceWay)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsFixedLength(true)
                    .HasComment("1.電子發票2.載具3.捐贈");

                entity.Property(e => e.OrderStatus).HasComment("1.待付款  3.付款完成  4.申請退款 5.退款完成");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.Property(e => e.TradeTime)
                    .HasColumnType("datetime")
                    .HasComment("訂單成立時間");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("訂單更新時間");
            });

            modelBuilder.Entity<Orderdetail>(entity =>
            {
                entity.HasIndex(e => e.GameId, "IX_Orderdetails_GameId");

                entity.HasIndex(e => e.OrderId, "IX_Orderdetails_OrderId");

                entity.Property(e => e.OrderdetailId).ValueGeneratedNever();

                entity.Property(e => e.Discount).HasComment("購買後則顯示當時折扣");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orderdetails_Game");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orderdetails_Order");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("Reply");

                entity.HasIndex(e => e.ArticleId, "IX_Reply_ArticleId");

                entity.HasIndex(e => e.UserId, "IX_Reply_UserId");

                entity.Property(e => e.ReplyId).ValueGeneratedNever();

                entity.Property(e => e.ParentId).HasComment("回復文章的回覆的回覆");

                entity.Property(e => e.ReplyText).IsRequired();

                entity.Property(e => e.ReplyTitle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reply_Article");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reply_AspNetUsers1");
            });

            modelBuilder.Entity<ReplyLike>(entity =>
            {
                entity.ToTable("ReplyLike");

                entity.HasIndex(e => e.ReplyId, "IX_ReplyLike_ReplyId");

                entity.HasIndex(e => e.UserId, "IX_ReplyLike_UserId");

                entity.Property(e => e.ReplyLikeId).ValueGeneratedNever();

                entity.HasOne(d => d.Reply)
                    .WithMany(p => p.ReplyLikes)
                    .HasForeignKey(d => d.ReplyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReplyLike_Reply");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReplyLikes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReplyLike_AspNetUsers1");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("ShoppingCart");

                entity.HasIndex(e => e.GameId, "IX_ShoppingCart_GameId");

                entity.HasIndex(e => e.UserId, "IX_ShoppingCart_UserId");

                //entity.Property(e => e.ShoppingCartId).ValueGeneratedNever();
                
                //測試自動識別?
                entity.Property(e => e.UserId).IsRequired();


                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_ShoppingCart_Game");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ShoppingCart_AspNetUsers1");
            });

            modelBuilder.Entity<SystemSpecification>(entity =>
            {
                entity.ToTable("SystemSpecification");

                entity.HasIndex(e => e.GameId, "IX_SystemSpecification_GameId");

                entity.Property(e => e.SystemSpecificationId).ValueGeneratedNever();

                entity.Property(e => e.Configure).HasComment("1.最低配備 2.建議配備");

                entity.Property(e => e.Hddspace)
                    .HasColumnName("HDDspace")
                    .HasComment("硬碟使用空間");

                entity.Property(e => e.System).HasComment("系統類別");

                entity.Property(e => e.SystemCpu).HasComment("處理器");

                entity.Property(e => e.SystemGpu).HasComment("顯示卡");

                entity.Property(e => e.SystemRam).HasComment("記憶體");

                entity.Property(e => e.SystemType).HasComment("1:windows 2:Mac");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.SystemSpecifications)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SystemSpecification_Game");
            });

            modelBuilder.Entity<Typelist>(entity =>
            {
                entity.ToTable("Typelist");

                entity.Property(e => e.TypelistId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
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

                entity.HasIndex(e => e.UserId, "IX_UserPrivacy_UserId");

                entity.Property(e => e.UserPrivacyId).ValueGeneratedNever();

                entity.Property(e => e.PrivacyState)
                    .IsRequired()
                    .HasComment("隱私狀況");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPrivacies)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserPrivacy_AspNetUsers1");
            });

            modelBuilder.Entity<Usergroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Usergroup");

                entity.HasIndex(e => e.FriendGroupId, "IX_Usergroup_FriendGroupId");

                entity.HasIndex(e => e.UserId, "IX_Usergroup_UserId");

                entity.HasOne(d => d.FriendGroup)
                    .WithMany()
                    .HasForeignKey(d => d.FriendGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usergroup_FriendGroup");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usergroup_AspNetUsers1");
            });

            modelBuilder.Entity<Wish>(entity =>
            {
                entity.ToTable("Wish");

                entity.HasIndex(e => e.GameId, "IX_Wish_GameId");

                entity.Property(e => e.WishId).ValueGeneratedNever();

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Wishes)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wish_Game");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Wishes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wish_AspNetUsers");
            });

            base.OnModelCreating(modelBuilder);
        }


}
}
