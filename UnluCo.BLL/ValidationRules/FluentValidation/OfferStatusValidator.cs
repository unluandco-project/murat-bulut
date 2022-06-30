using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;

namespace UnluCo.BLL.ValidationRules.FluentValidation
{
    public class OfferStatusValidator:AbstractValidator<OfferStatus>
    {
        public OfferStatusValidator()
        {
            RuleFor(x=>x.Title).NotEmpty();
        }
    }
}
