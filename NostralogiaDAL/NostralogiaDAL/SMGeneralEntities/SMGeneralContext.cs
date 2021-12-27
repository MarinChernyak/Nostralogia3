using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NostralogiaDAL.SMGeneralEntities
{
    public partial class SMGeneralContext : DbContext
    {
        public SMGeneralContext()
        {
        }

        public SMGeneralContext(DbContextOptions<SMGeneralContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SecurityProtocol> SecurityProtocols { get; set; }
        public virtual DbSet<TempPass> TempPasses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAppLanguage> UserAppLanguages { get; set; }
        public virtual DbSet<UserAppPoint> UserAppPoints { get; set; }
        public virtual DbSet<UserAppRole> UserAppRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-LE4MQKM2;Database=SMGeneralTest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("applications", "adm");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles", "adm");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.AppId).HasColumnName("AppID");

                entity.Property(e => e.RoleDescription)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RoleName).HasMaxLength(50);

                entity.Property(e => e.RoleNameIds)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("RoleNameIDS");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.AppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Roles_applications");
            });

            modelBuilder.Entity<SecurityProtocol>(entity =>
            {
                entity.ToTable("SecurityProtocol", "adm");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Passcode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TempPass>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TempPass", "adm");

                entity.Property(e => e.DateExpired).HasColumnType("datetime");

                entity.Property(e => e.Idapp).HasColumnName("IDApp");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.TempPass1)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("TempPass");

                entity.HasOne(d => d.IdappNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idapp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TempPass_applications");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TempPass_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "adm");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActivationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.MidleName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PlaceId).HasColumnName("PlaceID");

                entity.Property(e => e.Sex).HasDefaultValueSql("((3))");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.Token).HasMaxLength(128);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<UserAppLanguage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserAppLanguage", "adm");

                entity.Property(e => e.AppId).HasColumnName("AppID");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.App)
                    .WithMany()
                    .HasForeignKey(d => d.AppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAppLanguage_applications");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAppLanguage_Users");
            });

            modelBuilder.Entity<UserAppPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserAppPoints", "adm");

                entity.Property(e => e.AppId).HasColumnName("AppID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserAppRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("UserAppRole", "adm");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserAppRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAppRole_roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAppRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAppRole_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
