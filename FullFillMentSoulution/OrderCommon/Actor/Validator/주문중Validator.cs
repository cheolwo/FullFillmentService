using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using 주문Common.DTO.주문중;

namespace 주문Common.Actor.Validator
{
    public class Create주문중Validator : AbstractValidator<Create주문중DTO>
    {
        public Create주문중Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("주문중 name must be between 1 and 100 characters.");
        }
    }

    public class Update주문중Validator : AbstractValidator<Update주문중DTO>
    {
        public Update주문중Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("주문중 name must be between 1 and 100 characters.");
        }
    }

    public class Delete주문중Validator : AbstractValidator<Delete주문중DTO>
    {
        public Delete주문중Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
