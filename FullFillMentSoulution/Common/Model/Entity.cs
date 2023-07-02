using AutoMapper.Configuration.Annotations;
using Common.Cache;
using Newtonsoft.Json;
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
        //public List<문의> 문의들 { get; set; }
    }
    [NotMapped]
    public class Center : Entity, IStorableInCenterMemory
    {
        public string? UserId { get; set; }
        public string? FaxNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }    
        public string? ZipCode { get; set; }
        [Ignore]
        public Dictionary<string, string> Commodities { get; set; }
        [Ignore]
        public Dictionary<string, string> Statuses { get; set; }

        public string GetCenterId()
        {
            return Id;
        }
    }
    // 상품에 대한 공통정보
    [NotMapped]
    public class Commodity : Entity, IStorableInCenterMemory
    {
        public string? Quantity { get; set; }
        [Ignore]
        public string? CenterId { get; set; }

        public virtual string? GetCenterId()
        {
            return CenterId;
        }
    }
    [NotMapped]
    public class Status : Entity, IStorableInCenterMemory
    {
        public string? Quantity { get; set; }
        [Ignore]
        public string? CenterId { get; set; }
        public string? State { get; set; }

        public virtual string? GetCenterId()
        {
            return CenterId;
        }
    }
    [NotMapped]
    public class 문의
    {
        public string 내용 { get; set; }
        public string CenterId { get; set; }
        // 자식 댓글들
        public List<문의> 문의들 { get; set; }

        // 자식 댓글들을 JSON으로 직렬화하는 속성
        [NotMapped]
        public string 문의들Json
        {
            get => JsonConvert.SerializeObject(문의들);
            set => 문의들 = JsonConvert.DeserializeObject<List<문의>>(value);
        }
    }
}