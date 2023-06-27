using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 창고Common.DTO.입고상품;

namespace 창고Common.CreateCommand
{
    public class Create입고상품Command : CreateCommand<Create입고상품DTO>, IRequest<string>
    {
        public Create입고상품Command(Create입고상품DTO dto, CommandOption option)
        {
            t = dto;
            commandOption = option;
        }
        public Create입고상품Command(Create입고상품DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            commandOption = option;
            this.serverSubject = serverSubject;
        }
    }
    public class Update입고상품Command : UpdateCommand<Update입고상품DTO>, IRequest<string>
    {
        public Update입고상품Command(Update입고상품DTO dto, CommandOption option)
        {
            t = dto;
            commandOption = option;
        }
        public Update입고상품Command(Update입고상품DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            commandOption = option;
            this.serverSubject = serverSubject;
        }
    }
    public class Delete입고상품Command : DeleteCommand<Delete입고상품DTO>, IRequest<string>
    {
        public Delete입고상품Command(Delete입고상품DTO dto, CommandOption option)
        {
            t = dto;
            commandOption = option;
        }
        public Delete입고상품Command(Delete입고상품DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            commandOption = option;
            this.serverSubject = serverSubject;
        }
    }
}
