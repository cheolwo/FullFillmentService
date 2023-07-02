using Common.Model;

namespace 주문Common.Model
{
    public enum 주문상태
    {
        미확인, 
        확인,
        할당,
        피킹,
        포장,
        출고
    }
    public class 주문자 : Center
    {
        public string 계좌번호 { get; set; }
        public List<주문상품>? 주문상품들 { get; set; }
        public List<주문대기>? 주문대기들 { get; set; }
        public List<주문중>? 주문중들 { get; set; }
        public List<주문완료>? 주문완료들 { get; set; }
    }
    public class 주문상품 : Commodity
    {
        public string? 주문자Id { get; set; }
        public string 판매자상품Id { get; set; }
        public 주문자? 주문자 { get; set; }
        public List<주문대기>? 주문대기들 { get; set; }
        public List<주문중>? 주문중들 { get; set; }
        public List<주문완료>? 주문완료들 { get; set; }
    }
    public class 주문대기 : Status
    {
        public string? 주문자Id { get; set; }
        public 주문자? 주문자 { get; set; }
        public string? 주문상품Id { get; set; }
        public 주문상품? 주문상품 { get; set; }
        public List<주문중>? 주문중들 { get; set; }
        public List<주문완료>? 주문완료들 { get; set; }
        public string 입고Id { get; set; }
        public string 계약Id { get; set; }
    }
    public class 주문중 : Status
    {
        public string? 주문자Id { get; set; }
        public 주문자? 주문자 { get; set; }
        public string? 주문상품Id { get; set; }
        public 주문상품? 주문상품 { get; set; }
        public string? 주문대기Id { get; set; }
        public 주문대기? 주문대기 { get; set; }
        public List<주문완료>? 주문완료들 { get; set; }
        public string 적재Id { get; set; }
        public string 마켓Id { get; set; }
    }
    public class 주문완료 : Status
    {
        public string? 주문자Id { get; set; }
        public 주문자? 주문자 { get; set; }
        public string? 주문상품Id { get; set; }
        public 주문상품? 주문상품 { get; set; }
        public string? 주문대기Id { get; set; }
        public 주문대기? 주문대기 { get; set; }
        public string? 주문중Id { get; set; }
        public 주문중? 주문중 { get; set; }
        public string 출고Id { get; set; }
        public string 결재Id { get; set; }
    }
}

