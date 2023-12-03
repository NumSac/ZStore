using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZStore.Application.Api.Product.Queries
{
    public class GetProductsByCategoryQuery
    {
        public string CategoryName { get; set; } = "";
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
