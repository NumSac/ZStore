using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Application.Mappings;

namespace ZStore.Application.Api.Product.Queries.GetAllProductsPaged
{
    public class GetAllProductsParameter : RequestParameter, IMapFrom<GetAllProductsQuery>
    {

    }
}
