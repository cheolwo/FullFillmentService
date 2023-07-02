using Common.Actor.Builder;
using FluentValidation;
using FluentValidation.Results;
using FrontCommon.Actor;
using 주문Common.Actor.Validator;
using 주문Common.DTO.주문완료;

namespace 주문Common.Actor.Config
{
    public class Create주문완료DtoConfiguration : IDtoTypeCommandConfiguration<Create주문완료DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create주문완료DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create주문완료Validator());
        }
    }
    public class Update주문완료DtoConfiguration : IDtoTypeCommandConfiguration<Update주문완료DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update주문완료DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update주문완료Validator());
        }
    }

    public class Delete주문완료DtoConfiguration : IDtoTypeCommandConfiguration<Delete주문완료DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete주문완료DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete주문완료Validator());
        }
    }
}
