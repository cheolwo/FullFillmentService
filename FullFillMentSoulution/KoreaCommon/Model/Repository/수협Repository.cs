using Common.Repository;

namespace KoreaCommon.Model.Repository
{
    public class 수산협동조합Repository : CenterRepository<수산협동조합>
    {
        public 수산협동조합Repository(수협DbContext context) : base(context)
        {
        }
    }
    
    public class 수산품별재고현황Repository : CommodityRepository<수산품별재고현황>
    {
        public 수산품별재고현황Repository(수협DbContext context) : base(context)
        {
        }
    }
    public class 수산창고Repository : CenterRepository<수산창고>
    {
        public 수산창고Repository(수협DbContext context) : base(context)
        {
        }
    }
    public class 수산품Repository : EntityRepository<수산품>
    {
        public 수산품Repository(수협DbContext context) : base(context)
        {
        }
    }
}
