using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 마켓Common.DTO;

namespace 마켓Common.Actor.Validator
{
    public class Create마켓상품Validator : AbstractValidator<Create마켓상품DTO>
    {
        public Create마켓상품Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("마켓상품 name must be between 1 and 100 characters.");     
        }
    }

    public class Update마켓상품Validator : AbstractValidator<Update마켓상품DTO>
    {
        public Update마켓상품Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("마켓상품 name must be between 1 and 100 characters.");
        }
    }

    public class Delete마켓상품Validator : AbstractValidator<Delete마켓상품DTO>
    {
        public Delete마켓상품Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
