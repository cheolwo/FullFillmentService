using Common.DTO;
using Common.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 마켓Common.DTO
{
    public class Create마켓상품DTO : 마켓상품CudDTO, ICreateDTO
    {
    }
    public class Update마켓상품DTO : 마켓상품CudDTO, IUpdateDTO
    {
    }
    public class Delete마켓상품DTO : 마켓상품CudDTO, IDeleteDTO
    {

    }
    public class Read마켓상품DTO : ReadDto
    {

    }
}
