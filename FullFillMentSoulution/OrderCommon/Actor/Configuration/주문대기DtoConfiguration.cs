using Common.Actor.Builder;
using FluentValidation;
using FluentValidation.Results;
using FrontCommon.Actor;
using 주문Common.Actor.Validator;
using 주문Common.DTO.주문대기;

namespace 주문Common.Actor.Config
{
    public class Create주문대기DtoConfiguration : IDtoTypeCommandConfiguration<Create주문대기DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create주문대기DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create주문대기Validator());
        }
    }
    public class Update주문대기DtoConfiguration : IDtoTypeCommandConfiguration<Update주문대기DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update주문대기DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update주문대기Validator());
        }
    }

    public class Delete주문대기DtoConfiguration : IDtoTypeCommandConfiguration<Delete주문대기DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete주문대기DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete주문대기Validator());
        }
    }
}
