using EfDoctorWho;
using FluentValidation;

namespace DoctorWho.validation
{
    public class EnemyValidatior: AbstractValidator<Enemy>
    {
        public EnemyValidatior()
        {
            RuleFor(enemy=>enemy.EnemyName).MaximumLength(10).Must(CheckName);
            RuleFor(enemy=>enemy.Id).NotNull();
            RuleFor(enemy=>enemy.Description).MaximumLength(100);
        }

        private bool CheckName(string name)
        {
            return name.All(char.IsLetterOrDigit);
        }
    }

    }
