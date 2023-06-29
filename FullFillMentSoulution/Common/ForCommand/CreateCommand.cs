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

    public class CudCommand<T> : IRequest where T : class
    {
        public T t  { get; set; }
        public string? JwtToken { get; set; }
        public ServerSubject ServerSubject { get; set; }
        public CommandOption? CommandOption { get; set; }
        public CudCommand(T t, string? jwtToken, ServerSubject serverSubject, CommandOption? commandOption)
        {
            this.t = t;
            JwtToken = jwtToken;
            ServerSubject = serverSubject;
            CommandOption = commandOption;
        }
    }
    public class CreateCommand<T> : CudCommand<T>, IRequest where T : class
    {
        public CreateCommand(T t, string? jwtToken, ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }

    public class UpdateCommand<T> : CudCommand<T>, IRequest where T : class
    {
        public UpdateCommand(T t, string? jwtToken, ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }

    public class DeleteCommand<T> : CudCommand<T>, IRequest where T : class
    {   
        public DeleteCommand(T t, string? jwtToken, ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class ReadQuery<T> : IRequest where T : class
    {
        public T t { get; set; }
        public ServerSubject? ServerSubject { get; set; }
        public string JwtToken { get; set; }
        public ReadQuery(T t, ServerSubject? serverSubject, string jwtToken)
        {
            this.t = t;
            ServerSubject = serverSubject;
            JwtToken = jwtToken;
        }
    }
}
