using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SenGame.Models
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
        public virtual DbSet<Blockade> Blockades { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<CustomerService> CustomerServices { get; set; }
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<FriendGroup> FriendGroups { get; set; }
        public virtual DbSet<FriendList> FriendLists { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameDiscount> GameDiscounts { get; set; }
        public virtual DbSet<GamePicture> GamePictures { get; set; }
        public virtual DbSet<GameType> GameTypes { get; set; }
        public virtual DbSet<GameVideo> GameVideos { get; set; }
        public virtual DbSet<Invite> Invites { get; set; }
        public virtual DbSet<MemderReply> MemderReplies { get; set; }
        public virtual DbSet<MyForum> MyForums { get; set; }
        public virtual DbSet<MyGame> MyGames { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<ReplyLike> ReplyLikes { get; set; }
        public virtual DbSet<ServiceReply> ServiceReplies { get; set; }
        public virtual DbSet<SystemSpecification> SystemSpecifications { get; set; }
        public virtual DbSet<SystemType> SystemTypes { get; set; }
        public virtual DbSet<Typelist> Typelists { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserBackground> UserBackgrounds { get; set; }
        public virtual DbSet<UserCountry> UserCountries { get; set; }
        public virtual DbSet<UserEdit> UserEdits { get; set; }
        public virtual DbSet<UserPrivacy> UserPrivacies { get; set; }
        public virtual DbSet<Wish> Wishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
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
                    .HasColumnType("date")
                    .HasComment("最後回文時間");

                entity.Property(e => e.PostDate)
                    .HasColumnType("date")
                    .HasComment("發文日期");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

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

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleLikes)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Like_Article");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ArticleLikes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Like_User");
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

            modelBuilder.Entity<Blockade>(entity =>
            {
                entity.ToTable("Blockade");

                entity.Property(e => e.BlockadeId)
                    .ValueGeneratedNever()
                    .HasColumnName("BlockadeID");

                entity.Property(e => e.BlockadeUserId)
                    .HasMaxLength(10)
                    .HasColumnName("BlockadeUserID")
                    .IsFixedLength(true)
                    .HasComment("被封鎖人之ID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Blockades)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Blockade_User");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("Chat");

                entity.Property(e => e.ChatId)
                    .ValueGeneratedNever()
                    .HasColumnName("ChatID");

                entity.Property(e => e.ChatContent).HasComment("聊天紀錄");

                entity.Property(e => e.ChatTime)
                    .HasColumnType("date")
                    .HasComment("現在聊天時間");

                entity.Property(e => e.FriendId)
                    .HasMaxLength(10)
                    .HasColumnName("FriendID")
                    .IsFixedLength(true);

                entity.Property(e => e.LastChatDate)
                    .HasColumnType("date")
                    .HasComment("最後聊天時間");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasComment("使用者自身");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_User");
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

                entity.HasOne(d => d.MyGame)
                    .WithMany(p => p.CustomerServices)
                    .HasForeignKey(d => d.MyGameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerService_MyGame");
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

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Forums)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_Forum_Game");
            });

            modelBuilder.Entity<FriendGroup>(entity =>
            {
                entity.HasKey(e => e.FriendGoupId);

                entity.ToTable("FriendGroup");

                entity.Property(e => e.FriendGoupId)
                    .ValueGeneratedNever()
                    .HasColumnName("FriendGoupID");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<FriendList>(entity =>
            {
                entity.ToTable("FriendList");

                entity.Property(e => e.FriendListId)
                    .ValueGeneratedNever()
                    .HasColumnName("FriendLIstID");

                entity.Property(e => e.FriendGroupId).HasColumnName("FriendGroupID");

                entity.Property(e => e.FriendId).HasColumnName("FriendID");

                entity.Property(e => e.FriendNickName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.IsBlockade).HasComment("是否被封鎖");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.FriendListFriends)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendList_User1");

                entity.HasOne(d => d.FriendListNavigation)
                    .WithOne(p => p.FriendList)
                    .HasForeignKey<FriendList>(d => d.FriendListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendList_FriendGroup");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FriendListUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendList_User");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.GameId)
                    .ValueGeneratedNever()
                    .HasColumnName("GameID");

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.GamePrice).HasColumnType("money");

                entity.Property(e => e.GameTypleId).HasColumnName("GameTypleID");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasComment("發布日期");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Game_GameDiscount");

                entity.HasOne(d => d.GameTyple)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.GameTypleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Game_GameType");
            });

            modelBuilder.Entity<GameDiscount>(entity =>
            {
                entity.HasKey(e => e.DiscountId);

                entity.ToTable("GameDiscount");

                entity.Property(e => e.DiscountId)
                    .ValueGeneratedNever()
                    .HasColumnName("DiscountID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StarDate).HasColumnType("date");
            });

            modelBuilder.Entity<GamePicture>(entity =>
            {
                entity.ToTable("GamePicture");

                entity.Property(e => e.GamePictureId)
                    .ValueGeneratedNever()
                    .HasColumnName("GamePictureID");

                entity.Property(e => e.GameId)
                    .HasColumnName("GameID")
                    .HasComment("是甚麼影片");

                entity.Property(e => e.Instructions)
                    .HasMaxLength(50)
                    .HasComment("用途");
            });

            modelBuilder.Entity<GameType>(entity =>
            {
                entity.ToTable("GameType");

                entity.Property(e => e.GameTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("GameTypeID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.TypelistId).HasColumnName("TypelistID");

                entity.HasOne(d => d.Typelist)
                    .WithMany(p => p.GameTypes)
                    .HasForeignKey(d => d.TypelistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameType_Typelist");
            });

            modelBuilder.Entity<GameVideo>(entity =>
            {
                entity.ToTable("GameVideo");

                entity.Property(e => e.GameVideoId)
                    .ValueGeneratedNever()
                    .HasColumnName("GameVideoID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.Instructions).HasMaxLength(50);
            });

            modelBuilder.Entity<Invite>(entity =>
            {
                entity.ToTable("Invite");

                entity.Property(e => e.InviteId)
                    .ValueGeneratedNever()
                    .HasColumnName("InviteID");

                entity.Property(e => e.Message)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.SenderId)
                    .HasColumnName("SenderID")
                    .HasComment("邀請者");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasComment("被邀請者");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.InviteSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invite_User1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.InviteUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invite_User");
            });

            modelBuilder.Entity<MemderReply>(entity =>
            {
                entity.ToTable("MemderReply");

                entity.Property(e => e.MemderReplyId)
                    .ValueGeneratedNever()
                    .HasColumnName("MemderReplyID");

                entity.Property(e => e.FriendId)
                    .HasColumnName("FriendID")
                    .HasComment("好友才能去主頁留言");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasComment("判斷回復的回覆");

                entity.Property(e => e.ReplyContent).HasMaxLength(200);

                entity.Property(e => e.ReplyDate)
                    .HasColumnType("date")
                    .HasComment("留言當下時間");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.MemderReplies)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemderReply_FriendList");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MemderReplies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemderReply_User");
            });

            modelBuilder.Entity<MyForum>(entity =>
            {
                entity.ToTable("MyForum");

                entity.Property(e => e.MyForumId)
                    .ValueGeneratedNever()
                    .HasColumnName("MyForumID");

                entity.Property(e => e.ForumId).HasColumnName("ForumID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Forum)
                    .WithMany(p => p.MyForums)
                    .HasForeignKey(d => d.ForumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyForum_Forum");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MyForums)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyForum_User");
            });

            modelBuilder.Entity<MyGame>(entity =>
            {
                entity.ToTable("MyGame");

                entity.Property(e => e.MyGameId)
                    .ValueGeneratedNever()
                    .HasColumnName("MyGameID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.MyGames)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyGame_Game");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MyGames)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyGame_User");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasComment("訂單時間");

                entity.Property(e => e.EcpayId)
                    .HasColumnName("EcpayID")
                    .HasComment("Ecpay訂單編號");

                entity.Property(e => e.Invoice)
                    .HasMaxLength(10)
                    .HasColumnName("invoice")
                    .IsFixedLength(true)
                    .HasComment("發票票");

                entity.Property(e => e.OrderStatusId)
                    .HasColumnName("OrderStatusID")
                    .HasComment("訂單單狀態");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_OrderStatus");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.Property(e => e.OrderStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderStatusID");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(10)
                    .IsFixedLength(true)
                    .HasComment("狀態");
            });

            modelBuilder.Entity<Orderdetail>(entity =>
            {
                entity.Property(e => e.OrderdetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderdetailID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orderdetails_Order");
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

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reply_Article");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reply_User");
            });

            modelBuilder.Entity<ReplyLike>(entity =>
            {
                entity.ToTable("ReplyLike");

                entity.Property(e => e.ReplyLikeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ReplyLikeID");

                entity.Property(e => e.ReplyId).HasColumnName("ReplyID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Reply)
                    .WithMany(p => p.ReplyLikes)
                    .HasForeignKey(d => d.ReplyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReplyLike_Reply");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReplyLikes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReplyLike_User");
            });

            modelBuilder.Entity<ServiceReply>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ServiceReply");

                entity.Property(e => e.ReplyContent)
                    .IsRequired()
                    .HasComment("客服回應");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Service)
                    .WithMany()
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceReply_CustomerService");
            });

            modelBuilder.Entity<SystemSpecification>(entity =>
            {
                entity.HasKey(e => e.SystemId);

                entity.ToTable("SystemSpecification");

                entity.Property(e => e.SystemId)
                    .ValueGeneratedNever()
                    .HasColumnName("SystemID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.Hddspace)
                    .HasMaxLength(50)
                    .HasColumnName("HDDspace")
                    .HasComment("硬碟使用空間");

                entity.Property(e => e.System)
                    .HasMaxLength(50)
                    .HasComment("系統類別");

                entity.Property(e => e.SystemRam)
                    .HasMaxLength(50)
                    .HasComment("記憶體");

                entity.Property(e => e.SystemTypeId).HasColumnName("SystemTypeID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.SystemSpecifications)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SystemSpecification_Game");

                entity.HasOne(d => d.SystemType)
                    .WithMany(p => p.SystemSpecifications)
                    .HasForeignKey(d => d.SystemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SystemSpecification_SystemType");
            });

            modelBuilder.Entity<SystemType>(entity =>
            {
                entity.HasKey(e => e.SystmTypeId);

                entity.ToTable("SystemType");

                entity.Property(e => e.SystmTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("SystmTypeID");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Typelist>(entity =>
            {
                entity.ToTable("Typelist");

                entity.Property(e => e.TypelistId)
                    .ValueGeneratedNever()
                    .HasColumnName("TypelistID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PassWord).IsRequired();

                entity.Property(e => e.UserAbout).HasComment("自介");

                entity.Property(e => e.UserBackgroundId).HasColumnName("UserBackgroundID");

                entity.Property(e => e.UserCountryId).HasColumnName("UserCountryID");

                entity.Property(e => e.UserPicture).HasMaxLength(256);

                entity.Property(e => e.UsernickName).HasMaxLength(256);

                entity.HasOne(d => d.UserBackground)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserBackgroundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserBackground");

                entity.HasOne(d => d.UserCountry)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserCountryId)
                    .HasConstraintName("FK_User_UserCountry");
            });

            modelBuilder.Entity<UserBackground>(entity =>
            {
                entity.ToTable("UserBackground");

                entity.Property(e => e.UserBackgroundId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserBackgroundID");

                entity.Property(e => e.BackgroundColor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserCountry>(entity =>
            {
                entity.ToTable("UserCountry");

                entity.Property(e => e.UserCountryId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserCountryID");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<UserEdit>(entity =>
            {
                entity.ToTable("UserEdit");

                entity.Property(e => e.UserEditId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserEditID")
                    .HasComment("");

                entity.Property(e => e.FriendsList).HasComment("好友名單");

                entity.Property(e => e.GameFile).HasComment("遊戲資料");

                entity.Property(e => e.PersonalFile).HasComment("個人檔案");

                entity.Property(e => e.ReplyName).HasComment("是否能回復於個人主頁");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEdits)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserEdit_User");
            });

            modelBuilder.Entity<UserPrivacy>(entity =>
            {
                entity.ToTable("UserPrivacy");

                entity.Property(e => e.UserPrivacyId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserPrivacyID");

                entity.Property(e => e.PrivacyState)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("隱私狀況");

                entity.Property(e => e.UserEditId).HasColumnName("UserEditID");

                entity.HasOne(d => d.UserEdit)
                    .WithMany(p => p.UserPrivacies)
                    .HasForeignKey(d => d.UserEditId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPrivacy_UserEdit");
            });

            modelBuilder.Entity<Wish>(entity =>
            {
                entity.ToTable("Wish");

                entity.Property(e => e.WishId)
                    .ValueGeneratedNever()
                    .HasColumnName("WishID");

                entity.Property(e => e.AddDate).HasColumnType("date");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Wishes)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wish_Game");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Wishes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wish_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
