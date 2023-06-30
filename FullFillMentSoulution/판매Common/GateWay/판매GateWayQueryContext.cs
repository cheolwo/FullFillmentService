using Common.GateWay;
using Microsoft.Extensions.Configuration;
using 판매Common.DTO;

namespace 판매Common.GateWay
{
    public class 판매GateWayQueryContext : GateWayQueryContext
    {
        public 판매GateWayQueryContext(GateWayQueryBuilder gateWayQueryBuilder, IConfiguration configuration) 
            : base(gateWayQueryBuilder, configuration)
        {
        }

        protected override void OnModelCreating(GateWayQueryBuilder queryBuilder)
        {
            queryBuilder.ApplyConfiguration(new 판매자GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 판매자상품GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 판매대기GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 판매중GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 판매완료GateWayQueryConfiguration());
        }
    }
    public class 판매자GateWayQueryConfiguration : IGateWayQueryConfiguration<Read판매자DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read판매자DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 판매자상품GateWayQueryConfiguration : IGateWayQueryConfiguration<Read판매자DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read판매자DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 판매대기GateWayQueryConfiguration : IGateWayQueryConfiguration<Read판매대기DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read판매대기DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 판매중GateWayQueryConfiguration : IGateWayQueryConfiguration<Read판매중DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read판매중DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 판매완료GateWayQueryConfiguration : IGateWayQueryConfiguration<Read판매완료DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read판매완료DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
}
