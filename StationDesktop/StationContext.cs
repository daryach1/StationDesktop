using Microsoft.EntityFrameworkCore;
using StationDesktop.Data;

namespace StationDesktop
{
    public partial class StationContext : DbContext
    {
        public StationContext()
        {
        }

        public StationContext(DbContextOptions<StationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CoalSort> CoalSorts { get; set; } = null!;
        public virtual DbSet<Direction> Directions { get; set; } = null!;
        public virtual DbSet<Markup> Markups { get; set; } = null!;
        public virtual DbSet<Park> Parks { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Railway> Railways { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Wagon> Wagons { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=subjectstudio.online;Port=5432;Database=Station;Username=postgres;Password=Astro305");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoalSort>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("CoalSorts_pkey");

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Title).HasColumnType("character varying");
            });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Direction_pkey");

                entity.Property(e => e.Code).HasDefaultValueSql("nextval('\"Direction_Id_seq\"'::regclass)");

                entity.Property(e => e.Title).HasColumnType("character varying");
            });

            modelBuilder.Entity<Markup>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Markup_pkey");

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Color).HasColumnType("character varying");

                entity.Property(e => e.ShortTitle).HasColumnType("character varying");

                entity.Property(e => e.Title).HasColumnType("character varying");
            });

            modelBuilder.Entity<Park>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Park_pkey");

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Title).HasColumnType("character varying");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Positions_pkey");

                entity.Property(e => e.Code).HasDefaultValueSql("nextval('\"Positions_code_seq\"'::regclass)");

                entity.Property(e => e.Title).HasColumnType("character varying");
            });

            modelBuilder.Entity<Railway>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Railway_pkey");

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.HasOne(d => d.ParkCodeNavigation)
                    .WithMany(p => p.Railways)
                    .HasForeignKey(d => d.ParkCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ParkFK");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Users_pkey");

                entity.Property(e => e.Code).HasDefaultValueSql("nextval('\"Users_code_seq\"'::regclass)");

                entity.Property(e => e.Fullname).HasColumnType("character varying");

                entity.Property(e => e.Login).HasColumnType("character varying");

                entity.Property(e => e.Password).HasColumnType("character varying");

                entity.HasOne(d => d.PositionCodeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PositionCode)
                    .HasConstraintName("PositionFK");
            });

            modelBuilder.Entity<Wagon>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Wagon_pkey");

                entity.Property(e => e.Code).HasDefaultValueSql("nextval('\"Wagon_Id_seq\"'::regclass)");

                entity.HasOne(d => d.CoalSortCodeNavigation)
                    .WithMany(p => p.Wagons)
                    .HasForeignKey(d => d.CoalSortCode)
                    .HasConstraintName("CoalSortFK");

                entity.HasOne(d => d.DirectionCodeNavigation)
                    .WithMany(p => p.Wagons)
                    .HasForeignKey(d => d.DirectionCode)
                    .HasConstraintName("DirectionFK");

                entity.HasOne(d => d.MarkupCodeNavigation)
                    .WithMany(p => p.Wagons)
                    .HasForeignKey(d => d.MarkupCode)
                    .HasConstraintName("MarkupFK");

                entity.HasOne(d => d.RailwayCodeNavigation)
                    .WithMany(p => p.Wagons)
                    .HasForeignKey(d => d.RailwayCode)
                    .HasConstraintName("RailwayFK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
