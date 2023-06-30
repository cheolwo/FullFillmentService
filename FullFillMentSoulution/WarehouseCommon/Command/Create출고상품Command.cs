using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 창고Common.DTO.출고상품;

namespace 창고Common.Command
{
    public class Create출고상품Command : CreateCommand<Create출고상품DTO>, IRequest
    {
        public Create출고상품Command(Create출고상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update출고상품Command : UpdateCommand<Update출고상품DTO>, IRequest
    {
        public Update출고상품Command(Update출고상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete출고상품Command : DeleteCommand<Delete출고상품DTO>, IRequest
    {
        public Delete출고상품Command(Delete출고상품DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
