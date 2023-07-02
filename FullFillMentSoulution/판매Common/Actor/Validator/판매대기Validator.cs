using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 판매Common.DTO;

namespace 판매Common.Actor.Validator
{
    public class Create판매대기Validator : AbstractValidator<Create판매대기DTO>
    {
        public Create판매대기Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("판매대기 name must be between 1 and 100 characters.");
        }
    }

    public class Update판매대기Validator : AbstractValidator<Update판매대기DTO>
    {
        public Update판매대기Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("판매대기 name must be between 1 and 100 characters.");
        }
    }

    public class Delete판매대기Validator : AbstractValidator<Delete판매대기DTO>
    {
        public Delete판매대기Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
