using FluentValidation;
using 창고Common.DTO.입고상품;
using 창고Common.DTO.창고;

namespace 창고Common.Actor.Validator
{
    public class Create입고상품Validator : AbstractValidator<Create입고상품DTO>
    {
        public Create입고상품Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("입고상품 name must be between 1 and 100 characters.");
        }
    }

    public class Update입고상품Validator : AbstractValidator<Update입고상품DTO>
    {
        public Update입고상품Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("입고상품 name must be between 1 and 100 characters.");
        }
    }

    public class Delete입고상품Validator : AbstractValidator<Delete입고상품DTO>
    {
        public Delete입고상품Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
