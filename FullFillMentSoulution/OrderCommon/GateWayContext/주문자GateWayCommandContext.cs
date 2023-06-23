using Common.GateWay;
using 주문Common.DTO.For주문;

namespace 주문Common.GateWay
{
    public class 주문자GateWayCommandContext : GateWayCommandContext
    {
        public 주문자GateWayCommandContext(GateWayCommandContextOptions options)
                : base(options)
        {

        }
        protected override void OnModelCreating(GateWayCommandBuilder commandBuilder)
        {
            base.OnModelCreating(commandBuilder);
        }
    }
    public class GateWayCreate주문Configuration : IGateWayCommandConfiguration<Create주문DTO>
    {
        public void Configure(GateWayCommandTypeBuilder<Create주문DTO> builder)
        {
            //builder.SetQue(new Create주문DtoValidator());
        }
    }
}