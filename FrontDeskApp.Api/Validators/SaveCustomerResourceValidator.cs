using FluentValidation;
using FrontDeskApp.Api.Resources;

namespace FrontDeskApp.Api.Validators
{
    public class SaveCustomerResourceValidator : AbstractValidator<SaveCustomerResource>
    {
        public SaveCustomerResourceValidator()
        {
            RuleFor(a => a.CustomerFirstName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(a => a.CustomerLastName)
               .NotEmpty()
               .MaximumLength(100);

            RuleFor(a => a.CustomerPhoneNumer)
             .NotEmpty()
             .MaximumLength(100);
        }
    }
}
