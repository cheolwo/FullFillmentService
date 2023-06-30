using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 주문Common.Command
{
    public class Create주문완료Command : CreateCommand<Create주문완료DTO>, IRequest
    {
        public Create주문완료Command(Create주문완료DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Update주문완료Command : UpdateCommand<Update주문완료DTO>, IRequest
    {
        public Update주문완료Command(Update주문완료DTO t, string? jwtToken, 
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
    public class Delete주문완료Command : DeleteCommand<Delete주문완료DTO>, IRequest
    {
        public Delete주문완료Command(Delete주문완료DTO t, string? jwtToken,
            ServerSubject serverSubject, CommandOption? commandOption) : base(t, jwtToken, serverSubject, commandOption)
        {
        }
    }
}
