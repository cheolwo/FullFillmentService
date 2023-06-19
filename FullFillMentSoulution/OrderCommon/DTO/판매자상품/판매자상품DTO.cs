using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 주문Common.DTO.판매자상품
{
    public class Cud판매자상품DTO : CudDTO
    {

    }
    public class Create판매자상품DTO : CudDTO
    {
    }
    public class Update판매자상품DTO : CudDTO
    {
    }
    public class Delete판매자상품TO : CudDTO
    {
    }
    public class Read판매자상품DTO : ReadDto
    { 
        public DateTime SaleDate { get; set; }
    }
}
