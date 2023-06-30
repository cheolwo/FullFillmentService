using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 판매Common.DTO;

namespace 판매Common.Command
{
    public class Create판매완료Command : CreateCommand<Create판매완료DTO>, IRequest
    {
        public Create판매완료Command(Create판매완료DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update판매완료Command : UpdateCommand<Update판매완료DTO>, IRequest
    {
        public Update판매완료Command(Update판매완료DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete판매완료Command : DeleteCommand<Delete판매완료DTO>, IRequest
    {
        public Delete판매완료Command(Delete판매완료DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
