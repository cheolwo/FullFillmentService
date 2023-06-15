using KoreaCommon.Fish.해양수산부;
using Quartz;

namespace 수협Server.Job
{
    public class 수협창고재고상품CollectingJob : IJob
    {
        private readonly I수협창고재고상품수집 _수협창고재고상품수집;
        public 수협창고재고상품CollectingJob(I수협창고재고상품수집 수협창고재고상품수집)
        {
            _수협창고재고상품수집 = 수협창고재고상품수집;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _수협창고재고상품수집.수협창고재고상품ToDb(DateTime.Now);
        }
    }
}
