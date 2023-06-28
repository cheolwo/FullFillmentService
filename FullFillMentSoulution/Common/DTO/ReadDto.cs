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
}
