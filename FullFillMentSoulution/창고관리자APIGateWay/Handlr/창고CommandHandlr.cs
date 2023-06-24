using Common.ForCommand;
using Common.GateWay;
using Common.GateWayCommand;
using Microsoft.AspNetCore.Identity;
using 창고Common.DTO.창고;

namespace 창고관리자APIGateWay.Handlr
{
    public class 창고CommandHandlr : GateWayCreateCommandHandler<Create창고DTO>
    {
        public 창고CommandHandlr(GateWayCommandContext context) : base(context)
        {
        }
        public override Task Handle(CreateCommand<Create창고DTO> request, CancellationToken cancellationToken)
        {
            return base.Handle(request, cancellationToken);
        }
    }
}
