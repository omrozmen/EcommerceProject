using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductImageValidator : AbstractValidator<ProductImage>
    {
        public ProductImageValidator()
        {
            RuleFor(i => i.ProductId).NotEmpty();
        }
    }
}
