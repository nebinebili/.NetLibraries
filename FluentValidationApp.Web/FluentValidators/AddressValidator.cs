using FluentValidation;
using FluentValidationApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web.FluentValidators
{
    public class AddressValidator:AbstractValidator<Address>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} is not Null";
        public AddressValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.PostCode).NotEmpty().WithMessage(NotEmptyMessage)
                .MaximumLength(5).WithMessage("{PropertyName} must max length {MaxLength} character");
            RuleFor(x => x.Province).NotEmpty().WithMessage(NotEmptyMessage);
        }
    }
}
