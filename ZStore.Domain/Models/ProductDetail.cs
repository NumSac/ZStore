using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Domain.Common;

namespace ZStore.Domain.Models
{
    public class ProductDetail : BaseEntity
    {
        public int SoldItems { get; set; } = 0;
        public int TotalItems { get; set; } 
    }
}
