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
    public class Read판매자DTO : ReadCenterDTO
    {
        public string? 화물통관고유부호 { get; set; }
        public List<string>? 판매자상품들 { get; set; } // ReadDTO Json
        public List<string>? 판매대기들 { get; set; } // ReadDTO Json
        public List<string>? 판매중들 { get; set; } // ReadDTO Json

        public List<string>? 판매완료들 { get; set; } // ReadDTO Json
    }
    public class Read판매자상품DTO : ReadCommodityDTO
    {
        public string? 판매자 { get; set; } // ReadDTO Json
    }
    public class Read판매대기DTO : ReadStatusDTO
    {
        public string? BL번호 { get; set; }
        public string? 화물관리번호 { get; set; }
        public string? 판매자 { get; set; } // ReadDTO Json
        public string? 판매자상품 { get; set; } // ReadDTO Json
        public string? 입고상품 { get; set; } // ReadDTO Json
        public string? 협상대기 { get; set; } // ReadDTO Json
        public string? 협상중 { get; set; } // ReadDTO Json
        public string? 협상완료 { get; set; } // ReadDTO Json
    }
    public class Read판매중DTO : ReadStatusDTO
    {
        public string? 판매자 { get; set; } // ReadDTO Json
        public string? 판매자상품 { get; set; } // ReadDTO Json
        public string? 판매대기 { get; set; }// ReadDTO Json
        public string? 오픈마켓 { get; set; }// ReadDTO Json
        public string? 적재상품 { get; set; }// ReadDTO Json
    }
    public class Read판매완료DTO : ReadStatusDTO
    {
        public string? 판매자 { get; set; } // ReadDTO Json
        public string? 판매자상품 { get; set; } // ReadDTO Json
        public string? 판매대기 { get; set; }// ReadDTO Json
        public string? 판매중 { get; set; }// ReadDTO Json
        public string? 택배사 { get; set; }
        public string? 송장번호 { get; set; }
        public string? 협상완료 { get; set; } // ReadDTO Json
        public string? 주문자 { get; set; } // ReadDTO Json
        public string? 출고상품 { get; set; } // ReadDTO Json
    }
}
