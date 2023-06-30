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
    public class Create협상완료Command : CreateCommand<Create협상완료DTO>, IRequest
    {
        public Create협상완료Command(Create협상완료DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update협상완료Command : UpdateCommand<Update협상완료DTO>, IRequest
    {
        public Update협상완료Command(Update협상완료DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete협상완료Command : DeleteCommand<Delete협상완료DTO>, IRequest
    {
        public Delete협상완료Command(Delete협상완료DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
