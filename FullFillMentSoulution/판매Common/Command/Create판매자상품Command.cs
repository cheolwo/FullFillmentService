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
    public class Create판매자상품Command : CreateCommand<Create판매자상품DTO>, IRequest
    {
        public Create판매자상품Command(Create판매자상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update판매자상품Command : UpdateCommand<Update판매자상품DTO>, IRequest
    {
        public Update판매자상품Command(Update판매자상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete판매자상품Command : DeleteCommand<Delete판매자상품DTO>, IRequest
    {
        public Delete판매자상품Command(Delete판매자상품DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
