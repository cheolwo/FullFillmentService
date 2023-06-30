using Common.GateWay;
using Microsoft.Extensions.Configuration;
using 마켓Common.DTO;

namespace 마켓Common.GateWay
{
    public class 마켓GateWayQueryContext : GateWayQueryContext
    {
        public 마켓GateWayQueryContext(GateWayQueryBuilder gateWayQueryBuilder, IConfiguration configuration) 
            : base(gateWayQueryBuilder, configuration)
        {
        }

        protected override void OnModelCreating(GateWayQueryBuilder queryBuilder)
        {
            queryBuilder.ApplyConfiguration(new 마켓GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 마켓상품GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 협상대기GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 협상중GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 협상완료GateWayQueryConfiguration());
        }
    }
    public class 마켓GateWayQueryConfiguration : IGateWayQueryConfiguration<Read마켓DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read마켓DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 마켓상품GateWayQueryConfiguration : IGateWayQueryConfiguration<Read마켓상품DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read마켓상품DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 협상대기GateWayQueryConfiguration : IGateWayQueryConfiguration<Read협상대기DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read협상대기DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 협상중GateWayQueryConfiguration : IGateWayQueryConfiguration<Read협상중DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read협상중DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 협상완료GateWayQueryConfiguration : IGateWayQueryConfiguration<Read협상완료DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read협상완료DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
}
