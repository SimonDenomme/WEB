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
                    Items = new System.Collections.Generic.List<Mini>()
                });
            }

            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<Mini>().HasData(new Mini
                {
                    Id = i,
                    Name = $"Mini {i}",
                    CategoryId = i,
                    Cost = i * 10,
                    Discount = i * 2
                });
            }
        }
    }
}
