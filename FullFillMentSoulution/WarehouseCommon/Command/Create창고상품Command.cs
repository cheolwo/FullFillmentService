using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 창고Common.DTO.창고상품;

namespace 창고Common.Command
{
    public class Create창고상품Command : CreateCommand<Create창고상품DTO>, IRequest<string>
    {
        public Create창고상품Command(Create창고상품DTO dto, CommandOption option)
        {
            t = dto;
            CommandOption = option;
        }
        public Create창고상품Command(Create창고상품DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            CommandOption = option;
            this.ServerSubject = serverSubject;
        }
    }
    public class Update창고상품Command : UpdateCommand<Update창고상품DTO>, IRequest<string>
    {
        public Update창고상품Command(Update창고상품DTO dto, CommandOption option)
        {
            t = dto;
            CommandOption = option;
        }
        public Update창고상품Command(Update창고상품DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            CommandOption = option;
            this.ServerSubject = serverSubject;
        }
    }
    public class Delete창고상품Command : DeleteCommand<Delete창고상품DTO>, IRequest<string>
    {
        public Delete창고상품Command(Delete창고상품DTO dto, CommandOption option)
        {
            t = dto;
            CommandOption = option;
        }
        public Delete창고상품Command(Delete창고상품DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            CommandOption = option;
            this.ServerSubject = serverSubject;
        }
    }
}
