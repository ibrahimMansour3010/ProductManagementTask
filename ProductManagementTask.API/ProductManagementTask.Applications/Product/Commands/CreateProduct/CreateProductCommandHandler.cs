using MediatR;
using ProductManagementTask.Applications.Common.Interfaces;
using ProductManagementTask.Applications.Product.Commands.CreateProduct.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Applications.Product.Commands.CreateProduct
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductOutput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepo<ProductManagementTask.Domain.Entities.Product, long> _productRepo;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productRepo = _unitOfWork.Repository<ProductManagementTask.Domain.Entities.Product, long>();
        }
        public async Task<CreateProductOutput> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = await _productRepo.InsertAsync(new Domain.Entities.Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
            });
            await _unitOfWork.CompleteAsync();
            return new CreateProductOutput() { ProductId = productEntity.Id };
        }

    }
}
