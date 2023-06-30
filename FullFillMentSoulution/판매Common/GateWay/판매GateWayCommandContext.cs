using Common.GateWay;
using Microsoft.Extensions.Configuration;
using 판매Common.DTO.DetailDTO;

namespace 판매Common.GateWay
{
    public class 판매GateWayCommandContext : GateWayCommandContext
    {
        public 판매GateWayCommandContext(GateWayCommandBuilder commandBuilder, IConfiguration configuration)
            : base(commandBuilder, configuration)
        {
        }

        protected override void OnModelCreating(GateWayCommandBuilder commandBuilder)
        {
            commandBuilder.ApplyConfiguration(new 판매자GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 판매자상품GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 판매대기GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 판매중GateWayCommandConfiguration());
            commandBuilder.ApplyConfiguration(new 판매완료GateWayCommandConfiguration());
        }
    }
    public class 판매자GateWayCommandConfiguration : IGateWayCommandConfiguration<판매자CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<판매자CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 판매자상품GateWayCommandConfiguration : IGateWayCommandConfiguration<판매자상품CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<판매자상품CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 판매대기GateWayCommandConfiguration : IGateWayCommandConfiguration<판매대기CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<판매대기CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 판매중GateWayCommandConfiguration : IGateWayCommandConfiguration<판매중CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<판매중CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 판매완료GateWayCommandConfiguration : IGateWayCommandConfiguration<판매완료CudDTO>
    {
        public void Configure(GateWayCommandTypeBuilder<판매완료CudDTO> builder)
        {
            throw new NotImplementedException();
        }
    }
}
