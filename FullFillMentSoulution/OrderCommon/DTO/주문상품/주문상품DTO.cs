using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using Common.DTO.Interface;

namespace 주문Common.DTO.주문상품
{
    public class Create주문상품DTO : 주문상품CudDTO, ICreateDTO
    {
    }
    public class Update주문상품DTO : 주문상품CudDTO, IUpdateDTO
    {
    }
    public class Delete주문상품DTO : 주문상품CudDTO, IDeleteDTO
    {
    }
    public class Read주문상품DTO : ReadDto
    {
    }
}
