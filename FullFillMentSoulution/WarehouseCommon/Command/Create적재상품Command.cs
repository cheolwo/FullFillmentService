using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 창고Common.DTO.적재상품;

namespace 창고Common.Command
{
    public class Create적재상품Command : CreateCommand<Create적재상품DTO>, IRequest<string>
    {
        public Create적재상품Command(Create적재상품DTO dto, CommandOption option)
        {
            t = dto;
            commandOption = option;
        }
        public Create적재상품Command(Create적재상품DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            commandOption = option;
            this.serverSubject = serverSubject;
        }
    }
    public class Update적재상품Command : UpdateCommand<Update적재상품DTO>, IRequest<string>
    {
        public Update적재상품Command(Update적재상품DTO dto, CommandOption option)
        {
            t = dto;
            commandOption = option;
        }
        public Update적재상품Command(Update적재상품DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            commandOption = option;
            this.serverSubject = serverSubject;
        }
    }
    public class Delete적재상품Command : DeleteCommand<Delete적재상품DTO>, IRequest<string>
    {
        public Delete적재상품Command(Delete적재상품DTO dto, CommandOption option)
        {
            t = dto;
            commandOption = option;
        }
        public Delete적재상품Command(Delete적재상품DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            commandOption = option;
            this.serverSubject = serverSubject;
        }
    }
}
