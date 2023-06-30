using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 주문Common.DTO
{
    public class 주문자CudDTO : CenterCudDTO
    {
    }
    public class 주문상품CudDTO : CommodityCudDTO
    {

    }
    public class 주문대기CudDTO : StatusCudDTO
    {

    }
    public class 주문중CudDTO : StatusCudDTO
    {

    }
    public class 주문완료CudDTO : StatusCudDTO
    {

    }
}
