using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 주문Common.DTO.댓글
{
    public class Create댓글DTO : CudDTO
    {
    }
    public class Update댓글DTO : CudDTO
    {
        public string Content { get; set; }
    }
    public class Delete댓글TO : CudDTO
    {
    }
    public class Read댓글DTO : ReadDto
    {
    }
}
