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
        public virtual DbSet<RoommiePost> RoommiePosts { get; set; } = null!;
        public virtual DbSet<RoommiePostService> RoommiePostServices { get; set; } = null!;
        public virtual DbSet<RuleCr> RuleCrs { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<SpecificationRentPo> SpecificationRentPos { get; set; } = null!;
        public virtual DbSet<UserCr> UserCrs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=caribbeanrent.database.windows.net; Database=caribbeanrent; User ID=caribbean;Password=cariProject$;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Idcontact)
                    .HasName("PK__Contact__6A51F489E682EE6E");

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
                    .HasName("PK__Favorite__32FAC67A4C727B50");

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
                    .HasName("PK__Image__365310E891D2C955");

                entity.ToTable("Image");

                entity.Property(e => e.Idimage)
                    .HasColumnName("IDImage")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdrentPost).HasColumnName("IDRentPost");

                entity.Property(e => e.Urlimage)
                    .HasMaxLength(40)
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
                    .HasName("PK__InfoUser__D35F93424FDDE51A");

                entity.ToTable("InfoUser");

                entity.Property(e => e.IdinfoUser)
                    .HasColumnName("IDInfoUser")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.Property(e => e.UrlPhoto)
                    .HasMaxLength(40)
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
                    .HasName("PK__RentPost__E70CAE7AB1FF1508");

                entity.ToTable("RentPost");

                entity.Property(e => e.IdrentPost).HasColumnName("IDRentPost");

                entity.Property(e => e.Coordinates)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
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
                    .HasName("PK__RentPost__9EA8144DC8B30DC4");

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
                    .HasName("PK__RentRule__5554434FFA45808C");

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
                    .HasName("PK__ReportRe__0E6517A19ACDED61");

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

            modelBuilder.Entity<RoommiePost>(entity =>
            {
                entity.HasKey(e => e.IdroommiePost)
                    .HasName("PK__RoommieP__558A94F02FD5E790");

                entity.ToTable("RoommiePost");

                entity.Property(e => e.IdroommiePost).HasColumnName("IDRoommiePost");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Ubication)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.RoommiePosts)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_userCR_roommiePost");
            });

            modelBuilder.Entity<RoommiePostService>(entity =>
            {
                entity.HasKey(e => e.IdroommieService)
                    .HasName("PK__RoommieP__D77A2F983D0C4F0C");

                entity.ToTable("RoommiePostService");

                entity.Property(e => e.IdroommieService).HasColumnName("IDRoommieService");

                entity.Property(e => e.IdroommiePost).HasColumnName("IDRoommiePost");

                entity.Property(e => e.Idservice).HasColumnName("IDService");

                entity.HasOne(d => d.IdroommiePostNavigation)
                    .WithMany(p => p.RoommiePostServices)
                    .HasForeignKey(d => d.IdroommiePost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_roomiePost_rommiePostService");

                entity.HasOne(d => d.IdserviceNavigation)
                    .WithMany(p => p.RoommiePostServices)
                    .HasForeignKey(d => d.Idservice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_service_roommiePostService");
            });

            modelBuilder.Entity<RuleCr>(entity =>
            {
                entity.HasKey(e => e.Idrule)
                    .HasName("PK__RuleCR__A42F545DC2CCA393");

                entity.ToTable("RuleCR");

                entity.Property(e => e.Idrule).HasColumnName("IDRule");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Idservice)
                    .HasName("PK__Service__5049E73A50AA860F");

                entity.ToTable("Service");

                entity.Property(e => e.Idservice).HasColumnName("IDService");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SpecificationRentPo>(entity =>
            {
                entity.HasKey(e => e.IdspecificationRentPos)
                    .HasName("PK__Specific__DF81AD3F765B3477");

                entity.Property(e => e.IdspecificationRentPos).HasColumnName("IDSpecificationRentPos");

                entity.Property(e => e.IdrentPost).HasColumnName("IDRentPost");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdrentPostNavigation)
                    .WithMany(p => p.SpecificationRentPos)
                    .HasForeignKey(d => d.IdrentPost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rentPost_infoUser");
            });

            modelBuilder.Entity<UserCr>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__UserCR__C5B19602F2CC3B82");

                entity.ToTable("UserCR");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
