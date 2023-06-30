using Common.GateWay;
using Microsoft.Extensions.Configuration;
using 창고Common.DTO.입고상품;
using 창고Common.DTO.적재상품;
using 창고Common.DTO.창고;
using 창고Common.DTO.창고상품;
using 창고Common.DTO.출고상품;

namespace 창고Common.GateWay
{
    public class 창고GateWayQueryContext : GateWayQueryContext
    {
        public 창고GateWayQueryContext(GateWayQueryBuilder gateWayQueryBuilder, IConfiguration configuration) 
            : base(gateWayQueryBuilder, configuration)
        {
        }

        protected override void OnModelCreating(GateWayQueryBuilder queryBuilder)
        {
            queryBuilder.ApplyConfiguration(new 창고GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 창고상품GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 입고상품GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 적재상품GateWayQueryConfiguration());
            queryBuilder.ApplyConfiguration(new 출고상품GateWayQueryConfiguration());
        }
    }
    public class 창고GateWayQueryConfiguration : IGateWayQueryConfiguration<Read창고DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read창고DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 창고상품GateWayQueryConfiguration : IGateWayQueryConfiguration<Read창고상품DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read창고상품DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 입고상품GateWayQueryConfiguration : IGateWayQueryConfiguration<Read입고상품DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read입고상품DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 적재상품GateWayQueryConfiguration : IGateWayQueryConfiguration<Read적재상품DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read적재상품DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class 출고상품GateWayQueryConfiguration : IGateWayQueryConfiguration<Read출고상품DTO>
    {
        public void Configure(GateWayQueryTypeBuilder<Read출고상품DTO> builder)
        {
            throw new NotImplementedException();
        }
    }
}
