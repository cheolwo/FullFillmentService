using Common.DTO;
using Common.DTO.Interface;
using 판매Common.DTO.DetailDTO;

namespace 판매Common.DTO
{
    public class Create판매자DTO : 판매자CudDTO, ICreateDTO
    {
    }
    public class Update판매자DTO : 판매자CudDTO, IUpdateDTO
    {
    }
    public class Delete판매자DTO : 판매자CudDTO, IDeleteDTO
    {
    }
    public class Read판매자DTO : ReadDto
    {
    }
}
