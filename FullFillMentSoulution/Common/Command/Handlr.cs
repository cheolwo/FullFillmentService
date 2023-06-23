using Common.DTO;
using MediatR;

namespace Common.Command
{
    public class CreateCommandHandler<T> : IRequestHandler<CreateCommand<T>, T> where T : CudDTO
{
    private readonly GateWayContext _gateWayContext;

    public CreateCommandHandler(GateWayContext gateWayContext)
    {
        _gateWayContext = gateWayContext;
    }

    public async Task<T> Handle(CreateCommand<T> request, CancellationToken cancellationToken)
    {
        // Perform create logic based on the provided request.Model using GateWayContext
        // ...
        
        throw new System.NotImplementedException();
    }
}

public class UpdateCommandHandler<T> : IRequestHandler<UpdateCommand<T>, T> where T : CudDTO
{
    private readonly GateWayContext _gateWayContext;

    public UpdateCommandHandler(GateWayContext gateWayContext)
    {
        _gateWayContext = gateWayContext;
    }

    public async Task<T> Handle(UpdateCommand<T> request, CancellationToken cancellationToken)
    {
        // Perform update logic based on the provided request.Id and request.Model using GateWayContext
        // ...
        
        throw new System.NotImplementedException();
    }
}

public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
{
    private readonly GateWayContext _gateWayContext;

    public DeleteCommandHandler(GateWayContext gateWayContext)
    {
        _gateWayContext = gateWayContext;
    }

    public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        // Perform delete logic based on the provided request.Id using GateWayContext
        // ...
        
        throw new System.NotImplementedException();
    }
}
}