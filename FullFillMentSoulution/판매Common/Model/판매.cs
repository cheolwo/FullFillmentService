using Common.Model;

namespace 판매Common.Model
{
    public class 판매자 : Center
    {
        public string? 화물통관고유부호 { get; set; }
        public List<판매자상품> 판매자상품들 { get; set; }
        public List<판매대기> 판매대기들 { get; set; }
        public List<판매중> 판매중들 { get; set; }
        public List<판매완료> 판매완료들 { get; set; }
    }
    public class 판매자상품 : Commodity
    {
        public string? 판매자Id { get; set; }
        public 판매자 판매자 { get; set; }
        public List<판매대기> 판매대기들 { get; set; }
        public List<판매중> 판매중들 { get; set; }
        public List<판매완료> 판매완료들 { get; set; }
    }
    public class 판매대기 : Status
    {
        public string? 판매자Id { get; set; }
        public 판매자? 판매자 { get; set; }
        public string? 판매자상품Id { get; set; }
        public 판매자상품? 판매자상품 { get; set; }
        public List<판매중> 판매중들 { get; set; }
        public List<판매완료> 판매완료들 { get; set; }
        public string? BL번호 { get; set; }
        public string? 화물관리번호 { get; set; }
        public string? 입고Id { get; set; }
        public string? 협상대기Id { get; set; }
        public string? 협상중Id { get; set; }
        public string? 협상완료Id { get; set; }
    }
    public class 판매중 : Status
    {
        public 판매자? 판매자 { get; set; }
        public string? 판매자상품Id { get; set; }
        public 판매자상품? 판매자상품 { get; set; }
        public string? 판매대기Id { get; set; }
        public 판매대기? 판매대기 { get; set; }
        public string? 판매중Id { get; set; }
        public List<판매완료> 판매완료들 { get; set; }
        public string? 마켓판매중Id { get; set; }
        public string? 오픈마켓Id { get; set; }
        public string 적재Id { get; set; }
    }
    public class 판매완료 : Status
    {
        public string? 판매자Id { get; set; }
        public 판매자? 판매자 { get; set; }
        public string? 판매자상품Id { get; set; }
        public 판매자상품? 판매자상품 { get; set; }
        public string? 판매대기Id { get; set; }
        public 판매대기? 판매대기 { get; set; }
        public string? 판매중Id { get; set; }
        public 판매중? 판매중 { get; set; }
        public string? 택배사 { get; set; }
        public string? 송장번호 { get; set; }
        public string? 협상완료Id { get; set; }
        public string? 마켓판매완료Id { get; set; }
        public string? 주문자Id { get; set; }
        public string? 출고Id { get; set; }
    }
}