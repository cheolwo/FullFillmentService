using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model
{
    [NotMapped]
    public class Entity
    {
        [Key]
        public string Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
    [NotMapped]
    public class Center : Entity
    {
        public string? FaxNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

    }
    [NotMapped]
    public class Commodity : Entity
    {
        public string Quantity { get; set; }
    }
}