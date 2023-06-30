using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 창고Common.DTO.창고;

namespace 창고Common.Command
{
    public class Create창고Command : CreateCommand<Create창고DTO>, IRequest
    {
        public Create창고Command(Create창고DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update창고Command : UpdateCommand<Update창고DTO>, IRequest
    {
        public Update창고Command(Update창고DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete창고Command : DeleteCommand<Delete창고DTO>, IRequest
    {
        public Delete창고Command(Delete창고DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
