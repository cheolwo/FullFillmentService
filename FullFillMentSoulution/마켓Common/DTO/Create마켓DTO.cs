using Common.DTO;
using Common.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 마켓Common.DTO
{
    public class Create마켓DTO : 마켓CudDTO, ICreateDTO
    {
    }
    public class Update마켓DTO : 마켓CudDTO, IUpdateDTO
    { 
    }
    public class Delete마켓DTO : 마켓CudDTO, IDeleteDTO
    {

    }
    public class Read마켓DTO : ReadDto
    {

    }
}
