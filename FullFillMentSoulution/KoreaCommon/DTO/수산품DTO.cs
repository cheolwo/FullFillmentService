using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 수협Common.DTO
{
    public class Cud수산품DTO : CudDTO
    {

    }
    public class Create수산품DTO : CudDTO
    {
        public string? Code { get; set; }
    }
    public class Update수산품DTO : CudDTO
    {
        public string? Code { get; set; }
    }
    public class Delete수산품TO : CudDTO
    {
        public string? Code { get; set; }
    }
    public class Read수산품DTO : ReadDto
    {
        public string? Code { get; set; }
    }
}
