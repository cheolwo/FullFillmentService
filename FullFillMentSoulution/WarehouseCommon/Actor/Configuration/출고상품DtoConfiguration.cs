using Common.Actor.Builder;
using FrontCommon.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 창고Common.Actor.Validator;
using 창고Common.DTO.출고상품;

namespace 창고Common.Actor.Configuration
{
    public class Create출고상품DtoConfiguration : IDtoTypeCommandConfiguration<Create출고상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create출고상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create출고상품Validator());
        }
    }
    public class Update출고상품DtoConfiguration : IDtoTypeCommandConfiguration<Update출고상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update출고상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update출고상품Validator());
        }
    }

    public class Delete출고상품DtoConfiguration : IDtoTypeCommandConfiguration<Delete출고상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete출고상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete출고상품Validator());
        }
    }
}
