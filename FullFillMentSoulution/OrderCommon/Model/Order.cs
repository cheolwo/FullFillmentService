using System.ComponentModel.DataAnnotations;

namespace OrderCommon.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int OrdererId { get; set; }
        public int SellerCommodityId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string? Name { get; set; }
        public SellerCommodity SellerCommodity { get; set; }
        public Orderer Orderer { get; set; }
    }
    public class Orderer
    {
        [Key]
        public int OrdererId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public ICollection<SellerCommodity> SellerCommodities { get; set; }
    }

    public class SellerCommodity
    {
        [Key]
        public int SellerCommodityId { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

