﻿// <auto-generated />
using System;
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

            modelBuilder.Entity("MiniStore.Entity.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Message");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "bob@gmail.com",
                            Name = "bob",
                            Text = "allo je mappel bob."
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

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFrontPage")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLuminous")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPainted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NormalPrice")
                        .HasColumnType("float");

                    b.Property<int>("QtyInventory")
                        .HasColumnType("int");

                    b.Property<int>("QtySold")
                        .HasColumnType("int");

                    b.Property<double>("ReducedPrice")
                        .HasColumnType("float");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SizeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Minis");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "This is a description",
                            ImagePath = "Creature1.png",
                            IsFrontPage = false,
                            IsLuminous = false,
                            IsPainted = true,
                            Name = "Mini 1",
                            NormalPrice = 20.0,
                            QtyInventory = 5,
                            QtySold = 2,
                            ReducedPrice = 10.0,
                            SizeId = 1,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "This is a description",
                            ImagePath = "Creature2.png",
                            IsFrontPage = false,
                            IsLuminous = true,
                            IsPainted = true,
                            Name = "Mini 2",
                            NormalPrice = 40.0,
                            QtyInventory = 10,
                            QtySold = 4,
                            ReducedPrice = 20.0,
                            SizeId = 1,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "This is a description",
                            ImagePath = "Creature3.png",
                            IsFrontPage = false,
                            IsLuminous = false,
                            IsPainted = true,
                            Name = "Mini 3",
                            NormalPrice = 60.0,
                            QtyInventory = 15,
                            QtySold = 6,
                            ReducedPrice = 30.0,
                            SizeId = 1,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Description = "This is a description",
                            ImagePath = "Creature4.png",
                            IsFrontPage = false,
                            IsLuminous = true,
                            IsPainted = true,
                            Name = "Mini 4",
                            NormalPrice = 80.0,
                            QtyInventory = 20,
                            QtySold = 8,
                            ReducedPrice = 40.0,
                            SizeId = 1,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            Description = "This is a description",
                            ImagePath = "Creature5.png",
                            IsFrontPage = false,
                            IsLuminous = false,
                            IsPainted = true,
                            Name = "Mini 5",
                            NormalPrice = 100.0,
                            QtyInventory = 25,
                            QtySold = 10,
                            ReducedPrice = 50.0,
                            SizeId = 1,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 6,
                            Description = "This is a description",
                            ImagePath = "Creature6.png",
                            IsFrontPage = false,
                            IsLuminous = true,
                            IsPainted = true,
                            Name = "Mini 6",
                            NormalPrice = 120.0,
                            QtyInventory = 30,
                            QtySold = 12,
                            ReducedPrice = 60.0,
                            SizeId = 1,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 7,
                            Description = "This is a description",
                            ImagePath = "Creature7.png",
                            IsFrontPage = false,
                            IsLuminous = false,
                            IsPainted = true,
                            Name = "Mini 7",
                            NormalPrice = 140.0,
                            QtyInventory = 35,
                            QtySold = 14,
                            ReducedPrice = 70.0,
                            SizeId = 1,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 8,
                            Description = "This is a description",
                            ImagePath = "Creature8.png",
                            IsFrontPage = false,
                            IsLuminous = true,
                            IsPainted = true,
                            Name = "Mini 8",
                            NormalPrice = 160.0,
                            QtyInventory = 40,
                            QtySold = 16,
                            ReducedPrice = 80.0,
                            SizeId = 1,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 9,
                            Description = "This is a description",
                            ImagePath = "Creature9.png",
                            IsFrontPage = false,
                            IsLuminous = false,
                            IsPainted = true,
                            Name = "Mini 9",
                            NormalPrice = 180.0,
                            QtyInventory = 45,
                            QtySold = 18,
                            ReducedPrice = 90.0,
                            SizeId = 1,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 10,
                            Description = "This is a description",
                            ImagePath = "Creature10.png",
                            IsFrontPage = false,
                            IsLuminous = true,
                            IsPainted = true,
                            Name = "Mini 10",
                            NormalPrice = 200.0,
                            QtyInventory = 50,
                            QtySold = 20,
                            ReducedPrice = 100.0,
                            SizeId = 1,
                            StatusId = 2
                        });
                });

            modelBuilder.Entity("MiniStore.Entity.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MiniId")
                        .HasColumnType("int");

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MiniId");

                    b.ToTable("Review");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MiniId = 1,
                            Rating = (byte)5,
                            Text = "Good",
                            UserName = "Review 1"
                        });
                });

            modelBuilder.Entity("MiniStore.Entity.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Size");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "S"
                        },
                        new
                        {
                            Id = 2,
                            Title = "M"
                        },
                        new
                        {
                            Id = 3,
                            Title = "L"
                        });
                });

            modelBuilder.Entity("MiniStore.Entity.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Status 1"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Status 2"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Status 3"
                        });
                });

            modelBuilder.Entity("MiniStore.Models.Minis", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MiniId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NormalPrice")
                        .HasColumnType("float");

                    b.Property<double>("ReducedPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MiniId");

                    b.ToTable("MinisModel");
                });

            modelBuilder.Entity("MiniStore.Entity.Mini", b =>
                {
                    b.HasOne("MiniStore.Entity.Category", "Category")
                        .WithMany("Minis")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniStore.Entity.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniStore.Entity.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Size");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MiniStore.Entity.Review", b =>
                {
                    b.HasOne("MiniStore.Entity.Mini", "Mini")
                        .WithMany("Reviews")
                        .HasForeignKey("MiniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mini");
                });

            modelBuilder.Entity("MiniStore.Models.Minis", b =>
                {
                    b.HasOne("MiniStore.Entity.Mini", "Mini")
                        .WithMany()
                        .HasForeignKey("MiniId");

                    b.Navigation("Mini");
                });

            modelBuilder.Entity("MiniStore.Entity.Category", b =>
                {
                    b.Navigation("Minis");
                });

            modelBuilder.Entity("MiniStore.Entity.Mini", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
