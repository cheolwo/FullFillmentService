using FluentValidation;
using 창고Common.DTO.출고상품;

namespace 창고Common.Actor.Validator
{
    public class Create출고상품Validator : AbstractValidator<Create출고상품DTO>
    {
        public Create출고상품Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("출고상품 name must be between 1 and 100 characters.");
        }
    }

    public class Update출고상품Validator : AbstractValidator<Update출고상품DTO>
    {
        public Update출고상품Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("출고상품 name must be between 1 and 100 characters.");
        }
    }

    public class Delete출고상품Validator : AbstractValidator<Delete출고상품DTO>
    {
        public Delete출고상품Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
