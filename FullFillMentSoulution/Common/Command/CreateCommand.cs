using Common.DTO;
using MediatR;

namespace Common.Command
{
    public class CreateCommand<T> : IRequest<T> where T : CudDTO
    {
        public T Model { get; set; }
    }

    public class UpdateCommand<T> : IRequest<T> where T : CudDTO
    {
        public string Id { get; set; }
        public T Model { get; set; }
    }   

    public class DeleteCommand : IRequest
    {
        public string Id { get; set; }
    }
}
