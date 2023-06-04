using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model
{
    [NotMapped]
    public class Entity
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Entity other = (Entity)obj;
            return Code == other.Code && Name == other.Name;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + (Code?.GetHashCode() ?? 0);
            hash = hash * 23 + (Name?.GetHashCode() ?? 0);
            return hash;
        }

    }
    [NotMapped]
    public class Center : Entity
    {
        public string? FaxNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }    
        public string? ZipCode { get; set; }

    }
    [NotMapped]
    public class Commodity : Entity
    {
        public string Quantity { get; set; }
    }
}