using FluentValidation;
using FluentValidationApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} is Not Null";
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Email must true format");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage("Age must between 18 and 60");

            // Custom validator yazmaq ucun Must metodu ile yazilir.
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage)
                .Must(x =>
                {
                    return DateTime.Now.AddYears(-18) >= x;
                }).WithMessage("Age must bigger than 18");

            //One-many elaqesine gore validation elaqelendirildi.

            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());

            // IsInEnum() metodu
            RuleFor(x => x.Gender).IsInEnum().WithMessage("{PropertyName} must Male:1,Female:2");
        }
    }
}
