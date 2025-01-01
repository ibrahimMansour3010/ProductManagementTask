using MediatR;
using ProductManagementTask.Applications.Common.Exceptions;
using ProductManagementTask.Applications.Common.Interfaces;
using ProductManagementTask.Applications.Product.DeleteProduct.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Applications.Product.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductOutput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepo<ProductManagementTask.Domain.Entities.Product, long> _prodcutRepo;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _prodcutRepo = _unitOfWork.Repository<ProductManagementTask.Domain.Entities.Product, long>();
        }
        public async Task<DeleteProductOutput> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _prodcutRepo.GetOneAsyncNoTrack(c => c.Id == request.Id);
            if (product == null)
                throw new BusinessException("Item Not Founded");
            product.IsDeleted = true;
            _prodcutRepo.Update(product);
            await _unitOfWork.CompleteAsync();
            return new DeleteProductOutput() { ProductId = product.Id };
        }
    }
}
