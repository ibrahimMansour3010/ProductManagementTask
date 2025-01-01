using MediatR;
using ProductManagementTask.Applications.Common.Interfaces;
using ProductManagementTask.Applications.Product.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Applications.Product.Queries
{
    public class ProductListQueryHandler : IRequestHandler<ProductListQuery, ProductListOutput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepo<ProductManagementTask.Domain.Entities.Product, long> _prodcutRepo;

        public ProductListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _prodcutRepo = _unitOfWork.Repository<ProductManagementTask.Domain.Entities.Product, long>();
        }
        public async Task<ProductListOutput> Handle(ProductListQuery request, CancellationToken cancellationToken)
        {

            var products = await _prodcutRepo.GetPaginatedAsync(filter: c => !c.IsDeleted, pageSize: request.PageSize,
                page: request.PageNumber, orderBy: c => c.OrderByDescending(z => z.CreatedAt));
            var output = new ProductListOutput();
            output.AllItemCount = await _prodcutRepo.CountAsync(filter: c => !c.IsDeleted);
            output.Result = products.Select(c => new ProductItemListDto()
            {
                Id = c.Id,
                Description = c.Description,
                Name = c.Name,
                Price = c.Price,
                CreationDate = c.CreatedAt,
            }).ToList();

            return output;
        }
    }
}
