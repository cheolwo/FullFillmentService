using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 판매Common.DTO;

namespace 판매Common.Actor.Validator
{
    public class Create판매완료Validator : AbstractValidator<Create판매완료DTO>
    {
        public Create판매완료Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("판매완료 name must be between 1 and 100 characters.");
        }
    }

    public class Update판매완료Validator : AbstractValidator<Update판매완료DTO>
    {
        public Update판매완료Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("판매완료 name must be between 1 and 100 characters.");
        }
    }

    public class Delete판매완료Validator : AbstractValidator<Delete판매완료DTO>
    {
        public Delete판매완료Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
