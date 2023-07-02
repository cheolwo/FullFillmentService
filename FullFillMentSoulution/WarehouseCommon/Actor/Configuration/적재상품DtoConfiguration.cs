using Common.Actor.Builder;
using FrontCommon.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 창고Common.Actor.Validator;
using 창고Common.DTO.적재상품;

namespace 창고Common.Actor.Configuration
{
    public class Create적재상품DtoConfiguration : IDtoTypeCommandConfiguration<Create적재상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create적재상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create적재상품Validator());
        }
    }
    public class Update적재상품DtoConfiguration : IDtoTypeCommandConfiguration<Update적재상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update적재상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update적재상품Validator());
        }
    }

    public class Delete적재상품DtoConfiguration : IDtoTypeCommandConfiguration<Delete적재상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete적재상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete적재상품Validator());
        }
    }
}
