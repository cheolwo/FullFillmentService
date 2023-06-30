using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 창고Common.DTO.입고상품;

namespace 창고Common.CreateCommand
{
    public class Create입고상품Command : CreateCommand<Create입고상품DTO>, IRequest
    {
        public Create입고상품Command(Create입고상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update입고상품Command : UpdateCommand<Update입고상품DTO>, IRequest
    {
        public Update입고상품Command(Update입고상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete입고상품Command : DeleteCommand<Delete입고상품DTO>, IRequest
    {
        public Delete입고상품Command(Delete입고상품DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
