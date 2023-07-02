using Common.Actor.Builder;
using FrontCommon.Actor;
using 마켓Common.Actor.Validator;
using 마켓Common.DTO;

namespace 마켓Common.Actor.Config
{
    public class Create마켓DtoConfiguration : IDtoTypeCommandConfiguration<Create마켓DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create마켓DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create마켓Validator());
        }
    }
    public class Update마켓DtoConfiguration : IDtoTypeCommandConfiguration<Update마켓DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update마켓DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update마켓Validator());
        }
    }

    public class Delete마켓DtoConfiguration : IDtoTypeCommandConfiguration<Delete마켓DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete마켓DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete마켓Validator());
        }
    }
}
