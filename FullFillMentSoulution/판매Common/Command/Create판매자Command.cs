using Common.ForCommand;
using Common.GateWay;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 판매Common.DTO;

namespace 판매Common.Command
{
    public class Create판매자Command : CreateCommand<Create판매자DTO>, IRequest
    {
        public Create판매자Command(Create판매자DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update판매자Command : UpdateCommand<Update판매자DTO>, IRequest
    {
        public Update판매자Command(Update판매자DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete판매자Command : DeleteCommand<Delete판매자DTO>, IRequest
    {
        public Delete판매자Command(Delete판매자DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
