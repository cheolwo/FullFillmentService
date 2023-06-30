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
    public class Create판매중Command : CreateCommand<Create판매중DTO>, IRequest
    {
        public Create판매중Command(Create판매중DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update판매중Command : UpdateCommand<Update판매중DTO>, IRequest
    {
        public Update판매중Command(Update판매중DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete판매중Command : DeleteCommand<Delete판매중DTO>, IRequest
    {
        public Delete판매중Command(Delete판매중DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
