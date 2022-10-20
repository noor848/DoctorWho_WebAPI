using EfDoctorWho;
using FluentValidation;

namespace DoctorWho.validation
{
    public class EpisodValidator : AbstractValidator<Episod>
    {
        public EpisodValidator()
        {
            RuleFor(episod => episod.Author).NotNull();
            RuleFor(episod => episod.Doctor).NotNull();
            RuleFor(episod => episod.SeriesNumber).Length(10).WithMessage("should be 10 long");
            RuleFor(episod => episod.EpisodNumber).GreaterThan(0).WithMessage("greater than 0");
        }
    }
}
