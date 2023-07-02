using Common.Actor.Builder;
using FrontCommon.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 마켓Common.Actor.Validator;
using 마켓Common.DTO;

namespace 마켓Common.Actor.Config
{
    public class Create마켓상품DtoConfiguration : IDtoTypeCommandConfiguration<Create마켓상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create마켓상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create마켓상품Validator());
        }
    }
    public class Update마켓상품DtoConfiguration : IDtoTypeCommandConfiguration<Update마켓상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update마켓상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update마켓상품Validator());
        }
    }

    public class Delete마켓상품DtoConfiguration : IDtoTypeCommandConfiguration<Delete마켓상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete마켓상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete마켓상품Validator());
        }
    }
}
