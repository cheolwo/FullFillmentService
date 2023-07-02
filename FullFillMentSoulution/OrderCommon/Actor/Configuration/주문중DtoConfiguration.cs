using Common.Actor.Builder;
using FrontCommon.Actor;
using 주문Common.Actor.Validator;
using 주문Common.DTO.주문중;

namespace 주문Common.Actor.Config
{
    public class Create주문중DtoConfiguration : IDtoTypeCommandConfiguration<Create주문중DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create주문중DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create주문중Validator());
        }
    }
    public class Update주문중DtoConfiguration : IDtoTypeCommandConfiguration<Update주문중DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update주문중DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update주문중Validator());
        }
    }

    public class Delete주문중DtoConfiguration : IDtoTypeCommandConfiguration<Delete주문중DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete주문중DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete주문중Validator());
        }
    }
}
