using Common.Actor.Builder;
using FluentValidation;
using FluentValidation.Results;
using FrontCommon.Actor;
using 판매Common.DTO;

namespace 판매Common.Actor.Config04
{
    public class Create판매자상품DtoConfiguration : IDtoTypeCommandConfiguration<Create판매자상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create판매자상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create판매자상품Validator());
        }
    }
    public class Update판매자상품DtoConfiguration : IDtoTypeCommandConfiguration<Update판매자상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update판매자상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update판매자상품Validator());
        }
    }

    public class Delete판매자상품DtoConfiguration : IDtoTypeCommandConfiguration<Delete판매자상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete판매자상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete판매자상품Validator());
        }
    }
}
