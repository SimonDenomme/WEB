using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniStore.Domain;

namespace MiniStore.Data
{
    public class MiniStoreContext : IdentityDbContext<ApplicationUser>
    {
        public MiniStoreContext(DbContextOptions<MiniStoreContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Mini> Minis { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ItemInCart> ItemInCarts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
        public DbSet<MiniStore.ViewModels.Adresse.AdresseViewModel> AdresseViewModel { get; set; }
    }
}
