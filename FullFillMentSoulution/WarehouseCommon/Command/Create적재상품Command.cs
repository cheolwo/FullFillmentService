using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 창고Common.DTO.적재상품;

namespace 창고Common.Command
{
    public class Create적재상품Command : CreateCommand<Create적재상품DTO>, IRequest
    {
        public Create적재상품Command(Create적재상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update적재상품Command : UpdateCommand<Update적재상품DTO>, IRequest
    {
        public Update적재상품Command(Update적재상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete적재상품Command : DeleteCommand<Delete적재상품DTO>, IRequest
    {
        public Delete적재상품Command(Delete적재상품DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
