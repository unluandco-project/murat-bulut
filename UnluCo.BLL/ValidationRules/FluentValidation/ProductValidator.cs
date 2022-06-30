using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;

namespace UnluCo.BLL.ValidationRules.FluentValidation
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();

            RuleFor(x => x.CategoryId).NotEmpty();

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(100);

            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Description).MaximumLength(500);

            RuleFor(x => x.UsingStatus).NotEmpty();


            RuleFor(x => x.ImageFile).NotEmpty();
            RuleFor(x => x.ImageFile).SetValidator(new ImageFileValidator());

            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);


        }
    }
}
