using Common.Model.Repository;
using 마켓Common.Model;

namespace 마켓Common.Repository
{
    public interface I마켓QueryRepository : ICenterQueryRepository<마켓>
    {
    }
    public interface I마켓상품QueryRepository : IEntityQueryRepository<마켓상품>
    {
    }
    public interface I협상대기QueryRepository : IStatusQueryRepository<협상대기>
    {
    }
    public interface I협상중QueryRepository : IStatusQueryRepository<협상중>
    {
    }
    public interface I협상완료QueryRepository : IStatusQueryRepository<협상완료>
    {
    }
    public class 마켓Repository : CenterRepository<마켓>, I마켓QueryRepository
    {
        public 마켓Repository(마켓DbContext context) : base(context)
        {
        }
    }
    public class 마켓상품Repositroy : EntityRepository<마켓상품>, I마켓상품QueryRepository
    {
        public 마켓상품Repositroy(마켓DbContext context) : base(context)
        {
        }
    }
    public class 협상대기Repositroy : StatusRepository<협상대기>, I협상대기QueryRepository
    {
        public 협상대기Repositroy(마켓DbContext context) : base(context)
        {
        }
    }
    public class 협상중Repositroy : StatusRepository<협상중>, I협상중QueryRepository
    {
        public 협상중Repositroy(마켓DbContext context) : base(context)
        {
        }
    }
    public class 협상완료Repositroy : StatusRepository<협상완료>, I협상완료QueryRepository
    {
        public 협상완료Repositroy(마켓DbContext context) : base(context)
        {
        }
    }
}
