using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;

namespace UnluCo.BLL.ValidationRules.FluentValidation
{
    public class OfferValidator : AbstractValidator<Offer>
    {
        public OfferValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();

            RuleFor(x => x.UserId).NotEmpty();

            RuleFor(x => x.OfferPercentage).NotEmpty();
            RuleFor(x => x.OfferPercentage).GreaterThan(0);
        }
    }
}
