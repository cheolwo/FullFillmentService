using Common.Actor.Builder;
using FrontCommon.Actor;
using 마켓Common.Actor.Validator;
using 마켓Common.DTO;

namespace 마켓Common.Actor.Config
{
    public class Create협상중DtoConfiguration : IDtoTypeCommandConfiguration<Create협상중DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create협상중DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create협상중Validator());
        }
    }
    public class Update협상중DtoConfiguration : IDtoTypeCommandConfiguration<Update협상중DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update협상중DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update협상중Validator());
        }
    }

    public class Delete협상중DtoConfiguration : IDtoTypeCommandConfiguration<Delete협상중DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete협상중DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete협상중Validator());
        }
    }
}
