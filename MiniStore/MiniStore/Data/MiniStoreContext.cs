using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniStore.Domain;
using MiniStore.Entity;
using MiniStore.Models;

namespace MiniStore.Data
{
    public class MiniStoreContext : IdentityDbContext<ApplicationUser>
    {
        public MiniStoreContext(DbContextOptions<MiniStoreContext> options) : base(options) { }

        public DbSet<Mini> Minis { get; set; }
        //public DbSet<Minis> MinisModel { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();

            string[] NameArray = { "Dungeons & Dragons", "PathFinder", "GloomHeaven", "Cyberpunk Red", "Gamma World" };
            for (int i = 1; i <= 5; i++)
                modelBuilder.Entity<Category>().HasData(new Category
                {
                    Id = i,
                    Name = NameArray[i-1],
                    Minis = new System.Collections.Generic.List<Mini>()
                });

            for (int i = 1; i <= 32; i++)
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
                    CategoryId = i % 12 + 1,
                    SizeId = 1, // test
                    StatusId = 2, // test
                });

            modelBuilder.Entity<Review>().HasData(new Review
            {
                Id = 1,
                UserName = "Review 1",
                Text = "Good",
                Rating = 5,
                MiniId = 1
            });

            string[] TitleArray = { "Tiny", "Small", "Medium", "Large", "Huge", "Gargantuan" };
            for (int i = 1; i < 7; i++)
                modelBuilder.Entity<Size>().HasData(new Size
                {
                    Id = i,
                    Title = TitleArray[i - 1]
                });


            string[] StatusArray = { "En inventaire", "Bientôt", "Indisponible", "En rupture de stock" };
            for (int i = 1; i < 5; i++)
                modelBuilder.Entity<Status>().HasData(new Status
                {
                    Id = i,
                    Title = StatusArray[i - 1]
                });

            modelBuilder.Entity<Message>().HasData(new Message
            {
                Id = 1,
                Name = "bob",
                Email = "bob@gmail.com",
                Text = "allo je mappel bob."
            });

        }

        public DbSet<MiniStore.Models.Minis> Minis_1 { get; set; }
    }
}
