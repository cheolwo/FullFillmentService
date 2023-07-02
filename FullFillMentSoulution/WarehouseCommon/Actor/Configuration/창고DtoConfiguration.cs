using Common.Actor.Builder;
using FrontCommon.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 창고Common.Actor.Validator;
using 창고Common.DTO.창고;

namespace 창고Common.Actor.Configuration
{
    public class Create창고DtoConfiguration : IDtoTypeCommandConfiguration<Create창고DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create창고DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create창고Validator());
        }
    }
    public class Update창고DtoConfiguration : IDtoTypeCommandConfiguration<Update창고DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update창고DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update창고Validator());
        }
    }

    public class Delete창고DtoConfiguration : IDtoTypeCommandConfiguration<Delete창고DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete창고DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete창고Validator());
        }
    }
}
