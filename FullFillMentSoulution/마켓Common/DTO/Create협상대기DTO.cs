using Common.DTO;
using Common.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 마켓Common.DTO
{
    public class Create협상대기DTO : 협상대기CudDTO, ICreateDTO
    {
    }
    public class Update협상대기DTO : 협상대기CudDTO, IUpdateDTO
    {
    }
    public class Delete협상대기DTO : 협상대기CudDTO, IDeleteDTO
    {

    }
    public class Read협상대기DTO : ReadDto
    {

    }
}
