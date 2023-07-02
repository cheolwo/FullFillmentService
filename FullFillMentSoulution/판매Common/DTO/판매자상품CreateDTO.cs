using Common.DTO;
using Common.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 판매Common.DTO.DetailDTO;

namespace 판매Common.DTO
{
    public class Create판매자상품DTO : 판매자상품CudDTO, ICreateDTO
    {
    }
    public class Update판매자상품DTO : 판매자상품CudDTO, IUpdateDTO
    {
    }
    public class Delete판매자상품DTO : 판매자상품CudDTO, IDeleteDTO
    {
    }
}
