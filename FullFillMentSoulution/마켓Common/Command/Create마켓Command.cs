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
    public class Create마켓Command : CreateCommand<Create마켓DTO>, IRequest
    {
        public Create마켓Command(Create마켓DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update마켓Command : UpdateCommand<Update마켓DTO>, IRequest
    {
        public Update마켓Command(Update마켓DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete마켓Command : DeleteCommand<Delete마켓DTO>, IRequest
    {
        public Delete마켓Command(Delete마켓DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
