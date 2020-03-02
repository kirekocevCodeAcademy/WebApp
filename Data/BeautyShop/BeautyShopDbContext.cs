using Core.BeautyShop;
using Microsoft.EntityFrameworkCore;

namespace DomainData.BeautyShop
{
    public class BeautyShopDbContext : DbContext
    {
        public BeautyShopDbContext(DbContextOptions<BeautyShopDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<ShopItem> ShopItem { get; set; }
    }
}
