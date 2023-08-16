using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZStore.Domain.Models;

namespace ZStore.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<CompanyProfile> CompanyProfiles => Set<CompanyProfile>();
        public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<ProductDetail> ProductDetails => Set<ProductDetail>();
        public DbSet<ProductImage> ProductImages => Set<ProductImage>();
        public DbSet<Product> Products => Set<Product>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }
    }
}
