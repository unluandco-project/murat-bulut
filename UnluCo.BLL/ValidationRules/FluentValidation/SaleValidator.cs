using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;

namespace UnluCo.BLL.ValidationRules.FluentValidation
{
    class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(x=>x.ProductId).NotEmpty();

            RuleFor(x=>x.UserId).NotEmpty();

            RuleFor(x=>x.TotalPrice).NotEmpty();
            RuleFor(x=>x.TotalPrice).GreaterThan(0);
        }
    }
}
