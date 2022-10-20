using EfDoctorWho;
using FluentValidation;

namespace DoctorWho.validation
{
    public class CompanionValidatorAbstractValidator : AbstractValidator<Companion>
    {
        public CompanionValidatorAbstractValidator()
        {

            RuleFor(companion => companion.ComapnionName).MaximumLength(10).Must(CheckName);
            RuleFor(companion => companion.WhoPlayed).MaximumLength(10).Must(CheckName).NotEmpty();          
        }

        private bool CheckName(string name)
        {
            return name.All(char.IsLetterOrDigit);
        }

    }
}
