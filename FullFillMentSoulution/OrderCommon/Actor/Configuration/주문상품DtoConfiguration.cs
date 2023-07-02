using Common.Actor.Builder;
using FluentValidation;
using FluentValidation.Results;
using FrontCommon.Actor;
using 주문Common.Actor.Validator;
using 주문Common.DTO.주문상품;

namespace 주문Common.Actor.Config04
{
    public class Create주문상품DtoConfiguration : IDtoTypeCommandConfiguration<Create주문상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create주문상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create주문상품Validator());
        }
    }
    public class Update주문상품DtoConfiguration : IDtoTypeCommandConfiguration<Update주문상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update주문상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update주문상품Validator());
        }
    }

    public class Delete주문상품DtoConfiguration : IDtoTypeCommandConfiguration<Delete주문상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete주문상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete주문상품Validator());
        }
    }
}
