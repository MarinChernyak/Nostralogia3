using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NostralogiaDAL.NostraGeoEntities
{
    public partial class NostraGeoContext : DbContext
    {
        public NostraGeoContext()
        {
        }

        public NostraGeoContext(DbContextOptions<NostraGeoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<StateRegion> StateRegions { get; set; }
        public virtual DbSet<TimeZoneList> TimeZoneLists { get; set; }
        public virtual DbSet<VwGeoGeneral> VwGeoGenerals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-3MNP0406;Database=NostraGeo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegionState).HasColumnName("Region_State");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cities_countries");

                entity.HasOne(d => d.RegionStateNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.RegionState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cities_state_region");

                entity.HasOne(d => d.TimeZoneNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.TimeZone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cities_TimeZoneList");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Acronym)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StateRegion>(entity =>
            {
                entity.ToTable("state_region");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Acronym)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CountryRef).HasColumnName("Country_ref");

                entity.Property(e => e.StateRegion1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("State_region");
            });

            modelBuilder.Entity<TimeZoneList>(entity =>
            {
                entity.HasKey(e => e.Idtzone);

                entity.ToTable("TimeZoneList");

                entity.Property(e => e.Idtzone).HasColumnName("IDTZone");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LocationWorldWide)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("Location_World_Wide");

                entity.Property(e => e.TzoneName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("TZone_name");
            });

            modelBuilder.Entity<VwGeoGeneral>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwGeoGeneral");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.Acronym)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Expr1)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RegionState).HasColumnName("Region_State");

                entity.Property(e => e.StateRegion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("State_region");

                entity.Property(e => e.TzoneName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("TZone_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
