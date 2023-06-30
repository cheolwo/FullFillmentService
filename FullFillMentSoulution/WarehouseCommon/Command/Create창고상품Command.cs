using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 창고Common.DTO.창고상품;

namespace 창고Common.Command
{
    public class Create창고상품Command : CreateCommand<Create창고상품DTO>, IRequest
    {
        public Create창고상품Command(Create창고상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update창고상품Command : UpdateCommand<Update창고상품DTO>, IRequest
    {
        public Update창고상품Command(Update창고상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete창고상품Command : DeleteCommand<Delete창고상품DTO>, IRequest
    {
        public Delete창고상품Command(Delete창고상품DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
