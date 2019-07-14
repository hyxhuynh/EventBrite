﻿// <auto-generated />
using System;
using EventCatalogAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventCatalogAPI.Migrations
{
    [DbContext(typeof(CatalogContext))]
    [Migration("20190714225152_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.catalog_category_hilo", "'catalog_category_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.catalog_event_city_hilo", "'catalog_event_city_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.catalog_event_zipcode_hilo", "'catalog_event_zipcode_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.catalog_hilo", "'catalog_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.catalog_type_hilo", "'catalog_type_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventCatalogAPI.Domain.CatalogCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "catalog_category_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("CatalogCategories");
                });

            modelBuilder.Entity("EventCatalogAPI.Domain.CatalogEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "catalog_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Address1")
                        .IsRequired();

                    b.Property<string>("Address2");

                    b.Property<int>("CatalogCategoryId");

                    b.Property<int>("CatalogEventCityId");

                    b.Property<int>("CatalogEventZipcodeId");

                    b.Property<int>("CatalogTypeId");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EventDateTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PictureUrl");

                    b.Property<decimal>("Price");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Zipcode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CatalogCategoryId");

                    b.HasIndex("CatalogEventCityId");

                    b.HasIndex("CatalogEventZipcodeId");

                    b.HasIndex("CatalogTypeId");

                    b.ToTable("Catalog");
                });

            modelBuilder.Entity("EventCatalogAPI.Domain.CatalogEventCity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "catalog_event_city_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("CatalogEventCities");
                });

            modelBuilder.Entity("EventCatalogAPI.Domain.CatalogEventZipcode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "catalog_event_zipcode_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.ToTable("CatalogEventZipcodes");
                });

            modelBuilder.Entity("EventCatalogAPI.Domain.CatalogType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "catalog_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("CatalogTypes");
                });

            modelBuilder.Entity("EventCatalogAPI.Domain.CatalogEvent", b =>
                {
                    b.HasOne("EventCatalogAPI.Domain.CatalogCategory", "CatalogCategory")
                        .WithMany()
                        .HasForeignKey("CatalogCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventCatalogAPI.Domain.CatalogEventCity", "CatalogEventCity")
                        .WithMany()
                        .HasForeignKey("CatalogEventCityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventCatalogAPI.Domain.CatalogEventZipcode", "CatalogEventZipcode")
                        .WithMany()
                        .HasForeignKey("CatalogEventZipcodeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventCatalogAPI.Domain.CatalogType", "CatalogType")
                        .WithMany()
                        .HasForeignKey("CatalogTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
