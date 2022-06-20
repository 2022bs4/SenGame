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
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<FriendList> FriendLists { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameDiscount> GameDiscounts { get; set; }
        public virtual DbSet<GameType> GameTypes { get; set; }
        public virtual DbSet<Invite> Invites { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<MyForum> MyForums { get; set; }
        public virtual DbSet<MyGame> MyGames { get; set; }
        public virtual DbSet<PurchaseDatum> PurchaseData { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<ReplyLike> ReplyLikes { get; set; }
        public virtual DbSet<Typelist> Typelists { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCountry> UserCountries { get; set; }
        public virtual DbSet<Visa> Visas { get; set; }
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

                entity.Property(e => e.Check)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.LastTime).HasColumnType("date");

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Article_Game");
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

                entity.Property(e => e.Chatid).ValueGeneratedNever();

                entity.Property(e => e.ChatContext).HasMaxLength(255);

                entity.Property(e => e.ChatDate).HasColumnType("date");

                entity.Property(e => e.FriendListId).HasColumnName("FriendListID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FriendList)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.FriendListId)
                    .HasConstraintName("FK_Chat_FriendList");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Chat_User");
            });

            modelBuilder.Entity<FriendList>(entity =>
            {
                entity.ToTable("FriendList");

                entity.Property(e => e.FriendListId)
                    .ValueGeneratedNever()
                    .HasColumnName("FriendListID");

                entity.Property(e => e.FriendId).HasColumnName("FriendID");

                entity.Property(e => e.GroupName).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.FriendListFriends)
                    .HasForeignKey(d => d.FriendId)
                    .HasConstraintName("FK_FriendList_User1");

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

                entity.Property(e => e.PurchaseDataId).HasColumnName("PurchaseDataID");

                entity.Property(e => e.ReleadeDate).HasColumnType("date");

                entity.Property(e => e.SystemGraphCard).HasMaxLength(50);

                entity.Property(e => e.SystemMemory).HasMaxLength(50);

                entity.Property(e => e.SystemUseSize).HasMaxLength(50);

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

                entity.HasOne(d => d.PurchaseData)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.PurchaseDataId)
                    .HasConstraintName("FK_Game_PurchaseData");
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

            modelBuilder.Entity<Invite>(entity =>
            {
                entity.ToTable("Invite");

                entity.Property(e => e.InviteId)
                    .ValueGeneratedNever()
                    .HasColumnName("InviteID");

                entity.Property(e => e.Message)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.SendId).HasColumnName("SendID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Send)
                    .WithMany(p => p.InviteSends)
                    .HasForeignKey(d => d.SendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invite_User1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.InviteUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invite_User");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.ToTable("Like");

                entity.Property(e => e.LikeId)
                    .ValueGeneratedNever()
                    .HasColumnName("LikeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ArticleNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.Article)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Like_Article");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Like_User");
            });

            modelBuilder.Entity<MyForum>(entity =>
            {
                entity.ToTable("MyForum");

                entity.Property(e => e.MyForumId)
                    .ValueGeneratedNever()
                    .HasColumnName("MyForumID");

                entity.Property(e => e.ForumId).HasColumnName("ForumID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.MyForums)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyForum_Game");

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

            modelBuilder.Entity<PurchaseDatum>(entity =>
            {
                entity.HasKey(e => e.PurchaseDataId);

                entity.Property(e => e.PurchaseDataId)
                    .ValueGeneratedNever()
                    .HasColumnName("PurchaseDataID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("Reply");

                entity.Property(e => e.ReplyId)
                    .ValueGeneratedNever()
                    .HasColumnName("ReplyID");

                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.Property(e => e.ReplyMain).IsRequired();

                entity.Property(e => e.ReplyText)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);

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
                    .HasConstraintName("FK_ReplyLike_Reply");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReplyLikes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ReplyLike_User");
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

                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PassWord).IsRequired();

                entity.Property(e => e.PassWordTest).IsRequired();

                entity.Property(e => e.PayId).HasColumnName("PayID");

                entity.Property(e => e.UserCountryId).HasColumnName("UserCountryID");

                entity.Property(e => e.UserPicture).HasMaxLength(256);

                entity.Property(e => e.UserUrl)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UsernickName).HasMaxLength(256);

                entity.HasOne(d => d.Pay)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Visa");

                entity.HasOne(d => d.UserCountry)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserCountryId)
                    .HasConstraintName("FK_User_UserCountry");
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

            modelBuilder.Entity<Visa>(entity =>
            {
                entity.HasKey(e => e.PayId);

                entity.ToTable("Visa");

                entity.Property(e => e.PayId)
                    .ValueGeneratedNever()
                    .HasColumnName("PayID");

                entity.Property(e => e.VisaCard).IsRequired();

                entity.Property(e => e.VisaDate)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.VisaSaft)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength(true);
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
