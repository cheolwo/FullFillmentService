using Common.GateWay;
using Microsoft.Extensions.Configuration;
using 마켓Common.DTO;

namespace 마켓Common.GateWay
{
    public class 마켓GateWayCommandContext : GateWayCommandContext
    {
        public 마켓GateWayCommandContext(GateWayCommandBuilder commandBuilder, IConfiguration configuration) 
            : base(commandBuilder, configuration)
        {
        }

        protected override void OnModelCreating(GateWayCommandBuilder commandBuilder)
        {
            commandBuilder.ApplyConfiguration(new 마켓GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 마켓상품GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 협상대기GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 협상중GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 협상완료GateWayCommandConfiguration());
        }
    }
    public class 마켓GateWayCommandConfiguration : IGateWayCommandConfiguration<마켓CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<마켓CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 마켓상품GateWayCommandConfiguration : IGateWayCommandConfiguration<마켓상품CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<마켓상품CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 협상대기GateWayCommandConfiguration : IGateWayCommandConfiguration<협상대기CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<협상대기CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 협상중GateWayCommandConfiguration : IGateWayCommandConfiguration<협상중CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<협상중CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 협상완료GateWayCommandConfiguration : IGateWayCommandConfiguration<협상완료CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<협상완료CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
}
