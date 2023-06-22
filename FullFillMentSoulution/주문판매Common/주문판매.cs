using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.Model;
using 판매Common;
using 주문Common.Model;

namespace 주문판매Common
{
    public class 주문 : Commodity
    {
        [Key]
        public string Id { get; set; }
        public DateTime 주문일자 { get; set; }
        public string 주문자Id { get; set; }
        public string 판매자상품Id { get; set; }
        public string 판매자Id { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public double Price { get; set; }
        public string 결제번호 { get; set; }
        public string 적용포인트 { get; set; }
        public string 출고Id { get; set; }
        public string 결재Id { get; set; }
    }

    public class 상품문의 : Entity
    {
        [Key]
        public string Id { get; set; }
        public string? Content { get; set; }
        public string 판매자상품Id { get; set; }
        public string 주문자Id { get; set; }
    }
    public class 댓글 : Entity
    {
        [Key]
        public string Id { get; set; }
        public string 판매자상품Id { get; set; }
        public string 주문자Id { get; set; }
        public string Content { get; set; }
    }
}