using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Domain.Common;
using ZStore.Domain.Models;

namespace ZStore.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<AccountBaseEntity> Accounts { get; }
        DbSet<AccountBaseEntity> Companies { get; }
        DbSet<CompanyProfile> CompanyProfiles { get; }
        DbSet<AccountBaseEntity> ApplicationUsers { get; }
        DbSet<Category> Categories { get; }
        DbSet<ProductDetail> ProductDetails { get; }
        DbSet<ProductImage> ProductImages { get; }
        DbSet<Product> Products { get; }
        DbSet<OrderDetail> OrderDetails { get; }
        DbSet<OrderHeader> OrderHeaders { get; }
        DbSet<ShoppingCart> ShoppingCarts { get; }
    }
}
