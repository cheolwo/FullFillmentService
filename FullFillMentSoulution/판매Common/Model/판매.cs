using Common.Model;
using System.ComponentModel.DataAnnotations;

namespace 판매Common.Model
{
    public class 판매자 : Center
    {
        [Key]
        public string Id { get; set; }
        public List<판매자상품> 판매자상품들 { get; set; }
        public List<판매대기> 판매대기들 { get; set; }
        public List<판매중> 판매중들 { get; set; }
        public List<판매완료> 판매완료들 { get; set; }
    }
    public class 판매자상품 : Commodity
    {
        [Key]
        public string Id { get; set; }
        public string 판매자Id { get; set; }
        public 판매자 판매자 { get; set; }
        public List<판매대기> 판매대기들 { get; set; }
        public List<판매중> 판매중들 { get; set; }
        public List<판매완료> 판매완료들 { get; set; }
    }
    public class 판매대기 : Status
    {
        [Key]
        public string Id { get; set; }
        public string? 판매자Id { get; set; }
        public 판매자? 판매자 { get; set; }
        public string? 판매자상품Id { get; set; }
        public 판매자상품? 판매자상품 { get; set; }
        public List<판매중> 판매중들 { get; set; }
        public List<판매완료> 판매완료들 { get; set; }
        public string 입고Id { get; set; }
        public string 계약Id { get; set; }
    }
    public class 판매중 : Status
    {
        [Key]
        public string Id { get; set; }
        public 판매자? 판매자 { get; set; }
        public string? 판매자상품Id { get; set; }
        public 판매자상품? 판매자상품 { get; set; }
        public string? 판매대기Id { get; set; }
        public 판매대기? 판매대기 { get; set; }
        public string? 판매중Id { get; set; }
        public List<판매완료> 판매완료들 { get; set; }
        public string 마켓Id { get; set; }
        public string 적재Id { get; set; }
    }
    public class 판매완료 : Status
    {
        [Key]
        public string Id { get; set; }
        public string? 판매자Id { get; set; }
        public 판매자? 판매자 { get; set; }
        public string? 판매자상품Id { get; set; }
        public 판매자상품? 판매자상품 { get; set; }
        public string? 판매대기Id { get; set; }
        public 판매대기? 판매대기 { get; set; }
        public string? 판매중Id { get; set; }
        public 판매중? 판매중 { get; set; }
        public string? 주문Id { get; set; }
        public string? 출고Id { get; set; }
    }
    //public class 창고 : Center
    //{
    //    public string Id { get; set; }
    //    public List<판매대기> 판매대기들 { get; set; }
    //}
    //public class 마켓 : Center
    //{
    //    public string Id { get; set; }
    //    public List<판매중> 판매중들 { get; set; }
    //}
    //public class 주문자 : Center 
    //{
    //    public string Id { get; set; }
    //    public List<판매완료> 판매완료들 { get; set; }
    //}

}