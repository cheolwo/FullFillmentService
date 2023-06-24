using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class CudDTO 
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class CenterCudDTO : CudDTO
    {

    }
    public class CommodityCudDTO : CudDTO
    {

    }
    public class StatusCudDTO : CudDTO
    {

    }
    public class ReadDto 
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set;}
    }
}
