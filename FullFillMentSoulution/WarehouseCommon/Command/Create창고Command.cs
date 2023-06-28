using Common.ForCommand;
using Common.GateWay;
using MediatR;
using 창고Common.DTO.창고;

namespace 창고Common.Command
{
    public class Create창고Command : CreateCommand<Create창고DTO>, IRequest<string>
    {
        public Create창고Command(Create창고DTO dto, CommandOption option)
        {
            t = dto;
            CommandOption= option;
        }
        public Create창고Command(Create창고DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            CommandOption = option;
            this.ServerSubject = serverSubject;
        }
    }
    public class Update창고Command : UpdateCommand<Update창고DTO>, IRequest<string>
    {
        public Update창고Command(Update창고DTO dto, CommandOption option)
        {
            t = dto;
            CommandOption = option;
        }
        public Update창고Command(Update창고DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            CommandOption = option;
            this.ServerSubject = serverSubject;
        }
    }
    public class Delete창고Command : DeleteCommand<Delete창고DTO>, IRequest<string>
    {
        public Delete창고Command(Delete창고DTO dto, CommandOption option)
        {
            t = dto;
            CommandOption = option;
        }
        public Delete창고Command(Delete창고DTO dto, CommandOption option, ServerSubject serverSubject)
        {
            t = dto;
            CommandOption = option;
            this.ServerSubject = serverSubject;
        }
    }
}
