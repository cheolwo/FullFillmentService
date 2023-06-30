using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using Common.DTO.Interface;

namespace 주문Common.DTO.주문중
{
    public class Create주문중DTO : 주문중CudDTO, ICreateDTO
    {
    }
    public class Update주문중DTO : 주문중CudDTO, IUpdateDTO
    {
    }
    public class Delete주문중DTO : 주문중CudDTO, IDeleteDTO
    {
    }
    public class Read주문중DTO : ReadDto
    {
    }
}
