using Common.Actor.Builder;
using FrontCommon.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 창고Common.Actor.Validator;
using 창고Common.DTO.입고상품;

namespace 창고Common.Actor.Configuration
{
    public class Create입고상품DtoConfiguration : IDtoTypeCommandConfiguration<Create입고상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create입고상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create입고상품Validator());
        }
    }
    public class Update입고상품DtoConfiguration : IDtoTypeCommandConfiguration<Update입고상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update입고상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update입고상품Validator());
        }
    }

    public class Delete입고상품DtoConfiguration : IDtoTypeCommandConfiguration<Delete입고상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete입고상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete입고상품Validator());
        }
    }
}
