using Common.Actor.Builder;
using FrontCommon.Actor;
using 판매Common.Actor.Validator;
using 판매Common.DTO;

namespace 판매Common.Actor.Config04
{
    public class Create판매중DtoConfiguration : IDtoTypeCommandConfiguration<Create판매중DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create판매중DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create판매중Validator());
        }
    }
    public class Update판매중DtoConfiguration : IDtoTypeCommandConfiguration<Update판매중DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update판매중DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update판매중Validator());
        }
    }

    public class Delete판매중DtoConfiguration : IDtoTypeCommandConfiguration<Delete판매중DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete판매중DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete판매중Validator());
        }
    }
}
