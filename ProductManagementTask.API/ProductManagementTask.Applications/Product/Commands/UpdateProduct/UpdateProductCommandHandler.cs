using MediatR;
using ProductManagementTask.Applications.Common.Exceptions;
using ProductManagementTask.Applications.Common.Interfaces;
using ProductManagementTask.Applications.Product.Commands.UpdateProduct.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Applications.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductOutput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepo<ProductManagementTask.Domain.Entities.Product, long> _productRepo;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productRepo = _unitOfWork.Repository<ProductManagementTask.Domain.Entities.Product, long>();
        }
        public async Task<UpdateProductOutput> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetOneAsyncNoTrack(c => c.Id == request.Id);
            if (product == null)
                throw new BusinessException("Item Not Founded");
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            _productRepo.Update(product);
            await _unitOfWork.CompleteAsync();
            return new UpdateProductOutput()
            {
                Price = product.Price,
                Description = product.Description,
                Id = product.Id,
                Name = product.Name,
                CreatedAt = product.CreatedAt,
            };
        }
    }
}
