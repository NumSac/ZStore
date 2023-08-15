using ZStore.Domain.Common;

namespace ZStore.Domain.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
