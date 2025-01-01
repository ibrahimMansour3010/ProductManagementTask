using FluentValidation;
using ProductManagementTask.Applications.Product.Commands.UpdateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Applications.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(c => c.Price).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(c => c.Name).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(c => c.Description).NotNull().NotEmpty().MaximumLength(500);
        }
    }
}
