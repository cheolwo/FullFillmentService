using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 판매Common.DTO;

namespace 판매Common.Command
{
    public class Create판매대기Command : CreateCommand<Create판매자DTO>, IRequest
    {
        public Create판매대기Command(Create판매자DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update판매대기Command : UpdateCommand<Update판매자DTO>, IRequest
    {
        public Update판매대기Command(Update판매자DTO t, string? jwtToken, ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete판매대기Command : DeleteCommand<Delete판매대기DTO>, IRequest
    {
        public Delete판매대기Command(Delete판매대기DTO t, string? jwtToken, ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
