using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using 주문Common.DTO.주문자;

namespace 주문Common.Actor.Validator
{
    public class Create주문자Validator : AbstractValidator<Create주문자DTO>
    {
        public Create주문자Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("주문자 name must be between 1 and 100 characters.");
        }
    }

    public class Update주문자Validator : AbstractValidator<Update주문자DTO>
    {
        public Update주문자Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("주문자 name must be between 1 and 100 characters.");
        }
    }

    public class Delete주문자Validator : AbstractValidator<Delete주문자DTO>
    {
        public Delete주문자Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
