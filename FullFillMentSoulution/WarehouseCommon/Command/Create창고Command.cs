using Common.DTO;
using Common.ForCommand;
using Common.GateWay;
using Common.GateWayCommand;
using MediatR;
using 창고Common.DTO.입고상품;
using 창고Common.DTO.적재상품;
using 창고Common.DTO.창고;
using 창고Common.DTO.창고상품;
using 창고Common.DTO.출고상품;

namespace 창고Common.Command
{
    public class Create창고Command : CreateCommand<Create창고DTO>, IRequest<string>
    {
        public Create창고Command(Create창고DTO dto, CommandOption option)
        {
            t = dto;
            commandOption= option;
        }
    }
    public class Update창고Command : UpdateCommand<Update창고DTO>, IRequest<string>
    {
        public Update창고Command(Update창고DTO dto, CommandOption option)
        {
            t = dto;
            commandOption = option;
        }
    }
    public class Delete창고Command : DeleteCommand<Delete창고DTO>, IRequest<string>
    {
        public Delete창고Command(Delete창고DTO dto, CommandOption option)
        {
            t = dto;
            commandOption = option;
        }
    }
    public class Create입고상품CommandHandler : GateWayCreateCommandHandler<Create입고상품DTO>, IRequestHandler<Create입고상품Command, string>
    {
        public Create입고상품CommandHandler(GateWayCommandContext context) : base(context)
        {
        }

        public Task<string> Handle(Create입고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class Update입고상품CommandHandler : GateWayUpdateCommandHandler<Create입고상품DTO>, IRequestHandler<Update입고상품Command, string>
    {
        public Update입고상품CommandHandler(GateWayCommandContext context) : base(context)
        {
        }

        public Task<string> Handle(Update입고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class Delete입고상품CommandHandler : GateWayDeleteCommandHandler<Create입고상품DTO>, IRequestHandler<Delete입고상품Command, string>
    {
        public Delete입고상품CommandHandler(GateWayCommandContext context) : base(context)
        {
        }

        public Task<string> Handle(Delete입고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    // 적재상품
    public class Create적재상품CommandHandler : GateWayCreateCommandHandler<Create적재상품DTO>, IRequestHandler<Create적재상품Command, string>
    {
        public Create적재상품CommandHandler(GateWayCommandContext context) : base(context)
        {
        }

        public Task<string> Handle(Create적재상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class Update적재상품CommandHandler : GateWayUpdateCommandHandler<Create적재상품DTO>, IRequestHandler<Update적재상품Command, string>
    {
        public Update적재상품CommandHandler(GateWayCommandContext context) : base(context)
        {
        }

        public Task<string> Handle(Update적재상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class Delete적재상품CommandHandler : GateWayDeleteCommandHandler<Create적재상품DTO>, IRequestHandler<Delete적재상품Command, string>
    {
        public Delete적재상품CommandHandler(GateWayCommandContext context) : base(context)
        {
        }

        public Task<string> Handle(Delete적재상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    // 창고상품
    public class Create창고상품CommandHandler : GateWayCreateCommandHandler<Create창고상품DTO>, IRequestHandler<Create창고상품Command, string>
    {
        public Create창고상품CommandHandler(GateWayCommandContext context) : base(context)
        {
        }

        public Task<string> Handle(Create창고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class Update창고상품CommandHandler : GateWayUpdateCommandHandler<Create창고상품DTO>, IRequestHandler<Update창고상품Command, string>
    {
        public Update창고상품CommandHandler(GateWayCommandContext context) : base(context)
        {
        }

        public Task<string> Handle(Update창고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class Delete창고상품CommandHandler : GateWayDeleteCommandHandler<Create창고상품DTO>, IRequestHandler<Delete창고상품Command, string>
    {
        public Delete창고상품CommandHandler(GateWayCommandContext context) : base(context)
        {
        }

        public Task<string> Handle(Delete창고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    // 출고상품
    public class Create출고상품CommandHandler : GateWayCreateCommandHandler<Create출고상품DTO>, IRequestHandler<Create출고상품Command, string>
    {
        public Create출고상품CommandHandler(GateWayCommandContext context) : base(context)
        {
        }

        public Task<string> Handle(Create출고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class Update출고상품CommandHandler : GateWayUpdateCommandHandler<Create출고상품DTO>, IRequestHandler<Update출고상품Command, string>
    {
        public Update출고상품CommandHandler(GateWayCommandContext context) : base(context)
        {
        }

        public Task<string> Handle(Update출고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete출고상품CommandHandler : GateWayDeleteCommandHandler<Create출고상품DTO>, IRequestHandler<Delete출고상품Command, string>
    {
        public Delete출고상품CommandHandler(GateWayCommandContext context) : base(context)
        {
        }

        public Task<string> Handle(Delete출고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
