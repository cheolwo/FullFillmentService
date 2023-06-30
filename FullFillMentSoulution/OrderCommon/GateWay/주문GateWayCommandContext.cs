using Common.GateWay;
using Microsoft.Extensions.Configuration;
using 주문Common.DTO;

namespace 주문Common.GateWay
{
    public class 주문GateWayCommandContext : GateWayCommandContext
    {
        public 주문GateWayCommandContext(GateWayCommandBuilder commandBuilder, IConfiguration configuration) 
            : base(commandBuilder, configuration)
        {
        }

        protected override void OnModelCreating(GateWayCommandBuilder commandBuilder)
        {
            commandBuilder.ApplyConfiguration(new 주문자GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 주문상품GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 주문대기GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 주문중GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 주문완료GateWayCommandConfiguration());
        }
    }
    public class 주문자GateWayCommandConfiguration : IGateWayCommandConfiguration<주문자CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<주문자CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 주문상품GateWayCommandConfiguration : IGateWayCommandConfiguration<주문상품CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<주문상품CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 주문대기GateWayCommandConfiguration : IGateWayCommandConfiguration<주문대기CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<주문대기CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 주문중GateWayCommandConfiguration : IGateWayCommandConfiguration<주문중CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<주문중CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 주문완료GateWayCommandConfiguration : IGateWayCommandConfiguration<주문완료CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<주문완료CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
}
