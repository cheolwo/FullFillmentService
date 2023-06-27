using Common.DTO;
using Common.GateWay;
using MediatR;

namespace Common.ForCommand
{
    [Serializable]
    public class CommandOption
    {
        public string NameofCommand { get; set; }
        public List<string> Options { get; set; }
    }

    public class CudCommand<T> : IRequest where T : CudDTO
    {
        public T t { get; set; }
        public ServerSubject serverSubject { get; set; }
        public CommandOption commandOption { get; set; }
    }
    public class CreateCommand<T> : CudCommand<T>, IRequest where T : CudDTO
    {
    }

    public class UpdateCommand<T> : CudCommand<T>, IRequest where T : CudDTO
    {
    }   

    public class DeleteCommand<T> : CudCommand<T>, IRequest where T : CudDTO
    {
    }
}