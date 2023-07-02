using Common.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Actor.Configuration.Validator
{
    public class CenterCudDTOValidator : AbstractValidator<CenterCudDTO>
    {
        public CenterCudDTOValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.CreatedAt)
                .NotEmpty().WithMessage("CreatedAt is required.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.");

            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("ZipCode is required.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("전화번호는 필수 항목입니다.")
                .Matches(@"^\d{3}-\d{3,4}-\d{4}$").WithMessage("전화번호는 xxx-xxxx-xxxx 형식이어야 합니다.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");
        }
    }
}
