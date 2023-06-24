using Common.DTO;
using Common.ForCommand;
using MediatR;
using 창고Common.DTO.입고상품;
using 창고Common.DTO.창고;

namespace 창고Common.Command
{
    public class Create입고상품Command : CreateCommand<Create입고상품DTO>, IRequest<string>
    {
    }
    public class Update입고상품Command : UpdateCommand<Create입고상품DTO>, IRequest<string>
    {
    }
    public class Delete입고상품Command : DeleteCommand<Create입고상품DTO>, IRequest<string>
    {
    }
}
