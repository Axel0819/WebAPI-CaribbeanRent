using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.Models
{
    public partial class caribbeanrentContext : DbContext
    {
        public caribbeanrentContext()
        {
        }

        public caribbeanrentContext(DbContextOptions<caribbeanrentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Favorite> Favorites { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<InfoUser> InfoUsers { get; set; } = null!;
        public virtual DbSet<RentPost> RentPosts { get; set; } = null!;
        public virtual DbSet<RentPostService> RentPostServices { get; set; } = null!;
        public virtual DbSet<RentRule> RentRules { get; set; } = null!;
        public virtual DbSet<ReportRentPost> ReportRentPosts { get; set; } = null!;
        public virtual DbSet<RoomiePost> RoomiePosts { get; set; } = null!;
        public virtual DbSet<RoomiePostService> RoomiePostServices { get; set; } = null!;
        public virtual DbSet<RuleCr> RuleCrs { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<SpecificationRentPost> SpecificationRentPosts { get; set; } = null!;
        public virtual DbSet<UserCr> UserCrs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Idcontact)
                    .HasName("PK__Contact__6A51F489BE06DFE3");

                entity.ToTable("Contact");

                entity.Property(e => e.Idcontact)
                    .HasColumnName("IDContact")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Contact1)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Contact");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_userCR_contact");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasKey(e => e.Idfavorite)
                    .HasName("PK__Favorite__32FAC67A5791C489");

                entity.ToTable("Favorite");

                entity.Property(e => e.Idfavorite).HasColumnName("IDFavorite");

                entity.Property(e => e.IdrentPost).HasColumnName("IDRentPost");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.HasOne(d => d.IdrentPostNavigation)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.IdrentPost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rentPost_favorite");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_userCR_favorite");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.Idimage)
                    .HasName("PK__Image__365310E881DA504B");

                entity.ToTable("Image");

                entity.Property(e => e.Idimage)
                    .HasColumnName("IDImage")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdrentPost).HasColumnName("IDRentPost");

                entity.Property(e => e.Urlimage)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("URLImage");

                entity.HasOne(d => d.IdrentPostNavigation)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.IdrentPost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rentPost_image");
            });

            modelBuilder.Entity<InfoUser>(entity =>
            {
                entity.HasKey(e => e.IdinfoUser)
                    .HasName("PK__InfoUser__D35F9342B59EEABD");

                entity.ToTable("InfoUser");

                entity.Property(e => e.IdinfoUser)
                    .HasColumnName("IDInfoUser")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.Property(e => e.UrlPhoto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.InfoUsers)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_userCR_infoUser");
            });

            modelBuilder.Entity<RentPost>(entity =>
            {
                entity.HasKey(e => e.IdrentPost)
                    .HasName("PK__RentPost__E70CAE7AD912FF13");

                entity.ToTable("RentPost");

                entity.Property(e => e.IdrentPost).HasColumnName("IDRentPost");

                entity.Property(e => e.Coordinates)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Title)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.RentPosts)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_userCR_rentPost");
            });

            modelBuilder.Entity<RentPostService>(entity =>
            {
                entity.HasKey(e => e.IdrentService)
                    .HasName("PK__RentPost__9EA8144DBF2191F2");

                entity.ToTable("RentPostService");

                entity.Property(e => e.IdrentService).HasColumnName("IDRentService");

                entity.Property(e => e.IdrentPost).HasColumnName("IDRentPost");

                entity.Property(e => e.Idservice).HasColumnName("IDService");

                entity.HasOne(d => d.IdrentPostNavigation)
                    .WithMany(p => p.RentPostServices)
                    .HasForeignKey(d => d.IdrentPost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rentPost_rentPostService");

                entity.HasOne(d => d.IdserviceNavigation)
                    .WithMany(p => p.RentPostServices)
                    .HasForeignKey(d => d.Idservice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_service_rentPostService");
            });

            modelBuilder.Entity<RentRule>(entity =>
            {
                entity.HasKey(e => e.IdrentRule)
                    .HasName("PK__RentRule__5554434FD54B34DE");

                entity.ToTable("RentRule");

                entity.Property(e => e.IdrentRule).HasColumnName("IDRentRule");

                entity.Property(e => e.IdrentPost).HasColumnName("IDRentPost");

                entity.Property(e => e.Idrule).HasColumnName("IDRule");

                entity.HasOne(d => d.IdrentPostNavigation)
                    .WithMany(p => p.RentRules)
                    .HasForeignKey(d => d.IdrentPost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rentPost_rentRule");

                entity.HasOne(d => d.IdruleNavigation)
                    .WithMany(p => p.RentRules)
                    .HasForeignKey(d => d.Idrule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ruleCR_rentRule");
            });

            modelBuilder.Entity<ReportRentPost>(entity =>
            {
                entity.HasKey(e => e.Idreport)
                    .HasName("PK__ReportRe__0E6517A15B3044FE");

                entity.ToTable("ReportRentPost");

                entity.Property(e => e.Idreport).HasColumnName("IDReport");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.IdrentPost).HasColumnName("IDRentPost");

                entity.Property(e => e.Uidfrom)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("UIDFrom");

                entity.HasOne(d => d.IdrentPostNavigation)
                    .WithMany(p => p.ReportRentPosts)
                    .HasForeignKey(d => d.IdrentPost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rentPost_reportRentPost");
            });

            modelBuilder.Entity<RoomiePost>(entity =>
            {
                entity.HasKey(e => e.IdroomiePost)
                    .HasName("PK__RoomiePo__5A1DC6D8648623EB");

                entity.ToTable("RoomiePost");

                entity.Property(e => e.IdroomiePost).HasColumnName("IDRoomiePost");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Ubication)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.RoomiePosts)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_userCR_roomiePost");
            });

            modelBuilder.Entity<RoomiePostService>(entity =>
            {
                entity.HasKey(e => e.IdroomieService)
                    .HasName("PK__RoomiePo__6A609FCF0126FCD5");

                entity.ToTable("RoomiePostService");

                entity.Property(e => e.IdroomieService).HasColumnName("IDRoomieService");

                entity.Property(e => e.IdroomiePost).HasColumnName("IDRoomiePost");

                entity.Property(e => e.Idservice).HasColumnName("IDService");

                entity.HasOne(d => d.IdroomiePostNavigation)
                    .WithMany(p => p.RoomiePostServices)
                    .HasForeignKey(d => d.IdroomiePost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_roomiePost_roomiePostService");

                entity.HasOne(d => d.IdserviceNavigation)
                    .WithMany(p => p.RoomiePostServices)
                    .HasForeignKey(d => d.Idservice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_service_roomiePostService");
            });

            modelBuilder.Entity<RuleCr>(entity =>
            {
                entity.HasKey(e => e.Idrule)
                    .HasName("PK__RuleCR__A42F545DB32C2B38");

                entity.ToTable("RuleCR");

                entity.Property(e => e.Idrule).HasColumnName("IDRule");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Idservice)
                    .HasName("PK__Service__5049E73A26332E82");

                entity.ToTable("Service");

                entity.Property(e => e.Idservice).HasColumnName("IDService");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SpecificationRentPost>(entity =>
            {
                entity.HasKey(e => e.IdspecificationRentPost)
                    .HasName("PK__Specific__EA01AEBC3D2C3B89");

                entity.ToTable("SpecificationRentPost");

                entity.Property(e => e.IdspecificationRentPost).HasColumnName("IDSpecificationRentPost");

                entity.Property(e => e.IdrentPost).HasColumnName("IDRentPost");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdrentPostNavigation)
                    .WithMany(p => p.SpecificationRentPosts)
                    .HasForeignKey(d => d.IdrentPost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rentPost_infoUser");
            });

            modelBuilder.Entity<UserCr>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__UserCR__C5B196021AB30FA2");

                entity.ToTable("UserCR");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
