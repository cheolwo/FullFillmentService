using Common.ForCommand;
using MediatR;
using 창고Common.DTO.창고상품;

namespace 창고Common.Command
{
    public class Create창고상품Command : CreateCommand<Create창고상품DTO>, IRequest<string>
    {
    }
    public class Update창고상품Command : UpdateCommand<Update창고상품DTO>, IRequest<string>
    {
    }
    public class Delete창고상품Command : DeleteCommand<Delete창고상품DTO>, IRequest<string>
    {
    }
}
