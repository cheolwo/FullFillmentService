using Common.Actor.Builder;
using FrontCommon.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 창고Common.Actor.Validator;
using 창고Common.DTO.창고상품;

namespace 창고Common.Actor.Configuration
{
    public class Create창고상품DtoConfiguration : IDtoTypeCommandConfiguration<Create창고상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create창고상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Create창고상품Validator());
        }
    }
    public class Update창고상품DtoConfiguration : IDtoTypeCommandConfiguration<Update창고상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update창고상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Update창고상품Validator());
        }
    }

    public class Delete창고상품DtoConfiguration : IDtoTypeCommandConfiguration<Delete창고상품DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete창고상품DTO> builder)
        {
            builder.SetServerBaseAddress("").SetRoute("").SetValidator(new Delete창고상품Validator());
        }
    }
}
