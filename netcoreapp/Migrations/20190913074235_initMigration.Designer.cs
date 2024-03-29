﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using netcoreapp.Models;

namespace netcoreapp.Migrations
{
    [DbContext(typeof(CoreFisContext))]
    [Migration("20190913074235_initMigration")]
    partial class initMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("netcoreapp.Models.Category", b =>
                {
                    b.Property<int>("CategoryRowId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BasePrice");

                    b.Property<string>("CategoryId")
                        .IsRequired();

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.HasKey("CategoryRowId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("netcoreapp.Models.Product", b =>
                {
                    b.Property<int>("ProductRowId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryRowId");

                    b.Property<string>("Manufacturer");

                    b.Property<int>("Price");

                    b.Property<string>("ProductId");

                    b.Property<string>("ProductName");

                    b.HasKey("ProductRowId");

                    b.HasIndex("CategoryRowId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("netcoreapp.Models.Product", b =>
                {
                    b.HasOne("netcoreapp.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryRowId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
