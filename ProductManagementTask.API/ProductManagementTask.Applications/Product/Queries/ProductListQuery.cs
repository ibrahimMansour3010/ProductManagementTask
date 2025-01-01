using MediatR;
using ProductManagementTask.Applications.Common.Dtos;
using ProductManagementTask.Applications.Product.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Applications.Product.Queries
{
    public class ProductListQuery : BasePagenationDto, IRequest<ProductListOutput>
    {
    }
}
