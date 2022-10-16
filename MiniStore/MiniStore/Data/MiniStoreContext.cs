﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniStore.Domain;
using MiniStore.Entity;
using MiniStore.Models;

namespace MiniStore.Data
{
    public class MiniStoreContext : IdentityDbContext<ApplicationUser>
    {
        public MiniStoreContext(DbContextOptions<MiniStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Mini> Minis { get; set; }
        //public DbSet<Minis> MinisModel { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            for (int i = 1; i <= 12; i++)
            {
                modelBuilder.Entity<Category>().HasData(new Category
                {
                    Id = i,
                    Name = $"Category {i}",
                    Minis = new System.Collections.Generic.List<Mini>()
                });
            }
            modelBuilder.Seed();
            for (int i = 1; i <= 32; i++)
            {
                modelBuilder.Entity<Mini>().HasData(new Mini
                {
                    Id = i,
                    Name = $"Mini {i}",
                    Description = "This is a description",
                    ImagePath = "Creature" + i + ".png",
                    IsPainted = true,
                    IsLuminous = i % 2 == 0,
                    QtyInventory = 5 * i,
                    NormalPrice = i * 20,
                    ReducedPrice = i * 10,
                    IsFrontPage = false,
                    QtySold = i * 2,
                    CategoryId = i%12+1,
                    SizeId = 1, // test
                    StatusId = 2, // test
                });
                //modelBuilder.Entity<Minis>().HasData(new Minis
                //{
                //    Id = i,
                //    Name = $"Mini {i}",
                //    ImagePath = "Creature" + i + ".png",
                //    NormalPrice = i * 20,
                //    ReducedPrice = i * 10,
                //});
            }

            modelBuilder.Entity<Review>().HasData(new Review
            {
                Id = 1,
                UserName = "Review 1",
                Text = "Good",
                Rating = 5,
                MiniId = 1
            });

            modelBuilder.Entity<Size>().HasData(new Size
            {
                Id = 1,
                Title = "S"
            });

            modelBuilder.Entity<Size>().HasData(new Size
            {
                Id = 2,
                Title = "M"
            });

            modelBuilder.Entity<Size>().HasData(new Size
            {
                Id = 3,
                Title = "L"
            });

            modelBuilder.Entity<Status>().HasData(new Status
            {
                Id = 1,
                Title = "Tout"
            });
            modelBuilder.Entity<Status>().HasData(new Status
            {
                Id = 2,
                Title = "Disponible"
            });
            modelBuilder.Entity<Status>().HasData(new Status
            {
                Id = 3,
                Title = "Indisponible"
            });
            modelBuilder.Entity<Status>().HasData(new Status
            {
                Id = 4,
                Title = "Rupture de stock"
            });
            modelBuilder.Entity<Message>().HasData(new Message
            {
                Id = 1,
                Name = "bob",
                Email = "bob@gmail.com",
                Text = "allo je mappel bob."
            });

        }
    }
}
