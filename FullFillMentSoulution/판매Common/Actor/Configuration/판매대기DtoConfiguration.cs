using Common.Actor.Builder;
using FluentValidation;
using FluentValidation.Results;
using FrontCommon.Actor;
using 판매Common.Actor.Validator;
using 판매Common.DTO;

namespace 판매Common.Actor.Config04
{
     public class Create판매대기DtoConfiguration : IDtoTypeCommandConfiguration<Create판매대기DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create판매대기DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create판매대기Validator());
        }
    }
    public class Update판매대기DtoConfiguration : IDtoTypeCommandConfiguration<Update판매대기DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update판매대기DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update판매대기Validator());
        }
    }

    public class Delete판매대기DtoConfiguration : IDtoTypeCommandConfiguration<Delete판매대기DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete판매대기DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete판매대기Validator());
        }
    }
}
