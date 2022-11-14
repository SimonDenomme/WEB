using System.Collections.Generic;
using MiniStore.Domain;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace MiniStore.Data
{
    public static class SeedExtensions
    {
        private static readonly PasswordHasher<ApplicationUser> PASSWORD_HASHER = new();
        public static void Seed(this ModelBuilder builder)
        {
            builder.SeedAdmin();
            builder.SeedClient();

            builder.SeedCategories();
            builder.SeedSizes();
            builder.SeedStatus();
            builder.SeedMinis();
            builder.SeedMessages();
        }

        private static ApplicationUser CreateUser(string email, string password, string firstName, string lastName)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                FirstName = firstName,
                LastName = lastName
                
            };
            user.PasswordHash = PASSWORD_HASHER.HashPassword(user, password);

            return user;
        }

        private static void SeedUsers(this ModelBuilder builder, IEnumerable<ApplicationUser> users)
        {
            foreach (var user in users)
            {
                builder.Entity<ApplicationUser>().HasData(user);
            }
        }

        private static void SeedUsersToRole(this ModelBuilder builder, IEnumerable<ApplicationUser> users, IdentityRole role)
        {
            builder.Entity<IdentityRole>().HasData(role);

            foreach (var user in users)
            {
                builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = role.Id
                });
            }
        }

        private static void SeedAdmin(this ModelBuilder builder)
        {
            var admins = new List<ApplicationUser>() {
                CreateUser("admin@test.ca", "Qwerty123!", "Admin","Test"),
                CreateUser("edmon@narnia.na", "Qwerty123!","Edmon","Narnia"),
            };

            builder.SeedUsers(admins);
            builder.SeedUsersToRole(admins, new IdentityRole("Admin"));
        }
        private static void SeedClient(this ModelBuilder builder)
        {
            var clients = new List<ApplicationUser>() {
                CreateUser("client@test.ca",  "Qwerty123!","Client1","Test1"),
                CreateUser("client2@test.ca", "Qwerty123!","Client2","Test2"),
                CreateUser("client3@test.ca", "Qwerty123!","Client3","Test3"),
            };

            builder.SeedUsers(clients);
            builder.SeedUsersToRole(clients, new IdentityRole("Client"));
        }

        private static void SeedCategories(this ModelBuilder builder)
        {
            string[] NameArray = { "Dungeons & Dragons", "PathFinder", "GloomHeaven", "Cyberpunk Red", "Gamma World" };
            for (int i = 1; i <= 5; i++)
                builder.Entity<Category>().HasData(new Category
                {
                    Id = i,
                    Name = NameArray[i - 1],
                    Minis = new List<Mini>()
                });
        }
        private static void SeedMinis(this ModelBuilder builder)
        {
            for (int i = 1; i <= 32; i++)
                builder.Entity<Mini>().HasData(new Mini
                {
                    Id = Guid.NewGuid(),
                    Name = $"Mini {i}",
                    Description = $"This is a description of Mini {i}",
                    ImagePath = "Creature" + i + ".png",
                    IsPainted = true,
                    IsLuminous = i % 2 == 0,
                    QtyInventory = 5 * i,
                    NormalPrice = i * 20,
                    ReducedPrice = i * 10,
                    IsFrontPage = false,
                    QtySold = i * 2,
                    CategoryId = i % 5 + 1,
                    SizeId = i % 6 + 1,
                    StatusId = 1, // test
                });
        }
        private static void SeedMessages(this ModelBuilder builder)
        {
            builder.Entity<Message>().HasData(new Message
            {
                Id = Guid.NewGuid(),
                Name = "bob",
                Email = "bob@gmail.com",
                Text = "allo je mappel bob."
            });

        }
        private static void SeedSizes(this ModelBuilder builder)
        {
            string[] TitleArray = { "Tiny", "Small", "Medium", "Large", "Huge", "Gargantuan" };
            for (int i = 1; i < 7; i++)
                builder.Entity<Size>().HasData(new Size
                {
                    Id = i,
                    Title = TitleArray[i - 1]
                });
        }
        private static void SeedStatus(this ModelBuilder builder)
        {
            string[] StatusArray = { "En inventaire", "Précommande", "Indisponible", "En rupture de stock" };
            for (int i = 1; i < 5; i++)
                builder.Entity<Status>().HasData(new Status
                {
                    Id = i,
                    Title = StatusArray[i - 1]
                });
        }
    }
}
