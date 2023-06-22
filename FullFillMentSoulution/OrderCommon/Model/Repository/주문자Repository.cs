using Common.Model.Repository;
using OrderCommon.Model;
using 주문Common.Model;

namespace 주문Common.Model.Repository
{
    public interface I주문자QueryRepository : ICenterQueryRepository<주문자>
    {
    }
    public interface I주문상품QueryRepository : IEntityQueryRepository<주문상품>
    {
    }
    public interface I주문대기QueryRepository : IStatusQueryRepository<주문대기>
    {
    }
    public interface I주문중QueryRepository : IStatusQueryRepository<주문중>
    {
    }
    public interface I주문완료QueryRepository : IStatusQueryRepository<주문완료>
    {
    }
    public class 주문자Repository : CenterRepository<주문자>, I주문자QueryRepository
    {
        public 주문자Repository(주문DbContext context) : base(context)
        {
        }
    }
    public class 주문상품Repositroy : EntityRepository<주문상품>, I주문상품QueryRepository
    {
        public 주문상품Repositroy(주문DbContext context) : base(context)
        {
        }
    }
    public class 주문대기Repositroy : StatusRepository<주문대기>, I주문대기QueryRepository
    {
        public 주문대기Repositroy(주문DbContext context) : base(context)
        {
        }
    }
    public class 주문중Repositroy : StatusRepository<주문중>, I주문중QueryRepository
    {
        public 주문중Repositroy(주문DbContext context) : base(context)
        {
        }
    }
    public class 주문완료Repositroy : StatusRepository<주문완료>, I주문완료QueryRepository
    {
        public 주문완료Repositroy(주문DbContext context) : base(context)
        {
        }
    }
}
