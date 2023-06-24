using Azure.Core;
using Common.Command;
using Common.DTO;
using Common.ForCommand;
using Common.GateWay;
using MediatR;

namespace Common.GateWayCommand
{
    public interface IGateWayCommandHandlr<T> where T : CudDTO
    {
        
    }
    public abstract class GateWayCommandHandler<T> where T : CudDTO
    {
        protected readonly GateWayCommandContext _context;

        public GateWayCommandHandler(GateWayCommandContext context)
        {
            _context = context;
        }
    }
    public class GateWayCreateCommandHandler<T> : GateWayCommandHandler<T>, IRequestHandler<CreateCommand<T>> where T : CudDTO
    {
        public GateWayCreateCommandHandler(GateWayCommandContext context)
            : base(context)
        {
        }
        public virtual async Task Handle(CreateCommand<T> request, CancellationToken cancellationToken)
        {
            await _context.Set<T>().Enqueue(request);
        }
    }

    public class GateWayUpdateCommandHandler<T> : IRequestHandler<UpdateCommand<T>> where T : CudDTO
    {
        private readonly GateWayCommandContext _context;

        public GateWayUpdateCommandHandler(GateWayCommandContext context)
        {
            _context = context;
        }

        public virtual async Task Handle(UpdateCommand<T> request, CancellationToken cancellationToken)
        {
            await _context.Set<T>().Enqueue(request);
        }
    }

    public class GateWayDeleteCommandHandler<T> : IRequestHandler<DeleteCommand<T>> where T : CudDTO
    {
        private readonly GateWayCommandContext _context;

        public GateWayDeleteCommandHandler(GateWayCommandContext context)
        {
            _context = context;
        }

        public virtual async Task Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
        {
            await _context.Set<T>().Enqueue(request);
        }
    }
}
