using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class NostradamusContext : DbContext
    {
        public NostradamusContext()
        {
        }

        public NostradamusContext(DbContextOptions<NostradamusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authenticity> Authenticities { get; set; }
        public virtual DbSet<CharacteristicsDisaster> CharacteristicsDisasters { get; set; }
        public virtual DbSet<CoordinateEvent> CoordinateEvents { get; set; }
        public virtual DbSet<Datatype> Datatypes { get; set; }
        public virtual DbSet<EventHistorScale> EventHistorScales { get; set; }
        public virtual DbSet<EventHistorScaleVal> EventHistorScaleVals { get; set; }
        public virtual DbSet<EventPlaceType> EventPlaceTypes { get; set; }
        public virtual DbSet<EventScale> EventScales { get; set; }
        public virtual DbSet<EventScaleVal> EventScaleVals { get; set; }
        public virtual DbSet<EventsCategory> EventsCategories { get; set; }
        public virtual DbSet<EventsKwStorage> EventsKwStorages { get; set; }
        public virtual DbSet<Eventslist> Eventslists { get; set; }
        public virtual DbSet<Expansion> Expansions { get; set; }
        public virtual DbSet<ImpactRelatedSector> ImpactRelatedSectors { get; set; }
        public virtual DbSet<KeyWord1> KeyWords1 { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<MapNote> MapNotes { get; set; }
        public virtual DbSet<PeopleUser> PeopleUsers { get; set; }
        public virtual DbSet<Peopleevent> Peopleevents { get; set; }
        public virtual DbSet<Peoplekeywordsstore> Peoplekeywordsstores { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Picture1> Pictures1 { get; set; }
        public virtual DbSet<PlaceEvent> PlaceEvents { get; set; }
        public virtual DbSet<PotentialSeverity> PotentialSeverities { get; set; }
        public virtual DbSet<RectTimeVarCharacteristic> RectTimeVarCharacteristics { get; set; }
        public virtual DbSet<RectTimeVariant> RectTimeVariants { get; set; }
        public virtual DbSet<Relationship> Relationships { get; set; }
        public virtual DbSet<Relative> Relatives { get; set; }
        public virtual DbSet<SexDatum> SexData { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<Source1> Sources1 { get; set; }
        public virtual DbSet<TimesShift> TimesShifts { get; set; }
        public virtual DbSet<VwEmptyPeopleRecord> VwEmptyPeopleRecords { get; set; }
        public virtual DbSet<VwPeopleEvent> VwPeopleEvents { get; set; }
        public virtual DbSet<VwPeopleKeyWord> VwPeopleKeyWords { get; set; }
        public virtual DbSet<VwPeoplePictEvKw> VwPeoplePictEvKws { get; set; }
        public virtual DbSet<VwPersonalDatum> VwPersonalData { get; set; }
        public virtual DbSet<VwPersonalDisplayDatum> VwPersonalDisplayData { get; set; }
        public virtual DbSet<VwPersonalNote> VwPersonalNotes { get; set; }
        public virtual DbSet<VwRectTimeVariant> VwRectTimeVariants { get; set; }
        public virtual DbSet<VwRelative> VwRelatives { get; set; }
        public virtual DbSet<VwWorldEvent> VwWorldEvents { get; set; }
        public virtual DbSet<Worldevent> Worldevents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-LE4MQKM2;Database=NostradamusTest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Authenticity>(entity =>
            {
                entity.ToTable("authenticity");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Authenticity1)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("Authenticity");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<CharacteristicsDisaster>(entity =>
            {
                entity.ToTable("characteristics_disaster", "we");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdEvent).HasColumnName("ID_Event");

                entity.Property(e => e.ImpactRelatedSectors).HasColumnName("Impact_related_sectors");

                entity.Property(e => e.PotentialSeverity).HasColumnName("Potential_severity");

                entity.Property(e => e.SurviversNumber).HasColumnName("Survivers_number");

                entity.Property(e => e.WictimsNumber).HasColumnName("Wictims_number");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.CharacteristicsDisasters)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_we_characteristics_disaster_we_worldevents");

                entity.HasOne(d => d.ImpactRelatedSectorsNavigation)
                    .WithMany(p => p.CharacteristicsDisasters)
                    .HasForeignKey(d => d.ImpactRelatedSectors)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_we_characteristics_disaster_we_impact_related_sectors");

                entity.HasOne(d => d.PotentialSeverityNavigation)
                    .WithMany(p => p.CharacteristicsDisasters)
                    .HasForeignKey(d => d.PotentialSeverity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_we_characteristics_disaster_we_potential_severity");
            });

            modelBuilder.Entity<CoordinateEvent>(entity =>
            {
                entity.ToTable("coordinate_event", "we");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.DiffTime).HasColumnName("Diff_time");

                entity.Property(e => e.IdEvent).HasColumnName("ID_Event");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.CoordinateEvents)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_coordinate_event_worldevents");
            });

            modelBuilder.Entity<Datatype>(entity =>
            {
                entity.HasKey(e => e.Idtype);

                entity.ToTable("datatype");

                entity.Property(e => e.Idtype).HasColumnName("IDType");

                entity.Property(e => e.Adv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ADV");

                entity.Property(e => e.AdvAppl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("ADV_APPL");

                entity.Property(e => e.DataType1)
                    .HasMaxLength(50)
                    .HasColumnName("DataType");

                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<EventHistorScale>(entity =>
            {
                entity.ToTable("Event_histor_scale", "we");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Sc0)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sc0");

                entity.Property(e => e.Sc1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sc1");

                entity.Property(e => e.Sc10)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sc10");

                entity.Property(e => e.Sc2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sc2");

                entity.Property(e => e.Sc3)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sc3");

                entity.Property(e => e.Sc4)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sc4");

                entity.Property(e => e.Sc5)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sc5");

                entity.Property(e => e.Sc6)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sc6");

                entity.Property(e => e.Sc7)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sc7");

                entity.Property(e => e.Sc8)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sc8");

                entity.Property(e => e.Sc9)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sc9");

                entity.Property(e => e.ScaleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.KindEventNavigation)
                    .WithMany(p => p.EventHistorScales)
                    .HasForeignKey(d => d.KindEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_we_Event_histor_scale_we_kind_of_event");
            });

            modelBuilder.Entity<EventHistorScaleVal>(entity =>
            {
                entity.ToTable("Event_histor_scale_val", "we");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdEvent).HasColumnName("ID_Event");

                entity.Property(e => e.IdHistScale).HasColumnName("ID_Hist_Scale");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.EventHistorScaleVals)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_we_Event_histor_scale_val_we_worldevents");

                entity.HasOne(d => d.IdHistScaleNavigation)
                    .WithMany(p => p.EventHistorScaleVals)
                    .HasForeignKey(d => d.IdHistScale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_histor_scale_val_Event_histor_scale");
            });

            modelBuilder.Entity<EventPlaceType>(entity =>
            {
                entity.ToTable("Event_place_type", "we");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment).HasMaxLength(50);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<EventScale>(entity =>
            {
                entity.ToTable("Event_scales", "we");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KkindEvent).HasColumnName("Kkind_event");

                entity.Property(e => e.Sc1)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Sc10).HasMaxLength(500);

                entity.Property(e => e.Sc2)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Sc3)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Sc4)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Sc5).HasMaxLength(500);

                entity.Property(e => e.Sc6).HasMaxLength(500);

                entity.Property(e => e.Sc7).HasMaxLength(550);

                entity.Property(e => e.Sc8).HasMaxLength(500);

                entity.Property(e => e.Sc9).HasMaxLength(500);

                entity.Property(e => e.ScaleDescr).HasMaxLength(50);

                entity.Property(e => e.ScaleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Scale_name");

                entity.HasOne(d => d.KkindEventNavigation)
                    .WithMany(p => p.EventScales)
                    .HasForeignKey(d => d.KkindEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_we_Event_scales_we_kind_of_event");
            });

            modelBuilder.Entity<EventScaleVal>(entity =>
            {
                entity.ToTable("Event_scale_val", "we");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdEvent).HasColumnName("ID_Event");

                entity.Property(e => e.IdScale).HasColumnName("ID_Scale");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.EventScaleVals)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_we_Event_scale_val_we_worldevents");

                entity.HasOne(d => d.IdScaleNavigation)
                    .WithMany(p => p.EventScaleVals)
                    .HasForeignKey(d => d.IdScale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_we_Event_scale_val_we_Event_scales");
            });

            modelBuilder.Entity<EventsCategory>(entity =>
            {
                entity.HasKey(e => e.Idcat);

                entity.ToTable("events_categories");

                entity.Property(e => e.Idcat).HasColumnName("IDCat");

                entity.Property(e => e.AdvCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ADV_Category");
            });

            modelBuilder.Entity<EventsKwStorage>(entity =>
            {
                entity.ToTable("events_kw_storage", "we");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.IdEventKeyword).HasColumnName("ID_Event_keyword");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventsKwStorages)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_we_events_kw_storage_we_worldevents");

                entity.HasOne(d => d.IdEventKeywordNavigation)
                    .WithMany(p => p.EventsKwStorages)
                    .HasForeignKey(d => d.IdEventKeyword)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_we_events_kw_storage_we_kind_of_event");
            });

            modelBuilder.Entity<Eventslist>(entity =>
            {
                entity.HasKey(e => e.Idevent);

                entity.ToTable("eventslist");

                entity.Property(e => e.Idevent)
                    .ValueGeneratedNever()
                    .HasColumnName("IDEvent");

                entity.Property(e => e.AdvEvent)
                    .HasMaxLength(50)
                    .HasColumnName("ADV_Event");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Eventslists)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_eventslist_events_categories");
            });

            modelBuilder.Entity<Expansion>(entity =>
            {
                entity.ToTable("expansion", "we");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdEvent).HasColumnName("ID_event");

                entity.Property(e => e.Idcountry).HasColumnName("IDCountry");

                entity.Property(e => e.Idregion).HasColumnName("IDRegion");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.Expansions)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_we_expansion_we_worldevents");
            });

            modelBuilder.Entity<ImpactRelatedSector>(entity =>
            {
                entity.ToTable("impact_related_sectors", "we");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Impact)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<KeyWord1>(entity =>
            {
                entity.HasKey(e => e.Idkw)
                    .HasName("PK_we_kind_of_event");

                entity.ToTable("KeyWords", "we");

                entity.Property(e => e.Idkw)
                    .ValueGeneratedNever()
                    .HasColumnName("IDKW");

                entity.Property(e => e.AdvKeyWord)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ADV_KeyWord");

                entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasKey(e => e.Idkw);

                entity.ToTable("keywords");

                entity.Property(e => e.Idkw).HasColumnName("IDKW");

                entity.Property(e => e.AccessLevel).HasDefaultValueSql("((4))");

                entity.Property(e => e.AdvKeyWord)
                    .HasMaxLength(150)
                    .HasColumnName("ADV_KeyWord");

                entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");

                entity.HasOne(d => d.Reference)
                    .WithMany(p => p.InverseReference)
                    .HasForeignKey(d => d.ReferenceId)
                    .HasConstraintName("FK_keywords_keywords");
            });

            modelBuilder.Entity<MapNote>(entity =>
            {
                entity.ToTable("mapNotes");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdContributor).HasColumnName("ID_Contributor");

                entity.Property(e => e.IdPerson).HasColumnName("ID_person");

                entity.Property(e => e.IsAvailable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Note).IsRequired();

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.MapNotes)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mapNotes_people");
            });

            modelBuilder.Entity<PeopleUser>(entity =>
            {
                entity.HasKey(e => new { e.Idperson, e.Iduser });

                entity.ToTable("people_users");

                entity.Property(e => e.Idperson).HasColumnName("IDPerson");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.HasOne(d => d.IdpersonNavigation)
                    .WithMany(p => p.PeopleUsers)
                    .HasForeignKey(d => d.Idperson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_people_users_people");
            });

            modelBuilder.Entity<Peopleevent>(entity =>
            {
                entity.ToTable("peopleevents");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcessLevel).HasDefaultValueSql("((100))");

                entity.Property(e => e.Idcontributor)
                    .HasColumnName("IDContributor")
                    .HasDefaultValueSql("((79))");

                entity.Property(e => e.Idperson).HasColumnName("IDPerson");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.EventNavigation)
                    .WithMany(p => p.Peopleevents)
                    .HasForeignKey(d => d.Event)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_peopleevents_eventslist");

                entity.HasOne(d => d.IdpersonNavigation)
                    .WithMany(p => p.Peopleevents)
                    .HasForeignKey(d => d.Idperson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_peopleevents_people");
            });

            modelBuilder.Entity<Peoplekeywordsstore>(entity =>
            {
                entity.ToTable("peoplekeywordsstore");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdPerson).HasColumnName("ID_Person");

                entity.Property(e => e.IsAvailable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Peoplekeywordsstores)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_peoplekeywordsstore_people1");

                entity.HasOne(d => d.KeyWordNavigation)
                    .WithMany(p => p.Peoplekeywordsstores)
                    .HasForeignKey(d => d.KeyWord)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_peoplekeywordsstore_keywords");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("people");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdditionalHours).HasColumnName("Additional_hours");

                entity.Property(e => e.BirthDay)
                    .HasColumnName("Birth_Day")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BirthHourFrom).HasColumnName("Birth_Hour_From");

                entity.Property(e => e.BirthHourTo).HasColumnName("Birth_Hour_To");

                entity.Property(e => e.BirthMinFrom).HasColumnName("Birth_Min_From");

                entity.Property(e => e.BirthMinTo).HasColumnName("Birth_Min_To");

                entity.Property(e => e.BirthMonth)
                    .HasColumnName("Birth_Month")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BirthSecFrom).HasColumnName("Birth_Sec_From");

                entity.Property(e => e.BirthSecTo).HasColumnName("Birth_Sec_To");

                entity.Property(e => e.BirthYear)
                    .HasColumnName("Birth_Year")
                    .HasDefaultValueSql("((1900))");

                entity.Property(e => e.DataType).HasDefaultValueSql("((4))");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name")
                    .HasDefaultValueSql("(N'Unknown')");

                entity.Property(e => e.IdContributor).HasColumnName("ID_contributor");

                entity.Property(e => e.IsAvailable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Place).HasDefaultValueSql("((48))");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("Second_Name")
                    .HasDefaultValueSql("(N'Unknown')");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasKey(e => e.Idpicture);

                entity.ToTable("pictures");

                entity.Property(e => e.Idpicture)
                    .ValueGeneratedNever()
                    .HasColumnName("IDPicture");

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.FileSize).ValueGeneratedOnAdd();

                entity.Property(e => e.IdReference).HasColumnName("ID_Reference");

                entity.Property(e => e.IsAvailable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdReferenceNavigation)
                    .WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.IdReference)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pictures_people");
            });

            modelBuilder.Entity<Picture1>(entity =>
            {
                entity.HasKey(e => e.Idpicture);

                entity.ToTable("pictures", "we");

                entity.Property(e => e.Idpicture).HasColumnName("IDPicture");

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.IdReference).HasColumnName("ID_Reference");

                entity.HasOne(d => d.IdReferenceNavigation)
                    .WithMany(p => p.Picture1s)
                    .HasForeignKey(d => d.IdReference)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pictures_worldevents");
            });

            modelBuilder.Entity<PlaceEvent>(entity =>
            {
                entity.ToTable("place_event", "we");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdEvent).HasColumnName("ID_event");

                entity.Property(e => e.IdPlace).HasColumnName("ID_place");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.PlaceEvents)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_place_event_worldevents");
            });

            modelBuilder.Entity<PotentialSeverity>(entity =>
            {
                entity.ToTable("potential_severity", "we");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Severity)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<RectTimeVarCharacteristic>(entity =>
            {
                entity.ToTable("rect_time_var_characteristic");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RectTimeVariant>(entity =>
            {
                entity.ToTable("rect_time_variants");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdditionalHours).HasColumnName("Additional_hours");

                entity.Property(e => e.DayRect).HasColumnName("Day_Rect");

                entity.Property(e => e.HourRect).HasColumnName("Hour_rect");

                entity.Property(e => e.IdPerson).HasColumnName("ID_Person");

                entity.Property(e => e.IdPlace).HasColumnName("ID_Place");

                entity.Property(e => e.IsAvailable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MinuteRect).HasColumnName("Minute_rect");

                entity.Property(e => e.MonthRect).HasColumnName("Month_Rect");

                entity.Property(e => e.YearRect).HasColumnName("Year_Rect");

                entity.HasOne(d => d.DescriptionNavigation)
                    .WithMany(p => p.RectTimeVariants)
                    .HasForeignKey(d => d.Description)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rect_time_variants_rect_time_var_characteristic");

                entity.HasOne(d => d.SourceNavigation)
                    .WithMany(p => p.RectTimeVariants)
                    .HasForeignKey(d => d.Source)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rect_time_variants_source");
            });

            modelBuilder.Entity<Relationship>(entity =>
            {
                entity.HasKey(e => e.Idrelationship);

                entity.ToTable("relationships");

                entity.Property(e => e.Idrelationship).HasColumnName("IDRelationship");

                entity.Property(e => e.AdvRelationship)
                    .HasMaxLength(100)
                    .HasColumnName("ADV_Relationship")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Relative>(entity =>
            {
                entity.HasKey(e => new { e.IdPerson1, e.IdPerson2, e.Relationship })
                    .HasName("PK_relatives_1");

                entity.ToTable("relatives");

                entity.Property(e => e.IdPerson1).HasColumnName("ID_Person1");

                entity.Property(e => e.IdPerson2).HasColumnName("ID_Person2");
            });

            modelBuilder.Entity<SexDatum>(entity =>
            {
                entity.HasKey(e => e.SexId);

                entity.ToTable("sex_data");

                entity.Property(e => e.SexId)
                    .ValueGeneratedNever()
                    .HasColumnName("SexID");

                entity.Property(e => e.Ids)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("IDS")
                    .IsFixedLength(true);

                entity.Property(e => e.SexDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.HasKey(e => e.Idsource);

                entity.ToTable("source");

                entity.Property(e => e.Idsource).HasColumnName("IDSource");

                entity.Property(e => e.IdsComments)
                    .HasMaxLength(150)
                    .HasColumnName("IDS_Comments")
                    .IsFixedLength(true);

                entity.Property(e => e.IdsSource)
                    .HasMaxLength(50)
                    .HasColumnName("IDS_Source");
            });

            modelBuilder.Entity<Source1>(entity =>
            {
                entity.ToTable("source", "we");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<TimesShift>(entity =>
            {
                entity.HasKey(e => e.Idtimeshift);

                entity.ToTable("times_shift");

                entity.Property(e => e.Idtimeshift).HasColumnName("IDTimeshift");

                entity.Property(e => e.AdvKindOfShift)
                    .HasMaxLength(50)
                    .HasColumnName("ADV_Kind_of_shift");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.ShiftValue).HasColumnName("Shift_Value");
            });

            modelBuilder.Entity<VwEmptyPeopleRecord>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwEmptyPeopleRecords");

                entity.Property(e => e.AccessLevel).HasMaxLength(50);

                entity.Property(e => e.AdditionalHours).HasColumnName("Additional_hours");

                entity.Property(e => e.Authenticity)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDay).HasColumnName("Birth_Day");

                entity.Property(e => e.BirthHourFrom).HasColumnName("Birth_Hour_From");

                entity.Property(e => e.BirthHourTo).HasColumnName("Birth_Hour_To");

                entity.Property(e => e.BirthMinFrom).HasColumnName("Birth_Min_From");

                entity.Property(e => e.BirthMinTo).HasColumnName("Birth_Min_To");

                entity.Property(e => e.BirthMonth).HasColumnName("Birth_Month");

                entity.Property(e => e.BirthYear).HasColumnName("Birth_Year");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdContributor).HasColumnName("ID_contributor");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("Second_Name");
            });

            modelBuilder.Entity<VwPeopleEvent>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPeopleEvents");

                entity.Property(e => e.AdvCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ADV_Category");

                entity.Property(e => e.AdvSource)
                    .HasMaxLength(50)
                    .HasColumnName("ADV_source");

                entity.Property(e => e.Authenticity)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.EventStrId)
                    .HasMaxLength(50)
                    .HasColumnName("EventStrID");

                entity.Property(e => e.Idcontributor).HasColumnName("IDContributor");

                entity.Property(e => e.Idevent).HasColumnName("IDEvent");

                entity.Property(e => e.IdeventKind).HasColumnName("IDEventKind");

                entity.Property(e => e.Idperson).HasColumnName("IDPerson");

                entity.Property(e => e.Idsource).HasColumnName("IDSource");
            });

            modelBuilder.Entity<VwPeopleKeyWord>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPeopleKeyWords");

                entity.Property(e => e.AdvKeyWord)
                    .HasMaxLength(150)
                    .HasColumnName("ADV_KeyWord");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.IdPerson).HasColumnName("ID_Person");

                entity.Property(e => e.Idkw).HasColumnName("IDKW");

                entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("Second_Name");
            });

            modelBuilder.Entity<VwPeoplePictEvKw>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPeoplePictEvKW");

                entity.Property(e => e.AccessLevel).HasMaxLength(50);

                entity.Property(e => e.AdditionalHours).HasColumnName("Additional_hours");

                entity.Property(e => e.Authenticity)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDay).HasColumnName("Birth_Day");

                entity.Property(e => e.BirthHourFrom).HasColumnName("Birth_Hour_From");

                entity.Property(e => e.BirthHourTo).HasColumnName("Birth_Hour_To");

                entity.Property(e => e.BirthMinFrom).HasColumnName("Birth_Min_From");

                entity.Property(e => e.BirthMinTo).HasColumnName("Birth_Min_To");

                entity.Property(e => e.BirthMonth).HasColumnName("Birth_Month");

                entity.Property(e => e.BirthYear).HasColumnName("Birth_Year");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdContributor).HasColumnName("ID_contributor");

                entity.Property(e => e.NumKw).HasColumnName("NumKW");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("Second_Name");
            });

            modelBuilder.Entity<VwPersonalDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPersonalData");

                entity.Property(e => e.AdditionalHours).HasColumnName("Additional_hours");

                entity.Property(e => e.Adv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ADV");

                entity.Property(e => e.Authenticity)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDay).HasColumnName("Birth_Day");

                entity.Property(e => e.BirthHourFrom).HasColumnName("Birth_Hour_From");

                entity.Property(e => e.BirthHourTo).HasColumnName("Birth_Hour_To");

                entity.Property(e => e.BirthMinFrom).HasColumnName("Birth_Min_From");

                entity.Property(e => e.BirthMinTo).HasColumnName("Birth_Min_To");

                entity.Property(e => e.BirthMonth).HasColumnName("Birth_Month");

                entity.Property(e => e.BirthSecFrom).HasColumnName("Birth_Sec_From");

                entity.Property(e => e.BirthSecTo).HasColumnName("Birth_Sec_To");

                entity.Property(e => e.BirthYear).HasColumnName("Birth_Year");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryAcronym)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataTypeDescription).HasMaxLength(100);

                entity.Property(e => e.DataTypeName).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdContributor).HasColumnName("ID_contributor");

                entity.Property(e => e.Ids)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("IDS")
                    .IsFixedLength(true);

                entity.Property(e => e.IdsComments)
                    .HasMaxLength(150)
                    .HasColumnName("IDS_Comments")
                    .IsFixedLength(true);

                entity.Property(e => e.IdsSource)
                    .HasMaxLength(50)
                    .HasColumnName("IDS_Source");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("Second_Name");

                entity.Property(e => e.SexDescription).HasMaxLength(50);

                entity.Property(e => e.SexId).HasColumnName("SexID");

                entity.Property(e => e.StateAcronym)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.StateRegion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("State_region");
            });

            modelBuilder.Entity<VwPersonalDisplayDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPersonalDisplayData");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.AdditionalHours).HasColumnName("Additional_hours");

                entity.Property(e => e.BirthDay).HasColumnName("Birth_Day");

                entity.Property(e => e.BirthHourFrom).HasColumnName("Birth_Hour_From");

                entity.Property(e => e.BirthHourTo).HasColumnName("Birth_Hour_To");

                entity.Property(e => e.BirthMinFrom).HasColumnName("Birth_Min_From");

                entity.Property(e => e.BirthMinTo).HasColumnName("Birth_Min_To");

                entity.Property(e => e.BirthMonth).HasColumnName("Birth_Month");

                entity.Property(e => e.BirthSecFrom).HasColumnName("Birth_Sec_From");

                entity.Property(e => e.BirthSecTo).HasColumnName("Birth_Sec_To");

                entity.Property(e => e.BirthYear).HasColumnName("Birth_Year");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryAcronym)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataTypeDescription)
                    .HasMaxLength(100)
                    .HasColumnName("DataType_Description");

                entity.Property(e => e.DataTypeName)
                    .HasMaxLength(50)
                    .HasColumnName("DataType_Name");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DiffTime).HasColumnName("Diff_Time");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdContributor).HasColumnName("ID_contributor");

                entity.Property(e => e.NumKw).HasColumnName("NumKW");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("Second_Name");

                entity.Property(e => e.SexDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Sex_Description");

                entity.Property(e => e.StateAcronym)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StateId).HasColumnName("StateID");

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

            modelBuilder.Entity<VwPersonalNote>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPersonalNotes");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdContributor).HasColumnName("ID_Contributor");

                entity.Property(e => e.IdPerson).HasColumnName("ID_person");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.UserName).HasMaxLength(20);
            });

            modelBuilder.Entity<VwRectTimeVariant>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwRectTimeVariants");

                entity.Property(e => e.AdditionalHours).HasColumnName("Additional_hours");

                entity.Property(e => e.DayRect).HasColumnName("Day_Rect");

                entity.Property(e => e.DescriptVar)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.HourRect).HasColumnName("Hour_rect");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdPerson).HasColumnName("ID_Person");

                entity.Property(e => e.IdPlace).HasColumnName("ID_Place");

                entity.Property(e => e.MinuteRect).HasColumnName("Minute_rect");

                entity.Property(e => e.MonthRect).HasColumnName("Month_Rect");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("Second_Name");

                entity.Property(e => e.YearRect).HasColumnName("Year_Rect");
            });

            modelBuilder.Entity<VwRelative>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwRelatives");

                entity.Property(e => e.AdvRelationship)
                    .HasMaxLength(100)
                    .HasColumnName("ADV_Relationship")
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.FirstNameRelative).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdRelative).HasColumnName("ID_Relative");

                entity.Property(e => e.Idrelationship).HasColumnName("IDRelationship");

                entity.Property(e => e.LastNameRelative).HasMaxLength(50);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("Second_Name");
            });

            modelBuilder.Entity<VwWorldEvent>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwWorldEvents", "we");

                entity.Property(e => e.CommentEvent).HasColumnName("Comment_event");

                entity.Property(e => e.CommentSource)
                    .HasMaxLength(250)
                    .HasColumnName("Comment_source");

                entity.Property(e => e.ContributorsCountryId).HasColumnName("ContributorsCountryID");

                entity.Property(e => e.DataTypeDetails).HasMaxLength(100);

                entity.Property(e => e.DataTypeName).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.EventKeywords).HasMaxLength(1000);

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EventsDataType).HasColumnName("Events_DataType");

                entity.Property(e => e.EventsDayFrom).HasColumnName("Events_Day_from");

                entity.Property(e => e.EventsDayTo).HasColumnName("Events_Day_to");

                entity.Property(e => e.EventsHFrom).HasColumnName("Events_H_from");

                entity.Property(e => e.EventsHTo).HasColumnName("Events_H_to");

                entity.Property(e => e.EventsMFrom).HasColumnName("Events_M_from");

                entity.Property(e => e.EventsMTo).HasColumnName("Events_M_to");

                entity.Property(e => e.EventsMonthFrom).HasColumnName("Events_Month_from");

                entity.Property(e => e.EventsMonthTo).HasColumnName("Events_Month_to");

                entity.Property(e => e.EventsYearFrom).HasColumnName("Events_Year_from");

                entity.Property(e => e.EventsYearTo).HasColumnName("Events_Year_to");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdContributor).HasColumnName("ID_contributor");

                entity.Property(e => e.IdScaleEvent).HasColumnName("ID_ScaleEvent");

                entity.Property(e => e.IdhistScale).HasColumnName("IDHistScale");

                entity.Property(e => e.ImpactRelatedSectors).HasColumnName("Impact_related_sectors");

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.PagePlaceDataId).HasColumnName("PagePlaceDataID");

                entity.Property(e => e.PotentialSeverity).HasColumnName("Potential_severity");

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.SurviversNumber).HasColumnName("Survivers_number");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.WictimsNumber).HasColumnName("Wictims_number");
            });

            modelBuilder.Entity<Worldevent>(entity =>
            {
                entity.ToTable("worldevents", "we");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CommentEvent).HasColumnName("comment_event");

                entity.Property(e => e.CommentSource)
                    .HasMaxLength(250)
                    .HasColumnName("Comment_source");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EventsDataType).HasColumnName("Events_DataType");

                entity.Property(e => e.EventsDayFrom).HasColumnName("Events_Day_from");

                entity.Property(e => e.EventsDayTo).HasColumnName("Events_Day_to");

                entity.Property(e => e.EventsHFrom).HasColumnName("Events_H_from");

                entity.Property(e => e.EventsHTo).HasColumnName("Events_H_to");

                entity.Property(e => e.EventsMFrom).HasColumnName("Events_M_from");

                entity.Property(e => e.EventsMTo).HasColumnName("Events_M_to");

                entity.Property(e => e.EventsMonthFrom).HasColumnName("Events_Month_from");

                entity.Property(e => e.EventsMonthTo).HasColumnName("Events_Month_to");

                entity.Property(e => e.EventsYearFrom).HasColumnName("Events_Year_from");

                entity.Property(e => e.EventsYearTo).HasColumnName("Events_Year_to");

                entity.Property(e => e.IdContributor).HasColumnName("ID_contributor");

                entity.Property(e => e.SourceEvent).HasColumnName("Source_Event");

                entity.HasOne(d => d.EventsDataTypeNavigation)
                    .WithMany(p => p.Worldevents)
                    .HasForeignKey(d => d.EventsDataType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_worldevents_datatype");

                entity.HasOne(d => d.PlaceDataEventNavigation)
                    .WithMany(p => p.Worldevents)
                    .HasForeignKey(d => d.PlaceDataEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_worldevents_Event_place_type");

                entity.HasOne(d => d.SourceEventNavigation)
                    .WithMany(p => p.Worldevents)
                    .HasForeignKey(d => d.SourceEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_we_worldevents_we_source");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
