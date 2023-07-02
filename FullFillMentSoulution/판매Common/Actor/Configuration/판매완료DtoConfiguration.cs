using Common.Actor.Builder;
using FluentValidation;
using FluentValidation.Results;
using FrontCommon.Actor;
using 판매Common.DTO;

namespace 판매Common.Actor.Config04
{
    public class Create판매완료DtoConfiguration : IDtoTypeCommandConfiguration<Create판매완료DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create판매완료DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create판매완료Validator());
        }
    }
    public class Update판매완료DtoConfiguration : IDtoTypeCommandConfiguration<Update판매완료DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update판매완료DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update판매완료Validator());
        }
    }

    public class Delete판매완료DtoConfiguration : IDtoTypeCommandConfiguration<Delete판매완료DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete판매완료DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete판매완료Validator());
        }
    }
}
