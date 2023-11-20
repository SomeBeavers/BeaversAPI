using System;
using System.Collections.Generic;
using BeaversDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BeaversDB;

public partial class BeaversLifeContext : DbContext
{
    public BeaversLifeContext()
    {
    }

    public BeaversLifeContext(DbContextOptions<BeaversLifeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalInfo> AdditionalInfos { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<AnimalClub> AnimalClubs { get; set; }

    public virtual DbSet<AnimalLocation> AnimalLocations { get; set; }

    public virtual DbSet<Beaver> Beavers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Crow> Crows { get; set; }

    public virtual DbSet<Deer> Deers { get; set; }

    public virtual DbSet<Drawback> Drawbacks { get; set; }

    public virtual DbSet<Elf> Elves { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<MapToQuery> MapToQueries { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=BeaversLife;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdditionalInfo>(entity =>
        {
            entity.HasMany(d => d.Clubs).WithMany(p => p.AdditionalInfos)
                .UsingEntity<Dictionary<string, object>>(
                    "AdditionalInfoClub",
                    r => r.HasOne<Club>().WithMany().HasForeignKey("ClubsId"),
                    l => l.HasOne<AdditionalInfo>().WithMany().HasForeignKey("AdditionalInfosId"),
                    j =>
                    {
                        j.HasKey("AdditionalInfosId", "ClubsId");
                        j.ToTable("AdditionalInfoClub");
                        j.HasIndex(new[] { "ClubsId" }, "IX_AdditionalInfoClub_ClubsId");
                    });
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasIndex(e => e.HatedById, "IX_Animals_HatedById");

            entity.HasIndex(e => e.JobId, "IX_Animals_JobId");

            entity.HasIndex(e => e.LovedById, "IX_Animals_LovedById");

            entity.HasIndex(e => e.Name, "IX_Animals_Name")
                .IsUnique()
                .HasFilter("([Name] IS NOT NULL)");

            entity.Property(e => e.IpAddress).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.HatedBy).WithMany(p => p.AnimalHatedBies).HasForeignKey(d => d.HatedById);

            entity.HasOne(d => d.Job).WithMany(p => p.Animals).HasForeignKey(d => d.JobId);

            entity.HasOne(d => d.LovedBy).WithMany(p => p.AnimalLovedBies).HasForeignKey(d => d.LovedById);
        });

        modelBuilder.Entity<AnimalClub>(entity =>
        {
            entity.HasKey(e => new { e.AnimalId, e.ClubId });

            entity.ToTable("AnimalClub");

            entity.HasIndex(e => e.ClubId, "IX_AnimalClub_ClubId");

            entity.Property(e => e.PublicationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Animal).WithMany(p => p.AnimalClubs).HasForeignKey(d => d.AnimalId);

            entity.HasOne(d => d.Club).WithMany(p => p.AnimalClubs).HasForeignKey(d => d.ClubId);
        });

        modelBuilder.Entity<AnimalLocation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AnimalLocation");
        });

        modelBuilder.Entity<Beaver>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Beaver).HasForeignKey<Beaver>(d => d.Id);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.HasIndex(e => e.FoodId, "IX_Category_FoodId")
                .IsUnique()
                .HasFilter("([FoodId] IS NOT NULL)");

            entity.HasOne(d => d.Food).WithOne(p => p.Category).HasForeignKey<Category>(d => d.FoodId);
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasMany(d => d.Drawbacks).WithMany(p => p.Clubs)
                .UsingEntity<Dictionary<string, object>>(
                    "ClubDrawback",
                    r => r.HasOne<Drawback>().WithMany().HasForeignKey("DrawbacksId"),
                    l => l.HasOne<Club>().WithMany().HasForeignKey("ClubsId"),
                    j =>
                    {
                        j.HasKey("ClubsId", "DrawbacksId");
                        j.ToTable("ClubDrawback");
                        j.HasIndex(new[] { "DrawbacksId" }, "IX_ClubDrawback_DrawbacksId");
                    });
        });

        modelBuilder.Entity<Crow>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Crow).HasForeignKey<Crow>(d => d.Id);
        });

        modelBuilder.Entity<Deer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Deer).HasForeignKey<Deer>(d => d.Id);
        });

        modelBuilder.Entity<Drawback>(entity =>
        {
            entity.Property(e => e.ConsequenceName).HasColumnName("Consequence_Name");

            entity.HasMany(d => d.Foods).WithMany(p => p.Drawbacks)
                .UsingEntity<Dictionary<string, object>>(
                    "DrawbackFood",
                    r => r.HasOne<Food>().WithMany().HasForeignKey("FoodsId"),
                    l => l.HasOne<Drawback>().WithMany().HasForeignKey("DrawbacksId"),
                    j =>
                    {
                        j.HasKey("DrawbacksId", "FoodsId");
                        j.ToTable("DrawbackFood");
                        j.HasIndex(new[] { "FoodsId" }, "IX_DrawbackFood_FoodsId");
                    });
        });

        modelBuilder.Entity<Elf>(entity =>
        {
            entity.HasIndex(e => e.DeerId, "IX_Elves_DeerId");

            entity.HasOne(d => d.Deer).WithMany(p => p.Elves).HasForeignKey(d => d.DeerId);
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.ToTable("Food");

            entity.HasIndex(e => e.AnimalId, "IX_Food_AnimalId")
                .IsUnique()
                .HasFilter("([AnimalId] IS NOT NULL)");

            entity.Property(e => e.Discriminator).HasMaxLength(13);

            entity.HasOne(d => d.Animal).WithOne(p => p.Food).HasForeignKey<Food>(d => d.AnimalId);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasIndex(e => e.AdditionalInfoId, "IX_Grades_AdditionalInfoId");

            entity.HasIndex(e => e.AnimalId, "IX_Grades_AnimalId");

            entity.HasIndex(e => e.ClubId, "IX_Grades_ClubId");

            entity.Property(e => e.TheGrade).HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.AdditionalInfo).WithMany(p => p.Grades).HasForeignKey(d => d.AdditionalInfoId);

            entity.HasOne(d => d.Animal).WithMany(p => p.Grades).HasForeignKey(d => d.AnimalId);

            entity.HasOne(d => d.Club).WithMany(p => p.Grades).HasForeignKey(d => d.ClubId);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasMany(d => d.Drawbacks).WithMany(p => p.Jobs)
                .UsingEntity<Dictionary<string, object>>(
                    "JobDrawback",
                    r => r.HasOne<Drawback>().WithMany()
                        .HasForeignKey("DrawbackId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Job>().WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("JobId", "DrawbackId");
                        j.ToTable("JobDrawbacks");
                        j.HasIndex(new[] { "DrawbackId" }, "IX_JobDrawbacks_DrawbackId");
                    });
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => new { e.ClubId, e.Id });

            entity.ToTable("Location");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Club).WithMany(p => p.Locations).HasForeignKey(d => d.ClubId);
        });

        modelBuilder.Entity<MapToQuery>(entity =>
        {
            entity.ToTable("MapToQuery");

            entity.HasIndex(e => e.ClubId, "IX_MapToQuery_ClubId");

            entity.HasOne(d => d.Club).WithMany(p => p.MapToQueries).HasForeignKey(d => d.ClubId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.CategoryId, "IX_Product_CategoryId");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
