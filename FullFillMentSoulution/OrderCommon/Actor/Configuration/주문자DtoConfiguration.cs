using Common.Actor.Builder;
using FluentValidation;
using FluentValidation.Results;
using FrontCommon.Actor;
using 주문Common.Actor.Validator;
using 주문Common.DTO.주문자;

namespace 주문Common.Actor.Config04
{
    public class Create주문자DtoConfiguration : IDtoTypeCommandConfiguration<Create주문자DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create주문자DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create주문자Validator());
        }
    }
    public class Update주문자DtoConfiguration : IDtoTypeCommandConfiguration<Update주문자DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update주문자DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update주문자Validator());
        }
    }

    public class Delete주문자DtoConfiguration : IDtoTypeCommandConfiguration<Delete주문자DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete주문자DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete주문자Validator());
        }
    }
}
