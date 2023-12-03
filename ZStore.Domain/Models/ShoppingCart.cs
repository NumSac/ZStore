using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Domain.Common;

namespace ZStore.Domain.Models
{
    public class ShoppingCart : BaseEntity
    {
        public List<string> ProductIds { get; set; } = new List<string>();
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        [NotMapped]
        public double Price { get; set; }
    }
}
