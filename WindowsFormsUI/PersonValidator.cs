using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsUI
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(p => p.FirstName).MinimumLength(3);
            RuleFor(p => p.LastName).Must(BeValidName).WithMessage("Invalid name.");
            RuleFor(p => p.Amount)
                .GreaterThan(0).WithMessage("Must be positive.")
                .NotEmpty().WithMessage("Could not be null.");
        }

        private bool BeValidName(string name)
        {
            return name.All(Char.IsLetter) & name.Length > 3;
        }
    }
}
