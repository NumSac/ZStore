using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        [ValidateNever]
        public ProductDetail? ProductDetail { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        // Navigation property for the owning Company
        public string CompanyId { get; set; }  // This should match the type of the Company's primary key
        // Navigation property for the owning Company
        [ForeignKey("CompanyId")]
        [ValidateNever]
        public AccountBaseEntity Company { get; set; }

        [ValidateNever]
        public List<ProductImage>? ProductImages { get; set; }
    }
}
