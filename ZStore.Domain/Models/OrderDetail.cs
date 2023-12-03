using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZStore.Domain.Common;

namespace ZStore.Domain.Models
{
    public class OrderDetail : BaseEntity
    {
        [Required]
        public int OrderHeaderId { get; set; }
        [ForeignKey(nameof(OrderHeaderId))]
        public OrderHeader OrderHeader { get; set; }
        [NotMapped]
        public List<string> ProductIds { get; set; } = new List<string>();
        public double Price { get; set; }
    }
}
