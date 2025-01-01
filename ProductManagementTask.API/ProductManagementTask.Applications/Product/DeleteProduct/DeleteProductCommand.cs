using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Applications.Product.DeleteProduct
{
    public class DeleteProductCommand:IRequest<Dtos.DeleteProductOutput>
    {
        public long Id { get; set; }
    }
}
