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
    public class Create마켓상품Command : CreateCommand<Create마켓상품DTO>, IRequest
    {
        public Create마켓상품Command(Create마켓상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update마켓상품Command : UpdateCommand<Update마켓상품DTO>, IRequest
    {
        public Update마켓상품Command(Update마켓상품DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete마켓상품Command : DeleteCommand<Delete마켓상품DTO>, IRequest
    {
        public Delete마켓상품Command(Delete마켓상품DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
