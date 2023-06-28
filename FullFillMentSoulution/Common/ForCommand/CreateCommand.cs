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
        public T t  { get; set; }
        public string? jwtToken { get; set; }
        public ServerSubject ServerSubject { get; set; }
        public CommandOption? CommandOption { get; set; }
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
    public class ReadQuery<TDTO> : IRequest where T : ReadDto
    {
        public TDTO T { get; set; }
        public ServerSubject? ServerSubject { get; set; }
        public string JwtToken { get; set; }
        public ReadQuery(TDTO t, ServerSubject? serverSubject, string jwtToken)
        {
            T = t;
            ServerSubject = serverSubject;
            JwtToken = jwtToken;
        }
    }
}
