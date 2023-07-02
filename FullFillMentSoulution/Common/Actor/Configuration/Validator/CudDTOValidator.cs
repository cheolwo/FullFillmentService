using Common.DTO;
using FluentValidation;

namespace Common.Actor.Configuration.Validator
{
    public class CudDTOValidator : AbstractValidator<CudDTO>
    {
        public CudDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");
        }
    }
}
