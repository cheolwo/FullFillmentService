using Common.DTO;
using Common.ForCommand;
using MediatR;
using 창고Common.DTO.창고;

namespace 창고Common.Command
{
    public class Create창고Command : CreateCommand<Create창고DTO>, IRequest<string>
    {
    }
    public class Update창고Command : UpdateCommand<Update창고DTO>, IRequest<string>
    {
    }
    public class Delete창고Command : DeleteCommand<Delete창고DTO>, IRequest<string>
    {
    }
}
