using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.DAL.Concrete;
using UnluCo.Entities.Concrete;

namespace UnluCo.BLL.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3);

            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Surname).MinimumLength(2);

            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Email).Must(AlreadyEmail).WithMessage("This email already exist.");

            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(8);
            RuleFor(x => x.Password).MaximumLength(20);

        }

        private bool AlreadyEmail(string arg)
        {
            var _db = new UnluCoContext();
            var result = _db.Users.Where(x => x.Email.Equals(arg)).SingleOrDefault();
            if (result == null) return true;

            return false;
        }
    }
}
