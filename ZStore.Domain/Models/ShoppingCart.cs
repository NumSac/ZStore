using System.ComponentModel.DataAnnotations.Schema;
using ZStore.Domain.Common;

namespace ZStore.Domain.Models
{
    public class ShoppingCart : BaseEntity
    {
        [NotMapped]
        public ICollection<int> ProductIds { get; set; } 
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        [NotMapped]
        public double Price { get; set; }
    }
}
