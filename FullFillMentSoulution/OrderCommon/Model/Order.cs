using Common.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        public string Id { get; set; }
        public string 계좌번호 { get; set; }
        public List<주문>? 주문들 { get; set; }
        public List<댓글>? 댓글들 { get; set; }
        public List<상품문의>? 상품문의들 { get; set; }
    }
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
        public 판매자상품? 판매자상품 { get; set; }
        public 주문자? 주문자 { get; set; }
        public 판매자? 판매자 { get; set; }
        public 주문상태 상태 { get; set; }
    }

    public class 판매자 : Center
    {
        [Key]
        public string Id { get; set; }
        public List<판매자상품>? 판매자상품들 { get; set; }
        public List<주문>? 주문들 { get; set; }
        public List<상품문의>? 상품문의들 { get; set; }
        public List<댓글>? 댓글들 { get; set; }
        public List<할일목록>? 할일목록들 { get; set; }
        public List<주문자구매요약>? 주문자구매요약들 { get; set; }
        public List<판매자상품판매정보요약>? 판매자상품판매정보요약들 { get; set; }
        public string 판매자판매정보요약Id { get; set; }
        public 판매자판매정보요약 판매자판매정보요약 { get; set; }
    }
    public class 할일목록 : Entity
    {
        [Key]
        public string Id { get; set; }
        public 판매자 판매자 { get; set; }
        public 주문 주문 { get; set; }
        public string 판매자Id { get; set; }
        public string 주문Id { get; set; }
        public string 우선순위 { get; set; }
        public string 상태 { get; set; }
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
        public List<상품문의>? 상품문의들 { get; set; }
        public List<주문>? 주문들 { get; set; }
    }
    public class 상품문의 : Entity
    {
        [Key]
        public string Id { get; set; }
        public string? Content { get; set; }
        public string 판매자상품Id { get; set; }
        public string 주문자Id { get; set; }
        public 판매자상품 판매자상품 { get; set; }
        public 주문자 주문자 { get; set; }
    }
    public class 댓글 : Entity
    {
        [Key]
        public string Id { get; set; }
        public string 판매자상품Id { get; set; }
        public string 주문자Id { get; set; }
        public string Content { get; set; }
        public 판매자상품 판매자상품 { get; set; }
        public 주문자 주문자 { get; set; }
    }
    public class 판매자판매정보요약 : Entity
    {
        [Key]
        public string Id { get; set; }
        public string 판매자Id { get; set; }
        public 판매자? 판매자 { get; set; }
        public List<판매자상품판매정보요약>? 판매자상품판매정보요약들 { get; set; }
    }
    public class 판매자상품판매정보요약 : Entity
    {
        [Key]
        public string Id { get; set; }
        public string 판매자상품Id { get; set; }
        public 판매자상품 판매자상품 { get; set; }
        public string 판매자Id { get; set; }
        public 판매자 판매자 { get; set;  }
        public List<주문자구매요약> 주문자구매요약 { get; set; }
    }

    public class 주문자구매요약 : Entity
    {
        [Key]
        public string Id { get; set; }  
        public DateTime 구매일시 { get; set; }
        public string 총구매가격 { get; set; }
        public string 총수량 { get; set; }
        public 판매자상품판매정보요약 판매자상품판매정보요약 { get; set; }
        public string 판매자상품판매정보요약Id { get; set; }
        public 판매자 판매자 { get; set; }
        public string 판매자Id { get; set; }
        public 판매자상품 판매자상품 { get; set; }
        public string 판매자상품Id { get; set; }
        public 주문자 주문자 { get; set; }
        public string 주문자Id { get; set; }
    }
}

