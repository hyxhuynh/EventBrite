using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<CatalogCategory> CatalogCategories { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogEvent> CatalogEvents { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogCategory>(ConfigureCatalogCategory);
            modelBuilder.Entity<CatalogType>(ConfigureCatalogType);
            modelBuilder.Entity<CatalogEvent>(ConfigureCatalogEvent);

        }

        private void ConfigureCatalogEvent(
            EntityTypeBuilder<CatalogEvent> builder)
        {
            builder.ToTable("Catalog");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_hilo");
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Price)
                .IsRequired();
            builder.Property(c => c.Address1)
                .IsRequired();
            builder.Property(c => c.City)
                .IsRequired();
            builder.Property(c => c.State)
                .IsRequired();
            builder.Property(c => c.Zipcode)
                .IsRequired();
            builder.Property(c => c.EventDateTime)
                .IsRequired();


            builder.HasOne(c => c.CatalogType)
                .WithMany()
                .HasForeignKey(c => c.CatalogTypeId);

            builder.HasOne(c => c.CatalogCategory)
                .WithMany()
                .HasForeignKey(c => c.CatalogCategoryId);

        }

        private void ConfigureCatalogType(
            EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogTypes");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_type_hilo");

            builder.Property(c => c.Type)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureCatalogCategory(
            EntityTypeBuilder<CatalogCategory> builder)
        {
            builder.ToTable("CatalogCategories");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_category_hilo");

            builder.Property(c => c.Category)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}

