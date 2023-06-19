using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 수협Common.DTO
{
    public class Cud수산품별재고현황DTO : CudDTO
    {

    }
    public class Create수산품별재고현황DTO : CudDTO
    {
        public string? Code;
    }
    public class Update수산품별재고현황DTO : CudDTO
    {
        public string? Code;
    }
    public class Delete수산품별재고현황TO : CudDTO
    {
        public string? Code;
    }
    public class Read수산품별재고현황DTO : ReadDto
    {
        public string? Code;
    }
}
