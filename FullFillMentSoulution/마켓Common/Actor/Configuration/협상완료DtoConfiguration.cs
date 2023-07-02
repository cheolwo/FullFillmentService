using Common.Actor.Builder;
using FrontCommon.Actor;
using 마켓Common.Actor.Validator;
using 마켓Common.DTO;


namespace 마켓Common.Actor.Config
{
    public class Create협상완료DtoConfiguration : IDtoTypeCommandConfiguration<Create협상완료DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create협상완료DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create협상완료Validator());
        }
    }
    public class Update협상완료DtoConfiguration : IDtoTypeCommandConfiguration<Update협상완료DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update협상완료DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update협상완료Validator());
        }
    }

    public class Delete협상완료DtoConfiguration : IDtoTypeCommandConfiguration<Delete협상완료DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete협상완료DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete협상완료Validator());
        }
    }
}
