using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using Common.DTO.Interface;

namespace 주문Common.DTO.주문완료
{
    public class Create주문완료DTO : 주문완료CudDTO, ICreateDTO
    {
    }
    public class Update주문완료DTO : 주문완료CudDTO, IUpdateDTO
    {
    }
    public class Delete주문완료DTO : 주문완료CudDTO, IDeleteDTO
    {
    }
    public class Read주문완료DTO : ReadDto
    {
    }
}
