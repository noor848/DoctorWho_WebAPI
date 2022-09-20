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
            RuleFor(doctor => doctor.FirstEpisodDate.ToString("MM-dd-yyyy")).Empty().When(s => s.LastEpisodDate.ToString("MM-dd-yyyy").Equals("")).WithMessage("should be Empty Both");
            RuleFor(doctor => doctor.LastEpisodDate.ToString("MM-dd-yyyy")).GreaterThanOrEqualTo(s=>s.FirstEpisodDate.ToString("MM-dd-yyyy"));

        }

        private bool CheckName(string name)
        {
            return name.All(char.IsLetterOrDigit);
        }
    }
}
