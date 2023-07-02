using AutoMapper.Configuration.Annotations;

namespace Common.DTO
{
    public interface IStoreableInMemory
    {
        string GetId();
    }
    public class ReadDto : IStoreableInMemory
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set;}

        public string GetId()
        {
            if (Id == null) throw new ArgumentNullException(nameof(Id));
            return Id;
        }
    }
    public class ReadCenterDTO : ReadDto
    {
        public string? UserId { get; set; }
        public string? FaxNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
    }
    public class ReadCommodityDTO : ReadDto
    {
        public string? Quantity { get; set; }
        [Ignore]
        public string? CenterId { get; set; }
    }
    public class ReadStatusDTO : ReadDto
    {
        public string? Quantity { get; set; }
        [Ignore]
        public string? CenterId { get; set; }
        public string? State { get; set; }
    }
}
