using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using ZStore.Domain.Common;
using ZStore.Domain.Models;
using ZStore.Infrastructure;

namespace ZStore.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AccountBaseEntity>, IApplicationDbContext
    {
        public DbSet<Domain.Common.AccountBaseEntity> Accounts => Set<AccountBaseEntity>();
        public DbSet<AccountBaseEntity> Companies => Set<AccountBaseEntity>();
        public DbSet<CompanyProfile> CompanyProfiles => Set<CompanyProfile>();
        public DbSet<AccountBaseEntity> ApplicationUsers => Set<AccountBaseEntity>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<ProductDetail> ProductDetails => Set<ProductDetail>();
        public DbSet<ProductImage> ProductImages => Set<ProductImage>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
        public DbSet<OrderHeader> OrderHeaders => Set<OrderHeader>();
        public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();
        public DbSet<ShoppingCartItem> ShoppingCartItems => Set<ShoppingCartItem>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            base.OnConfiguring(optionsBuilder);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }
    }
}
