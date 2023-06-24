using Common.ForCommand;
using MediatR;
using 창고Common.DTO.출고상품;

namespace 창고Common.Command
{
    public class Create출고상품Command : CreateCommand<Create출고상품DTO>, IRequest<string>
    {
    }
    public class Update출고상품Command : UpdateCommand<Update출고상품DTO>, IRequest<string>
    {
    }
    public class Delete출고상품Command : DeleteCommand<Delete출고상품DTO>, IRequest<string>
    {
    }
}
