using EfDoctorWho;
using FluentValidation;
using System.Linq;

namespace DoctorWho.validation
{
    public class DoctorValidator: AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(doctor => doctor.DoctorName).NotEmpty().NotNull();
            RuleFor(doctor => doctor.DoctorNumber).NotEmpty().NotNull();
            RuleFor(doctor => doctor.FirstEpisodDate.Date).Empty().When(s => s.LastEpisodDate.Date.Equals("")).WithMessage("should be Empty Both");
            RuleFor(doctor => doctor.LastEpisodDate.Date).GreaterThanOrEqualTo(s=>s.FirstEpisodDate.Date);

        }
    }
}
