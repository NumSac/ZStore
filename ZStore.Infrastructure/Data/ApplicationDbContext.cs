using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZStore.Domain.Common;
using ZStore.Domain.Models;

namespace ZStore.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AccountBaseEntity>
    {
        public DbSet<Domain.Common.AccountBaseEntity> Accounts => Set<AccountBaseEntity>();
        public DbSet<AccountBaseEntity> Companies => Set<AccountBaseEntity>();
        public DbSet<CompanyProfile> CompanyProfiles => Set<CompanyProfile>();
        public DbSet<AccountBaseEntity> ApplicationUsers => Set<AccountBaseEntity>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<ProductDetail> ProductDetails => Set<ProductDetail>();
        public DbSet<ProductImage> ProductImages => Set<ProductImage>();
        public DbSet<Product> Products => Set<Product>();
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
