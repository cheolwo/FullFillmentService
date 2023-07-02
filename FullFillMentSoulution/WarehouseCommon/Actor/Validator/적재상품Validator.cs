using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 창고Common.DTO.적재상품;

namespace 창고Common.Actor.Validator
{
    public class Create적재상품Validator : AbstractValidator<Create적재상품DTO>
    {
        public Create적재상품Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("적재상품 name must be between 1 and 100 characters.");
        }
    }

    public class Update적재상품Validator : AbstractValidator<Update적재상품DTO>
    {
        public Update적재상품Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("적재상품 name must be between 1 and 100 characters.");
        }
    }

    public class Delete적재상품Validator : AbstractValidator<Delete적재상품DTO>
    {
        public Delete적재상품Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
