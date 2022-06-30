using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCo.BLL.ValidationRules.FluentValidation
{
    public class ImageFileValidator : AbstractValidator<IFormFile>
    {
        public ImageFileValidator()
        {
            RuleFor(x => x.Length).NotNull().LessThanOrEqualTo(400*1024)
                .WithMessage("Maksimum dosya boyutu 400kb");

            RuleFor(x => x.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("Dosya jpeg/jpg/png formatında olmalıdır.");
        }
    }
}
