using Common.ForCommand;
using Common.GateWay;
using MediatR;

using 주문Common.DTO.주문자;

namespace 주문Common.Command
{
    public class Create주문자Command : CreateCommand<Create주문자DTO>, IRequest
    {
        public Create주문자Command(Create주문자DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update주문자Command : UpdateCommand<Update주문자DTO>, IRequest
    {
        public Update주문자Command(Update주문자DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete주문자Command : DeleteCommand<Delete주문자DTO>, IRequest
    {
        public Delete주문자Command(Delete주문자DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
