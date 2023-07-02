using Common.Actor.Builder;
using FluentValidation;
using FluentValidation.Results;
using FrontCommon.Actor;
using 판매Common.DTO;

namespace 판매Common.Actor.Config04
{
    public class Create판매자DtoConfiguration : IDtoTypeCommandConfiguration<Create판매자DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create판매자DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create판매자Validator());
        }
    }
    public class Update판매자DtoConfiguration : IDtoTypeCommandConfiguration<Update판매자DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update판매자DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update판매자Validator());
        }
    }

    public class Delete판매자DtoConfiguration : IDtoTypeCommandConfiguration<Delete판매자DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete판매자DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete판매자Validator());
        }
    }
}
