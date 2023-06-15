using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model
{
    [NotMapped]
    public class Entity
    {
        public string Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? FileUrlJson { get; set; } // JSON 직렬화된 문자열을 저장할 속성 추가
        public DateTime CreatedAt { get; set; }
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
        [NotMapped]
        public List<string> FileUrls
        {
            get => JsonConvert.DeserializeObject<List<string>>(FileUrlJson);
            set => FileUrlJson = JsonConvert.SerializeObject(value);
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