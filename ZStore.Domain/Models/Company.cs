using System.ComponentModel.DataAnnotations;
using ZStore.Domain.Common;

namespace ZStore.Domain.Models
{
    public class Company : AuditableBaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string CompanyEmail { get; set; } = string.Empty;
        [Required]
        public string StreetAddress { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string State { get; set; } = string.Empty;
        [Required]
        public string PostalCode { get; set; } = string.Empty;
        [Required] 
        public string Country { get; set; } = string.Empty;
        [Required]
        public string VatNumber { get; set; } = string.Empty;
        public CompanyProfile? Profile { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
