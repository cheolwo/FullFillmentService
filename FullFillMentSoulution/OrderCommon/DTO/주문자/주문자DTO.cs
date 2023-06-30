using Common.DTO;
using Common.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 주문Common.DTO.주문자
{
    public class Create주문자DTO : 주문자CudDTO, ICreateDTO
    {
    }
    public class Update주문자DTO : 주문자CudDTO, IUpdateDTO
    {
    }
    public class Delete주문자DTO : 주문자CudDTO, IDeleteDTO
    {
    }
    public class Read주문자DTO : ReadDto
    {
    }
}
