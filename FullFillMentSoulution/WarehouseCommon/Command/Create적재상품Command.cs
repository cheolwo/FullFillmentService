using Common.ForCommand;
using MediatR;
using 창고Common.DTO.적재상품;

namespace 창고Common.Command
{
    public class Create적재상품Command : CreateCommand<Create적재상품DTO>, IRequest<string>
    {
    }
    public class Update적재상품Command : UpdateCommand<Update적재상품DTO>, IRequest<string>
    {
    }
    public class Delete적재상품Command : DeleteCommand<Delete적재상품DTO>, IRequest<string>
    {
    }
}
