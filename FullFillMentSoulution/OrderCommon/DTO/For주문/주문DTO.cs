using Common.DTO;
using FrontCommon.Actor;

namespace 주문Common.DTO.For주문
{
    public class Cud주문DTO : CudDTO
    {
        public string 주문명 { get; set; }
    }
    [CQRS(true)]
    public class Create주문DTO : Cud주문DTO
    {
    }
    public class Update주문DTO : Cud주문DTO
    {
    }
    public class Delete주문DTO : Cud주문DTO
    {
    }
    public class Read주문DTO : ReadDto
    {
    }
}
