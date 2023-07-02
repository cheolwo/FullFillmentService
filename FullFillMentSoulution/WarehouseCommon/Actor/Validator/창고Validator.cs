using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 창고Common.DTO.창고;

namespace 창고Common.Actor.Validator
{
    public class Create창고Validator : AbstractValidator<Create창고DTO>
    {
        public Create창고Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("창고 name must be between 1 and 100 characters.");
        }
    }

    public class Update창고Validator : AbstractValidator<Update창고DTO>
    {
        public Update창고Validator()
        {
            // Other fields can be null, but if they are not null, they should meet the requirements.
            RuleFor(x => x.Name)
                .Length(1, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("창고 name must be between 1 and 100 characters.");
        }
    }

    public class Delete창고Validator : AbstractValidator<Delete창고DTO>
    {
        public Delete창고Validator()
        {
            // Generally, only the Id is required for a delete.
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
