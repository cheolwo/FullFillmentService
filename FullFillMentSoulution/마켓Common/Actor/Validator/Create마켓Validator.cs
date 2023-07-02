using Common.DTO;
using FluentValidation;
using 마켓Common.DTO;

namespace 마켓Common.Actor.Validator
{
    public class Create마켓Validator : AbstractValidator<Create마켓DTO>
    {
        public Create마켓Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("마켓 name must be between 1 and 100 characters.");
        }
    }

    public class Update마켓Validator : AbstractValidator<Update마켓DTO>
    {
        public Update마켓Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("마켓 name must be between 1 and 100 characters.");
        }
    }

    public class Delete마켓Validator : AbstractValidator<Delete마켓DTO>
    {
        public Delete마켓Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
