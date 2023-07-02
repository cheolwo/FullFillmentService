using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 마켓Common.Actor.Validator
{
    public class Create협상중Validator : AbstractValidator<Create협상중DTO>
    {
        public Create협상중Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("협상중 name must be between 1 and 100 characters.");     
        }
    }

    public class Update협상중Validator : AbstractValidator<Update협상중DTO>
    {
        public Update협상중Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("협상중 name must be between 1 and 100 characters.");
        }
    }

    public class Delete협상중Validator : AbstractValidator<Delete협상중DTO>
    {
        public Delete협상중Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
