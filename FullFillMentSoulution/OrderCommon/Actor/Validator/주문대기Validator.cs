using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 주문Common.DTO.주문대기;

namespace 주문Common.Actor.Validator
{
    public class Create주문대기Validator : AbstractValidator<Create주문대기DTO>
    {
        public Create주문대기Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("주문대기 name must be between 1 and 100 characters.");
        }
    }

    public class Update주문대기Validator : AbstractValidator<Update주문대기DTO>
    {
        public Update주문대기Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("주문대기 name must be between 1 and 100 characters.");
        }
    }

    public class Delete주문대기Validator : AbstractValidator<Delete주문대기DTO>
    {
        public Delete주문대기Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
