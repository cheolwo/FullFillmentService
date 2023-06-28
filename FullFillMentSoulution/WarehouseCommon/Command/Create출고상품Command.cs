using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 창고Common.DTO.출고상품;

namespace 창고Common.Command
{
    public class Create출고상품Command : CreateCommand<Create출고상품DTO>, IRequest<string>
    {
        public Create출고상품Command(Create출고상품DTO dto, CommandOption option)
        {
            t = dto;
            CommandOption = option;
        }
        public Create출고상품Command(Create출고상품DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            CommandOption = option;
            this.ServerSubject = serverSubject;
        }
    }
    public class Update출고상품Command : UpdateCommand<Update출고상품DTO>, IRequest<string>
    {
        public Update출고상품Command(Update출고상품DTO dto, CommandOption option)
        {
            t = dto;
            CommandOption = option;
        }
        public Update출고상품Command(Update출고상품DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            CommandOption = option;
            this.ServerSubject = serverSubject;
        }
    }
    public class Delete출고상품Command : DeleteCommand<Delete출고상품DTO>, IRequest<string>
    {
        public Delete출고상품Command(Delete출고상품DTO dto, CommandOption option)
        {
            t = dto;
            CommandOption = option;
        }
        public Delete출고상품Command(Delete출고상품DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            CommandOption = option;
            this.ServerSubject = serverSubject;
        }
    }
}
