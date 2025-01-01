using MediatR;
using ProductManagementTask.Applications.Product.Commands.UpdateProduct.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Applications.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand:IRequest<UpdateProductOutput>
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
