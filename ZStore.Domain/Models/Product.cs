using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZStore.Domain.Common;

namespace ZStore.Domain.Models
{
    public class Product : AuditableBaseEntity
    {

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000)]
        public double Price { get; set; }

        public ProductDetail ProductDetail { get; set; } = null!;

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;

        public List<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

        // Navigation property for the owning Company
        public string? CompanyId { get; set; }  // This should match the type of the Company's primary key
        [ForeignKey("CompanyId")]
        public AccountBaseEntity Company { get; set; } = null!;
    }
}
