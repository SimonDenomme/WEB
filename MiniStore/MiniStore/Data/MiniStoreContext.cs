using Microsoft.EntityFrameworkCore;
using MiniStore.Entity;

namespace MiniStore.Data
{
    public class MiniStoreContext : DbContext
    {
        public MiniStoreContext(DbContextOptions<MiniStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Mini> Minis { get; set; }
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

            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<Mini>().HasData(new Mini
                {
                    Id = i,
                    Name = $"Mini {i}",
                    Description = "This is a description",
                    Cost = i * 10,
                    Price = i * 20,
                    Discount = i * 2,
                    IsColored = i % 2 == 0,
                    ImagePath = "Creature" + i + ".png",
                    CategoryId = i,
                }) ;
            }

            modelBuilder.Entity<Review>().HasData(new Review
            {
                Id = 1,
                UserName = "Review 1",
                Text = "Good",
                Rating = 5,
                MiniId = 1
            });
        }
    }
}
