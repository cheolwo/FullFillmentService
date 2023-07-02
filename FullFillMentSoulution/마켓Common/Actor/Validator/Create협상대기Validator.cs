using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 마켓Common.DTO;

namespace 마켓Common.Actor.Validator
{
    public class Create협상대기Validator : AbstractValidator<Create협상대기DTO>
    {
        public Create협상대기Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("협상대기 name must be between 1 and 100 characters.");     
        }
    }

    public class Update협상대기Validator : AbstractValidator<Update협상대기DTO>
    {
        public Update협상대기Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("협상대기 name must be between 1 and 100 characters.");
        }
    }

    public class Delete협상대기Validator : AbstractValidator<Delete협상대기DTO>
    {
        public Delete협상대기Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
