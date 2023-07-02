using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 주문Common.DTO.주문완료;

namespace 주문Common.Actor.Validator
{
    public class Create주문완료Validator : AbstractValidator<Create주문완료DTO>
    {
        public Create주문완료Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("주문완료 name must be between 1 and 100 characters.");
        }
    }

    public class Update주문완료Validator : AbstractValidator<Update주문완료DTO>
    {
        public Update주문완료Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("주문완료 name must be between 1 and 100 characters.");
        }
    }

    public class Delete주문완료Validator : AbstractValidator<Delete주문완료DTO>
    {
        public Delete주문완료Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
