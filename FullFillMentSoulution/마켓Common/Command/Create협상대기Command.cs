using Common.ForCommand;
using Common.GateWay;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 마켓Common.DTO;

namespace 마켓Common.Command
{
    public class Create협상대기Command : CreateCommand<Create협상대기DTO>, IRequest
    {
        public Create협상대기Command(Create협상대기DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update협상대기Command : UpdateCommand<Update협상대기DTO>, IRequest
    {
        public Update협상대기Command(Update협상대기DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete협상대기Command : DeleteCommand<Delete협상대기DTO>, IRequest
    {
        public Delete협상대기Command(Delete협상대기DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
