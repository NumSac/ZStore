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
        public ProductDetail? ProductDetail { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        // Navigation property for the owning Company
        public string OwnerId { get; set; } // Will be ApplicationUserId
        public List<ProductImage>? ProductImages { get; set; }
    }
}
