using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Domain.Models;

namespace ZStore.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public ProductDetail ProductDetail { get; set; } = new ProductDetail();
        //public ICollection<string> ImageUrls { get; set; } = new List<string>();
    }
}
