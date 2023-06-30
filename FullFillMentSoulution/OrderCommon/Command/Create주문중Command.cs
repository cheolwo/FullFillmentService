using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 주문Common.DTO.주문중;

namespace 주문Common.Command
{
    public class Create주문중Command : CreateCommand<Create주문중DTO>, IRequest
    {
        public Create주문중Command(Create주문중DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update주문중Command : UpdateCommand<Update주문중DTO>, IRequest
    {
        public Update주문중Command(Update주문중DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete주문중Command : DeleteCommand<Delete주문중DTO>, IRequest
    {
        public Delete주문중Command(Delete주문중DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
