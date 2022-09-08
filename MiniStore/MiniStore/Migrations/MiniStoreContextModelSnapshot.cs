﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniStore.Data;

namespace MiniStore.Migrations
{
    [DbContext(typeof(MiniStoreContext))]
    partial class MiniStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MiniStore.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Category 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Category 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Category 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Category 4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Category 5"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Category 6"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Category 7"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Category 8"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Category 9"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Category 10"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Category 11"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Category 12"
                        });
                });

            modelBuilder.Entity("MiniStore.Entity.Mini", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Minis");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Cost = 10m,
                            Discount = 2m,
                            Name = "Mini 1"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Cost = 20m,
                            Discount = 4m,
                            Name = "Mini 2"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Cost = 30m,
                            Discount = 6m,
                            Name = "Mini 3"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Cost = 40m,
                            Discount = 8m,
                            Name = "Mini 4"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            Cost = 50m,
                            Discount = 10m,
                            Name = "Mini 5"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 6,
                            Cost = 60m,
                            Discount = 12m,
                            Name = "Mini 6"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 7,
                            Cost = 70m,
                            Discount = 14m,
                            Name = "Mini 7"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 8,
                            Cost = 80m,
                            Discount = 16m,
                            Name = "Mini 8"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 9,
                            Cost = 90m,
                            Discount = 18m,
                            Name = "Mini 9"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 10,
                            Cost = 100m,
                            Discount = 20m,
                            Name = "Mini 10"
                        });
                });

            modelBuilder.Entity("MiniStore.Entity.Mini", b =>
                {
                    b.HasOne("MiniStore.Entity.Category", null)
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniStore.Entity.Category", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
