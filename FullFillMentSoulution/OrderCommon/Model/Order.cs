using Common.Model;
using System.ComponentModel.DataAnnotations;

namespace 주문Common.Model
{
    public class 주문자 : Center
    {
        [Key]
        public string Id { get; set; }
        public List<주문> 주문들 { get; set; }
    }
    public class 주문 : Commodity
    {
        [Key]
        public string Id { get; set; }
        public DateTime 주문일자 { get; set; }
        public string 주문자Id { get; set; }
        public string 판매자상품Id { get; set; }
        public string 판매자Id { get; set; }
        public double Price { get; set; }
        public 판매자상품? 판매자상품 { get; set; }
        public 주문자? 주문자 { get; set; }
        public 판매자? 판매자 { get; set; }
    }

    public class 판매자 : Center
    {
        [Key]
        public string Id { get; set; }
        public List<판매자상품> 판매자상품들 { get; set; }
        public List<주문> 주문된것들{ get; set; }
    }

    public class 판매자상품 : Commodity
    {
        [Key]
        public string Id { get; set; }
        public DateTime 판매개시일자 { get; set; }
        public string 판매자Id { get; set; }
        public string 창고Id { get; set; }
        public double Price { get; set; }
        public 판매자 판매자 { get; set; }
        public List<주문> 주문들 { get; set; }
    }
}

