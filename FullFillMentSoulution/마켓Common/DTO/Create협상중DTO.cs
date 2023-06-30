using Common.DTO;
using Common.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace 마켓Common.DTO
{
    public class Create협상중DTO : 협상중CudDTO, ICreateDTO
    {
    }
    public class Update협상중DTO : 협상중CudDTO, IUpdateDTO
    {
    }
    public class Delete협상중DTO : 협상중CudDTO, IDeleteDTO
    {
    }
    public class Read협상중DTO : ReadDto
    {
    }
}
