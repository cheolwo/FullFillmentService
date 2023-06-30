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
    public class Create협상중Command : CreateCommand<Create협상중DTO>, IRequest
    {
        public Create협상중Command(Create협상중DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update협상중Command : UpdateCommand<Update협상중DTO>, IRequest
    {
        public Update협상중Command(Update협상중DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete협상중Command : DeleteCommand<Delete협상중DTO>, IRequest
    {
        public Delete협상중Command(Delete협상중DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
