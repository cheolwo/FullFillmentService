using Common.GateWay;
using 창고Common.DTO.입고상품;
using 창고Common.DTO.적재상품;
using 창고Common.DTO.창고;
using 창고Common.DTO.창고상품;
using 창고Common.DTO.출고상품;

namespace 창고관리자APIGateWay.GateWayContext
{
    public class 창고관리GateWayCommandContext : GateWayCommandContext
    {
        public 창고관리GateWayCommandContext(IConfiguration configuration, GateWayCommandContextOptions options)
            : base(configuration, options)
        {
        }

        protected override void OnModelCreating(GateWayCommandBuilder commandBuilder)
        {
            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Create창고DTO>)new 창고GateWayCommandConfiguration(_configuration));
            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Update창고DTO>)new 창고GateWayCommandConfiguration(_configuration));
            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Delete창고DTO>)new 창고GateWayCommandConfiguration(_configuration));

            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Create창고상품DTO>)new 창고상품GateWayCommandConfiguration(_configuration));
            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Update창고상품DTO>)new 창고상품GateWayCommandConfiguration(_configuration));
            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Delete창고상품DTO>)new 창고상품GateWayCommandConfiguration(_configuration));

            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Create입고상품DTO>)new 입고상품GateWayCommandConfiguration(_configuration));
            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Update입고상품DTO>)new 입고상품GateWayCommandConfiguration(_configuration));
            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Delete입고상품DTO>)new 입고상품GateWayCommandConfiguration(_configuration));

            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Create적재상품DTO>)new 적재상품GateWayCommandConfiguration(_configuration));
            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Update적재상품DTO>)new 적재상품GateWayCommandConfiguration(_configuration));
            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Delete적재상품DTO>)new 적재상품GateWayCommandConfiguration(_configuration));

            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Create출고상품DTO>)new 출고상품GateWayCommandConfiguration(_configuration));
            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Update출고상품DTO>)new 출고상품GateWayCommandConfiguration(_configuration));
            commandBuilder.ApplyConfiguration((IGateWayCommandConfiguration<Delete출고상품DTO>)new 출고상품GateWayCommandConfiguration(_configuration));
        }
    }
    public class 창고GateWayCommandConfiguration :
                    IGateWayCommandConfiguration<Create창고DTO>,
                    IGateWayCommandConfiguration<Update창고DTO>,
                    IGateWayCommandConfiguration<Delete창고DTO>
    {
        private readonly IConfiguration _configuration;

        public 창고GateWayCommandConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(GateWayCommandTypeBuilder<Create창고DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }

        public void Configure(GateWayCommandTypeBuilder<Update창고DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }

        public void Configure(GateWayCommandTypeBuilder<Delete창고DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }
    }

    public class 창고상품GateWayCommandConfiguration :
                        IGateWayCommandConfiguration<Create창고상품DTO>,
                        IGateWayCommandConfiguration<Update창고상품DTO>,
                        IGateWayCommandConfiguration<Delete창고상품DTO>
    {
        private readonly IConfiguration _configuration;

        public 창고상품GateWayCommandConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(GateWayCommandTypeBuilder<Create창고상품DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ?? 
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }

        public void Configure(GateWayCommandTypeBuilder<Update창고상품DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }

        public void Configure(GateWayCommandTypeBuilder<Delete창고상품DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }
    }

    public class 입고상품GateWayCommandConfiguration :
                        IGateWayCommandConfiguration<Create입고상품DTO>,
                        IGateWayCommandConfiguration<Update입고상품DTO>,
                        IGateWayCommandConfiguration<Delete입고상품DTO>
    {
        private readonly IConfiguration _configuration;

        public 입고상품GateWayCommandConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(GateWayCommandTypeBuilder<Create입고상품DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }

        public void Configure(GateWayCommandTypeBuilder<Update입고상품DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }

        public void Configure(GateWayCommandTypeBuilder<Delete입고상품DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }
    }

    public class 적재상품GateWayCommandConfiguration :
                        IGateWayCommandConfiguration<Create적재상품DTO>,
                        IGateWayCommandConfiguration<Update적재상품DTO>,
                        IGateWayCommandConfiguration<Delete적재상품DTO>
    {
        private readonly IConfiguration _configuration;

        public 적재상품GateWayCommandConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(GateWayCommandTypeBuilder<Create적재상품DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }

        public void Configure(GateWayCommandTypeBuilder<Update적재상품DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }

        public void Configure(GateWayCommandTypeBuilder<Delete적재상품DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }
    }

    public class 출고상품GateWayCommandConfiguration :
                        IGateWayCommandConfiguration<Create출고상품DTO>,
                        IGateWayCommandConfiguration<Update출고상품DTO>,
                        IGateWayCommandConfiguration<Delete출고상품DTO>
    {
        private readonly IConfiguration _configuration;

        public 출고상품GateWayCommandConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(GateWayCommandTypeBuilder<Create출고상품DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }

        public void Configure(GateWayCommandTypeBuilder<Update출고상품DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }

        public void Configure(GateWayCommandTypeBuilder<Delete출고상품DTO> builder)
        {
            builder.SetRabbitMqConnection(_configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("RabbitMQConnectionString")));
            builder.SetGateWay(_configuration.GetConnectionString("GateWayServerUrl") ??
                throw new ArgumentNullException(_configuration.GetConnectionString("GateWayServerUrl")));
        }
    }
}
