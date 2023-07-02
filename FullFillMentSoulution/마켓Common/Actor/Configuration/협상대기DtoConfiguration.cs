using Common.Actor.Builder;
using FrontCommon.Actor;
using 마켓Common.Actor.Validator;
using 마켓Common.DTO;

namespace 마켓Common.Actor.Config
{
    public class Create협상대기DtoConfiguration : IDtoTypeCommandConfiguration<Create협상대기DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create협상대기DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create협상대기Validator());
        }
    }
    public class Update협상대기DtoConfiguration : IDtoTypeCommandConfiguration<Update협상대기DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update협상대기DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update협상대기Validator());
        }
    }

    public class Delete협상대기DtoConfiguration : IDtoTypeCommandConfiguration<Delete협상대기DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete협상대기DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete협상대기Validator());
        }
    }
}
