using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 주문Common.DTO.댓글
{
    public class Create댓글DTO
    {
        public string Id { get; set; }
    }
    public class Update댓글DTO
    {
        public string Id { get; set; }
        public string Content { get; set; }
    }
    public class Delete댓글TO
    {
        public string Id { get; set; }
    }
    public class Read댓글DTO
    {
        public string Id { get; set; }
    }
}
