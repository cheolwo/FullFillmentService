using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 주문Common.DTO.주문대기;

namespace 주문Common.Command
{
    public class Create주문대기Command : CreateCommand<Create주문대기DTO>, IRequest
    {
        public Create주문대기Command(Create주문대기DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update주문대기Command : UpdateCommand<Update주문대기DTO>, IRequest
    {
        public Update주문대기Command(Update주문대기DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete주문대기Command : DeleteCommand<Delete주문대기DTO>, IRequest
    {
        public Delete주문대기Command(Delete주문대기DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
