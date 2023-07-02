using Common.DTO;
using FluentValidation;

namespace Common.Actor.Configuration.Validator
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(5, 20).WithMessage("Username must be between 5 and 20 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Length(8, 20).WithMessage("Password must be between 8 and 20 characters.");

            RuleFor(x => x.RememberMe)
                .NotNull().WithMessage("RememberMe is required.");
        }
    }
}
