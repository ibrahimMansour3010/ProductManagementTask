using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Applications.Product.Queries.Dtos
{
    public class ProductListOutput
    {
        public int AllItemCount { get; set; }
        public IList<ProductItemListDto> Result { get; set; }
    }
}
