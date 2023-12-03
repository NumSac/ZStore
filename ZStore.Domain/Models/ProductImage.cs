using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZStore.Domain.Common;

namespace ZStore.Domain.Models
{
    public class ProductImage : BaseEntity
    {
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
    }
}
