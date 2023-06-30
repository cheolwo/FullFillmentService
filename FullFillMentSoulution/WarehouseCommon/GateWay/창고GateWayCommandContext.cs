using Common.GateWay;
using Microsoft.Extensions.Configuration;
using 창고Common.DTO;

namespace 창고Common.GateWay
{
    public class 창고GateWayCommandContext : GateWayCommandContext
    {
        public 창고GateWayCommandContext(GateWayCommandBuilder commandBuilder, IConfiguration configuration) 
            : base(commandBuilder, configuration)
        {
        }

        protected override void OnModelCreating(GateWayCommandBuilder commandBuilder)
        {
            commandBuilder.ApplyConfiguration(new 창고GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 창고상품GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 입고상품GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 적재상품GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 출고상품GateWayCommandConfiguration());
        }
    }
    public class 창고GateWayCommandConfiguration : IGateWayCommandConfiguration<창고CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<창고CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 창고상품GateWayCommandConfiguration : IGateWayCommandConfiguration<창고상품CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<창고상품CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 입고상품GateWayCommandConfiguration : IGateWayCommandConfiguration<입고상품CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<입고상품CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 적재상품GateWayCommandConfiguration : IGateWayCommandConfiguration<적재상품CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<적재상품CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 출고상품GateWayCommandConfiguration : IGateWayCommandConfiguration<출고상품CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<출고상품CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
}
