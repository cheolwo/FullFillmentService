using Common.GateWay;
using Microsoft.Extensions.Configuration;
using 주문Common.DTO.주문대기;
using 주문Common.DTO.주문상품;
using 주문Common.DTO.주문완료;
using 주문Common.DTO.주문자;
using 주문Common.DTO.주문중;

namespace 주문Common.GateWay
{
    public class 주문GateWayQueryContext : GateWayQueryContext
    {
        public 주문GateWayQueryContext(GateWayQueryBuilder gateWayQueryBuilder, IConfiguration configuration) 
            : base(gateWayQueryBuilder, configuration)
        {
        }

        protected override void OnModelCreating(GateWayQueryBuilder queryBuilder)
        {
            queryBuilder.ApplyConfiguration(new 주문자GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 주문상품GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 주문대기GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 주문중GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 주문완료GateWayQueryConfiguration());
        }
    }
    public class 주문자GateWayQueryConfiguration : IGateWayQueryConfiguration<Read주문자DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read주문자DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 주문상품GateWayQueryConfiguration : IGateWayQueryConfiguration<Read주문상품DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read주문상품DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 주문대기GateWayQueryConfiguration : IGateWayQueryConfiguration<Read주문대기DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read주문대기DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 주문중GateWayQueryConfiguration : IGateWayQueryConfiguration<Read주문중DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read주문중DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 주문완료GateWayQueryConfiguration : IGateWayQueryConfiguration<Read주문완료DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read주문완료DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
}
