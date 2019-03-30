using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbRepository
{
    public partial class TemphumidContext : DbContext
    {
        public TemphumidContext()
        {
        }

        public TemphumidContext(DbContextOptions<TemphumidContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<TemperaturesHumidities> TemperaturesHumidities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TempHumid;User ID=sa;Password=pass123?");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Devices>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TemperaturesHumidities>(entity =>
            {
                entity.Property(e => e.Humidity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Temperature).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.TemperaturesHumidities)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemperaturesHumidities_Devices");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}