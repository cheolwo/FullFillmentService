using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 주문Common.DTO.주문상품;

namespace 주문Common.Command
{
    public class Create주문상품Command : CreateCommand<Create주문상품DTO>, IRequest
    {
        public Create주문상품Command(Create주문상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update주문상품Command : UpdateCommand<Update주문상품DTO>, IRequest
    {
        public Update주문상품Command(Update주문상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete주문상품Command : DeleteCommand<Delete주문상품DTO>, IRequest
    {
        public Delete주문상품Command(Delete주문상품DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
